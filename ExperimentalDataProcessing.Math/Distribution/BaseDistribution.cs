using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ExperimentalDataProcessing.Math.Models;

namespace ExperimentalDataProcessing.Math.Distribution
{
    public abstract class BaseDistribution
    {
        private readonly Random _random = new Random((int)DateTime.Now.Ticks);

        private IEnumerable<double> _pseudorandomValues;

        public virtual bool IsDensityGraphingFromPoints { get; protected set; } = false;

        public IEnumerable<double> PseudorandomValues
        {
            get => _pseudorandomValues;
            set
            {
                _pseudorandomValues = value;
                CalculateExperimentalCharacteristics();
            }
        }

        public DistributionStatisticalCharacteristics TheoreticalCharacteristics { get; protected set; } =
            new DistributionStatisticalCharacteristics();

        public DistributionStatisticalCharacteristics ExperimentalCharacteristics { get; protected set; } =
            new DistributionStatisticalCharacteristics();

        public double MaxValue => PseudorandomValues.Max();

        public double MinValue => PseudorandomValues.Min();

        public double ValuesRightBorder => PseudorandomValues.Max() + 10;

        public double ValuesLeftBorder => PseudorandomValues.Min() - 10;

        public int ValuesRightBorderInt => (int)System.Math.Round(ValuesRightBorder);

        public int ValuesLeftBorderInt => (int)System.Math.Round(ValuesLeftBorder);

        protected double GenerateUniform()
        {
            return _random.NextDouble();
        }

        public abstract void GeneratePseudorandomValues(int valuesAmount, double estimateAccuracy,
            CancellationToken cancellationToken);

        protected abstract void CalculateTheoreticalCharacteristics();

        private void CalculateExperimentalCharacteristics()
        {
            var valuesCount = PseudorandomValues.Count();

            var experimentalMean = PseudorandomValues.Sum() / valuesCount;
            var experimentalDispersion =
                PseudorandomValues.Sum(_ => System.Math.Pow(_ - experimentalMean, 2)) /
                (valuesCount - 1);
            var experimentalStdDev = System.Math.Sqrt(experimentalDispersion);

            var secondCentralMoment = CalculateCentralMoment(PseudorandomValues, (double)experimentalMean, 2);
            var thirdCentralMoment = CalculateCentralMoment(PseudorandomValues, (double)experimentalMean, 3);
            var fourthCentralMoment = CalculateCentralMoment(PseudorandomValues, (double)experimentalMean, 4);

            var thirdCorrectedCentralMoment = (thirdCentralMoment * System.Math.Pow(valuesCount, 2)) /
                                              ((valuesCount - 1) * (valuesCount - 2));

            var low = (valuesCount - 1d) * (valuesCount - 2d) * (valuesCount - 3d);

            var fourthCorrectedCentralMoment =
                (valuesCount * fourthCentralMoment * (System.Math.Pow(valuesCount, 2) - 2 * valuesCount + 3) -
                 3 * valuesCount * System.Math.Pow(secondCentralMoment, 2) * (2 * valuesCount - 3)) / low;

            var skewness = thirdCorrectedCentralMoment / System.Math.Pow((double)experimentalStdDev, 3);
            var kurtosis = (fourthCorrectedCentralMoment / System.Math.Pow((double)experimentalStdDev, 4)) - 3;

            ExperimentalCharacteristics = new DistributionStatisticalCharacteristics
            {
                Dispersion = experimentalDispersion,
                Mean = experimentalMean,
                StdDev = experimentalStdDev,
                Skewness = skewness,
                Kurtosis = kurtosis,
                FirstCorrectedCentralMoment = experimentalMean,
                SecondCorrectedCentralMoment = experimentalDispersion,
                ThirdCorrectedCentralMoment = thirdCorrectedCentralMoment,
                FourthCorrectedCentralMoment = fourthCorrectedCentralMoment
            };
        }

        protected virtual bool IsCheckPassed(double estimateAccuracy)
        {
            var meanDeviation =
                CalculateParameterDeviation(ExperimentalCharacteristics.Mean, TheoreticalCharacteristics.Mean);
            var dispersionDeviation =
                CalculateParameterDeviation(ExperimentalCharacteristics.Dispersion,
                    TheoreticalCharacteristics.Dispersion);

            return estimateAccuracy > meanDeviation && estimateAccuracy > dispersionDeviation;
        }

        public abstract Func<double, double?> GetDensityFunction();

        public IEnumerable<ParameterEstimation> CalculateParametersEstimation(double estimateAccuracy)
        {
            var meanEstimation = CalculateParameterEstimation("Математическое ожидание", estimateAccuracy,
                ExperimentalCharacteristics.Mean, TheoreticalCharacteristics.Mean);

            var dispersionEstimation = CalculateParameterEstimation("Дисперсия", estimateAccuracy,
                ExperimentalCharacteristics.Dispersion, TheoreticalCharacteristics.Dispersion);

            var stdDevEstimation = CalculateParameterEstimation("Cреднеквадратическое отклонение", estimateAccuracy,
                ExperimentalCharacteristics.StdDev, TheoreticalCharacteristics.StdDev);

            var maxValue = new ParameterEstimation("Максимальное значение", MaxValue);
            var minValue = new ParameterEstimation("Минимальное значение", MinValue);

            var firstCorrectedCentralMoment = new ParameterEstimation("Исправленный центральный момент 1-го порядка",
                ExperimentalCharacteristics.FirstCorrectedCentralMoment);
            
            var secondCorrectedCentralMoment = new ParameterEstimation("Исправленный центральный момент 2-го порядка",
                ExperimentalCharacteristics.SecondCorrectedCentralMoment);
            
            var thirdCorrectedCentralMoment = new ParameterEstimation("Исправленный центральный момент 3-го порядка",
                ExperimentalCharacteristics.ThirdCorrectedCentralMoment);
            
            var fourthCorrectedCentralMoment = new ParameterEstimation("Исправленный центральный момент 4-го порядка",
                ExperimentalCharacteristics.FourthCorrectedCentralMoment);

            var skewnessEstimation = CalculateParameterEstimation("Коэффициент асимметрии", estimateAccuracy,
                ExperimentalCharacteristics.Skewness, TheoreticalCharacteristics.Skewness);

            var kurtosisEstimation = CalculateParameterEstimation("Коэффициент эксцесса", estimateAccuracy,
                ExperimentalCharacteristics.Kurtosis, TheoreticalCharacteristics.Kurtosis);

            return new[]
            {
                minValue,
                maxValue,
                meanEstimation,
                dispersionEstimation,
                stdDevEstimation,
                firstCorrectedCentralMoment,
                secondCorrectedCentralMoment,
                thirdCorrectedCentralMoment,
                fourthCorrectedCentralMoment,
                skewnessEstimation,
                kurtosisEstimation
            };
        }

        private static ParameterEstimation CalculateParameterEstimation(string name, double estimateAccuracy,
            double experimentalValue,
            double theoreticalValue)
        {
            var deviation = CalculateParameterDeviation(experimentalValue, theoreticalValue);
            var hasPassedCheck = estimateAccuracy > deviation;

            return new ParameterEstimation(name, experimentalValue, theoreticalValue, deviation, hasPassedCheck);
        }

        protected static double CalculateParameterDeviation(double experimentalValue, double theoreticalValue)
        {
            return System.Math.Abs(experimentalValue - theoreticalValue);
        }

        /// <summary>
        ///     Проверить гипотезу о законе распределения
        /// </summary>
        /// <param name="significanceLevel">Уровень значимости</param>
        /// <param name="manualIntervalsAmount">Количество интервалов</param>
        /// <returns></returns>
        public VerifyHypothesisDistributionResult VerifyHypothesisDistribution(
            double significanceLevel, int? manualIntervalsAmount = null)
        {
            var intervalStart = PseudorandomValues.Min();

            var intervalEnd = PseudorandomValues.Max();

            var valuesAmount = PseudorandomValues.Count();
            var intervalsAmount = manualIntervalsAmount
                                  ?? MathHelper.CalculateIntervalsAmountUseSturgesRule(valuesAmount);

            var intervalsInfo = new List<IntervalHypothesisDistributionInfo>();

            var intervalStep = (intervalEnd - intervalStart) / intervalsAmount;

            double criterionOfConsent = 0;

            for (var i = 1; i <= intervalsAmount; i++)
            {
                var intervalPartStart = intervalStart + (i - 1) * intervalStep;
                var intervalPartEnd = intervalPartStart + intervalStep;

                var partValuesCount = PseudorandomValues
                    .Count(value => value <= intervalPartEnd && value > intervalPartStart);

                var hitProbability = CalculateIntervalHitProbability(intervalPartStart, intervalPartEnd);

                var theoreticalFrequencies = hitProbability * valuesAmount;

                criterionOfConsent += System.Math.Pow(theoreticalFrequencies - partValuesCount, 2) /
                                      theoreticalFrequencies;

                intervalsInfo.Add(new IntervalHypothesisDistributionInfo
                {
                    IntervalNumber = i,
                    IntervalStart = intervalPartStart,
                    IntervalEnd = intervalPartEnd,
                    ValuesCount = partValuesCount,
                    HitProbability = hitProbability,
                    TheoreticalFrequencies = theoreticalFrequencies
                });
            }

            var degreesOfFreedom = intervalsAmount - 2;

            var criticalChiSquareValue = MathHelper.GetCriticalChiSquareValue(degreesOfFreedom, significanceLevel);

            return new VerifyHypothesisDistributionResult
            {
                CriticalChiSquareValue = criticalChiSquareValue,
                CriterionOfConsent = criterionOfConsent,
                DegreesOfFreedom = degreesOfFreedom,
                IntervalsAmount = intervalsAmount,
                IsHypothesisRefuted = criterionOfConsent > criticalChiSquareValue,
                Intervals = intervalsInfo
            };
        }

        protected abstract double CalculateIntervalHitProbability(double intervalStart, double intervalEnd);

        /// <summary>
        /// Эмпирическим (выборочным) центральным моментом k-го порядка
        /// </summary>
        /// <param name="values">Значения</param>
        /// <param name="mean">Мат ожидание</param>
        /// <param name="k">Порядок</param>
        /// <returns></returns>
        private static double CalculateCentralMoment(IEnumerable<double> values, double mean, int k)
        {
            var enumerable = values as double[] ?? values.ToArray();
            var valuesAmount = enumerable.ToArray().Length;

            return enumerable.Sum(value => System.Math.Pow(value - mean, k)) / valuesAmount;
        }
    }
}