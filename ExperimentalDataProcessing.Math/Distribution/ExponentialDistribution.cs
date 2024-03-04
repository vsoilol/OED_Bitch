using System;
using System.Collections.Generic;
using System.Threading;
using ExperimentalDataProcessing.Helpers;
using ExperimentalDataProcessing.Math.Models;
using MathNet.Numerics.Distributions;

namespace ExperimentalDataProcessing.Math.Distribution
{
    public sealed class ExponentialDistribution : BaseDistribution
    {
        private readonly double _lambda;

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="lambda">Параметр интенсивности (лямбда)</param>
        public ExponentialDistribution(double lambda)
        {
            _lambda = lambda;

            CalculateTheoreticalCharacteristics();
        }

        public override void GeneratePseudorandomValues(int valuesAmount, double estimateAccuracy,
            CancellationToken cancellationToken)
        {
            do
            {
                if (cancellationToken.IsCancellationRequested) throw new OperationCanceledException();

                PseudorandomValues = GeneratePseudorandomValuesUseFormulas(valuesAmount, cancellationToken);
            } while (!IsCheckPassed(estimateAccuracy));

            DataSaver.SaveDataToFile(PseudorandomValues, "Показательное");
        }

        private IEnumerable<double> GeneratePseudorandomValuesUseFormulas(int valuesAmount,
            CancellationToken cancellationToken)
        {
            var values = new double[valuesAmount];

            for (var i = 0; i < valuesAmount; i++)
            {
                if (cancellationToken.IsCancellationRequested) throw new OperationCanceledException();

                values[i] = -1 / _lambda * System.Math.Log(GenerateUniform());
            }

            return values;
        }

        private IEnumerable<double> GeneratePseudorandomValuesUseLibrary(int valuesAmount,
            CancellationToken cancellationToken)
        {
            var exponential = new Exponential(_lambda);

            var values = new double[valuesAmount];

            for (var i = 0; i < valuesAmount; i++)
            {
                if (cancellationToken.IsCancellationRequested) throw new OperationCanceledException();

                values[i] = exponential.Sample();
            }

            return values;
        }

        protected override void CalculateTheoreticalCharacteristics()
        {
            var theoreticalMean = 1 / _lambda;
            var theoreticalDispersion = 1 / System.Math.Pow(_lambda, 2);
            var theoreticalStdDev = System.Math.Sqrt(theoreticalDispersion);

            TheoreticalCharacteristics = new DistributionStatisticalCharacteristics
            {
                Dispersion = theoreticalDispersion,
                Mean = theoreticalMean,
                StdDev = theoreticalStdDev,
                Skewness = 2,
                Kurtosis = 6
            };
        }

        public override Func<double, double?> GetDensityFunction()
        {
            var densityFunction = new Func<double, double?>(x => ExponentialDensity(x, _lambda));
            return densityFunction;
        }

        protected override double CalculateIntervalHitProbability(double intervalStart, double intervalEnd)
        {
            var hitProbability = System.Math.Exp(-1 * _lambda * intervalStart)
                                 - System.Math.Exp(-1 * _lambda * intervalEnd);

            return hitProbability;
        }

        protected override bool IsCheckPassed(double estimateAccuracy)
        {
            var kurtosisDeviation =
                CalculateParameterDeviation(ExperimentalCharacteristics.Kurtosis,
                    TheoreticalCharacteristics.Kurtosis);

            var skewnessDeviation =
                CalculateParameterDeviation(ExperimentalCharacteristics.Skewness,
                    TheoreticalCharacteristics.Skewness);

            return base.IsCheckPassed(estimateAccuracy) && estimateAccuracy > kurtosisDeviation &&
                   estimateAccuracy > skewnessDeviation;
        }

        /// <summary>
        ///     Функцию плотности нормального распределения
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="lambda">Параметр интенсивности (лямбда)</param>
        /// <returns></returns>
        private static double ExponentialDensity(double x, double lambda)
        {
            if (x < 0) return 0;

            return lambda * System.Math.Exp(-lambda * x);
        }
    }
}