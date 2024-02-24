using ExperimentalDataProcessing.Math.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExperimentalDataProcessing.Math.Distribution
{
    public abstract class BaseDistribution
    {
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

        public abstract Func<double, double?> GetDensityFunction();

        public IEnumerable<ParameterEstimation> CalculateParametersEstimation(double estimateAccuracy)
        {
            CalculateTheoreticalCharacteristics();
            CalculateExperimentalCharacteristics();

            var meanEstimation = CalculateParameterEstimation("Математическое ожидание", estimateAccuracy,
                ExperimentalCharacteristics.Mean, TheoreticalCharacteristics.Mean);

            var stdDevEstimation = CalculateParameterEstimation("Среднеквадратическое отклонение", estimateAccuracy,
                ExperimentalCharacteristics.StdDev, TheoreticalCharacteristics.StdDev);

            var dispersionEstimation = CalculateParameterEstimation("Дисперсия", estimateAccuracy,
                ExperimentalCharacteristics.Dispersion, TheoreticalCharacteristics.Dispersion);

            return new[] { meanEstimation, stdDevEstimation, dispersionEstimation };
        }

        private ParameterEstimation CalculateParameterEstimation(string name, double estimateAccuracy,
            double experimentalValue,
            double theoreticalValue)
        {
            var deviation = System.Math.Abs(experimentalValue - theoreticalValue);

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
    }
}