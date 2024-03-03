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

        public virtual bool IsDensityGraphingFromPoints { get; protected set; } = false;

        public IEnumerable<double> PseudorandomValues { get; set; }

        public DistributionStatisticalCharacteristics TheoreticalCharacteristics { get; protected set; } =
            new DistributionStatisticalCharacteristics();

        public DistributionStatisticalCharacteristics ExperimentalCharacteristics { get; protected set; } =
            new DistributionStatisticalCharacteristics();

        public double MaxValue => PseudorandomValues.Max() + 10;

        public double MinValue => PseudorandomValues.Min() - 10;

        public int MaxIntValue => (int)System.Math.Round(MaxValue);

        public int MinIntValue => (int)System.Math.Round(MinValue);

        protected double GenerateUniform()
        {
            return _random.NextDouble();
        }

        public abstract void GeneratePseudorandomValues(int valuesAmount, double estimateAccuracy,
            CancellationToken cancellationToken);

        protected abstract void CalculateTheoreticalCharacteristics();

        protected virtual void CalculateExperimentalCharacteristics()
        {
            var experimentalMean = PseudorandomValues.Sum() / PseudorandomValues.Count();
            var experimentalDispersion = PseudorandomValues.Sum(_ => System.Math.Pow(_ - experimentalMean, 2)) /
                                         (PseudorandomValues.Count() - 1);
            var experimentalStdDev = System.Math.Sqrt(experimentalDispersion);

            ExperimentalCharacteristics = new DistributionStatisticalCharacteristics
            {
                Dispersion = experimentalDispersion,
                Mean = experimentalMean,
                StdDev = experimentalStdDev
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

            return new[] { meanEstimation, dispersionEstimation };
        }

        private static ParameterEstimation CalculateParameterEstimation(string name, double estimateAccuracy,
            double experimentalValue,
            double theoreticalValue)
        {
            var deviation = CalculateParameterDeviation(experimentalValue, theoreticalValue);
            var hasPassedCheck = estimateAccuracy > deviation;

            return new ParameterEstimation
            {
                Name = name,
                TheoreticalValue = theoreticalValue,
                ExperimentalValue = experimentalValue,
                Deviation = deviation,
                HasPassedCheck = hasPassedCheck
            };
        }

        private static double CalculateParameterDeviation(double experimentalValue, double theoreticalValue)
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
                    IntervalEnd = intervalEnd,
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
    }
}