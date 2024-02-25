using ExperimentalDataProcessing.Math.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExperimentalDataProcessing.Math.Distribution
{
    public abstract class BaseDistribution
    {
        private readonly Random _random = new Random((int)DateTime.Now.Ticks);

        protected BaseDistribution(int valuesAmount, double estimateAccuracy)
        {
            ValuesAmount = valuesAmount;
            EstimateAccuracy = estimateAccuracy;
        }

        public double EstimateAccuracy { get; private set; }

        public int ValuesAmount { get; private set; }

        protected double GenerateUniform() => _random.NextDouble();

        public virtual bool IsDensityGraphingFromPoints { get; protected set; } = false;

        public IEnumerable<double> PseudorandomValues { get; protected set; }

        public DistributionStatisticalCharacteristics TheoreticalCharacteristics { get; protected set; } =
            new DistributionStatisticalCharacteristics();

        public DistributionStatisticalCharacteristics ExperimentalCharacteristics { get; protected set; } =
            new DistributionStatisticalCharacteristics();

        public double MaxValue => PseudorandomValues.Max() + 10;

        public double MinValue => PseudorandomValues.Min() - 10;

        public int MaxIntValue => (int)System.Math.Round(MaxValue);

        public int MinIntValue => (int)System.Math.Round(MinValue);

        public abstract void GeneratePseudorandomValues();

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

        protected virtual bool IsCheckPassed()
        {
            var meanDeviation =
                CalculateParameterDeviation(ExperimentalCharacteristics.Mean, TheoreticalCharacteristics.Mean);
            var dispersionDeviation =
                CalculateParameterDeviation(ExperimentalCharacteristics.Dispersion,
                    TheoreticalCharacteristics.Dispersion);

            return EstimateAccuracy > meanDeviation && EstimateAccuracy > dispersionDeviation;
        }

        public abstract Func<double, double?> GetDensityFunction();

        public IEnumerable<ParameterEstimation> CalculateParametersEstimation()
        {
            var meanEstimation = CalculateParameterEstimation("Математическое ожидание", EstimateAccuracy,
                ExperimentalCharacteristics.Mean, TheoreticalCharacteristics.Mean);

            var dispersionEstimation = CalculateParameterEstimation("Дисперсия", EstimateAccuracy,
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
    }
}