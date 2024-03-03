using System;
using System.Collections.Generic;
using System.Threading;
using ExperimentalDataProcessing.Helpers;
using ExperimentalDataProcessing.Math.Models;
using MathNet.Numerics.Distributions;

namespace ExperimentalDataProcessing.Math.Distribution
{
    public sealed class ContinuousUniformDistribution : BaseDistribution
    {
        private readonly decimal _intervalEnd;
        private readonly decimal _intervalStart;

        public ContinuousUniformDistribution(decimal intervalStart, decimal intervalEnd)
        {
            _intervalStart = intervalStart;
            _intervalEnd = intervalEnd;

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

            DataSaver.SaveDataToFile(PseudorandomValues, "Равномерное");
        }

        private IEnumerable<decimal> GeneratePseudorandomValuesUseFormulas(int valuesAmount,
            CancellationToken cancellationToken)
        {
            var values = new decimal[valuesAmount];

            for (var i = 0; i < valuesAmount; i++)
            {
                if (cancellationToken.IsCancellationRequested) throw new OperationCanceledException();

                values[i] = (_intervalEnd - _intervalStart) * GenerateUniform() + _intervalStart;
            }

            return values;
        }

        private IEnumerable<double> GeneratePseudorandomValuesUseLibrary(int valuesAmount,
            CancellationToken cancellationToken)
        {
            var continuousUniform = new ContinuousUniform((double)_intervalStart, (double)_intervalEnd);

            var values = new double[valuesAmount];

            for (var i = 0; i < valuesAmount; i++)
            {
                if (cancellationToken.IsCancellationRequested) throw new OperationCanceledException();

                values[i] = continuousUniform.Sample();
            }

            return values;
        }

        protected override void CalculateTheoreticalCharacteristics()
        {
            var theoreticalMean = (_intervalStart + _intervalEnd) / 2;
            var theoreticalDispersion = MathHelper.Pow(_intervalEnd - _intervalStart, 2) / 12;
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
            var densityFunction = new Func<double, decimal?>(x =>
                ContinuousUniformDensity(x, _intervalStart, _intervalEnd));
            return densityFunction;
        }

        protected override decimal CalculateIntervalHitProbability(decimal intervalStart, decimal intervalEnd)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Функцию плотности равномерного распределения
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="intervalStart">Начало интервала</param>
        /// <param name="intervalEnd">Конец интервала</param>
        /// <returns></returns>
        private static decimal ContinuousUniformDensity(double x, decimal intervalStart, decimal intervalEnd)
        {
            if ((decimal)x >= intervalStart && (decimal)x <= intervalEnd) return 1 / (intervalEnd - intervalStart);

            return 0;
        }
    }
}