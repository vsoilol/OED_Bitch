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
        private readonly decimal _lambda;

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="lambda">Параметр интенсивности (лямбда)</param>
        public ExponentialDistribution(decimal lambda)
        {
            _lambda = lambda;

            CalculateTheoreticalCharacteristics();
        }

        public override void GeneratePseudorandomValues(int valuesAmount, decimal estimateAccuracy,
            CancellationToken cancellationToken)
        {
            do
            {
                if (cancellationToken.IsCancellationRequested) throw new OperationCanceledException();

                PseudorandomValues = GeneratePseudorandomValuesUseFormulas(valuesAmount, cancellationToken);
            } while (!IsCheckPassed(estimateAccuracy));

            DataSaver.SaveDataToFile(PseudorandomValues, "Показательное");
        }

        private IEnumerable<decimal> GeneratePseudorandomValuesUseFormulas(int valuesAmount,
            CancellationToken cancellationToken)
        {
            var values = new decimal[valuesAmount];

            for (var i = 0; i < valuesAmount; i++)
            {
                if (cancellationToken.IsCancellationRequested) throw new OperationCanceledException();

                values[i] = -1 / _lambda * MathHelper.Log(GenerateUniform());
            }

            return values;
        }

        private IEnumerable<decimal> GeneratePseudorandomValuesUseLibrary(int valuesAmount,
            CancellationToken cancellationToken)
        {
            var exponential = new Exponential((double)_lambda);

            var values = new decimal[valuesAmount];

            for (var i = 0; i < valuesAmount; i++)
            {
                if (cancellationToken.IsCancellationRequested) throw new OperationCanceledException();

                values[i] = (decimal)exponential.Sample();
            }

            return values;
        }

        protected override void CalculateTheoreticalCharacteristics()
        {
            var theoreticalMean = 1 / _lambda;
            var theoreticalDispersion = 1 / MathHelper.Pow(_lambda, 2);
            var theoreticalStdDev = MathHelper.Sqrt(theoreticalDispersion);

            TheoreticalCharacteristics = new DistributionStatisticalCharacteristics
            {
                Dispersion = theoreticalDispersion,
                Mean = theoreticalMean,
                StdDev = theoreticalStdDev
            };
        }

        public override Func<double, decimal?> GetDensityFunction()
        {
            var densityFunction = new Func<double, decimal?>(x => ExponentialDensity(x, _lambda));
            return densityFunction;
        }

        protected override decimal CalculateIntervalHitProbability(decimal intervalStart, decimal intervalEnd)
        {
            var hitProbability = MathHelper.Exp(-1 * _lambda * intervalStart)
                                 - MathHelper.Exp(-1 * _lambda * intervalEnd);

            return hitProbability;
        }

        /// <summary>
        ///     Функцию плотности нормального распределения
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="lambda">Параметр интенсивности (лямбда)</param>
        /// <returns></returns>
        private static decimal ExponentialDensity(double x, decimal lambda)
        {
            if (x < 0) return 0;

            return lambda * MathHelper.Exp(-lambda * (decimal)x);
        }
    }
}