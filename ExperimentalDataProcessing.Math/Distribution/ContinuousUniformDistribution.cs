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
        private readonly double _intervalEnd;
        private readonly double _intervalStart;

        public ContinuousUniformDistribution(double intervalStart, double intervalEnd)
        {
            _intervalStart = intervalStart;
            _intervalEnd = intervalEnd;

            CalculateTheoreticalCharacteristics();
        }

        public override void GeneratePseudorandomValues(int valuesAmount, double estimateAccuracy,
            CancellationToken cancellationToken)
        {
            do
            {
                if (cancellationToken.IsCancellationRequested) throw new OperationCanceledException();

                PseudorandomValues = GeneratePseudorandomValuesUseFormulas(valuesAmount, cancellationToken);
                CalculateExperimentalCharacteristics();
            } while (!IsCheckPassed(estimateAccuracy));

            DataSaver.SaveDataToFile(PseudorandomValues, "Равномерное");
        }

        private IEnumerable<double> GeneratePseudorandomValuesUseFormulas(int valuesAmount,
            CancellationToken cancellationToken)
        {
            var values = new double[valuesAmount];

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
            var continuousUniform = new ContinuousUniform(_intervalStart, _intervalEnd);

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
            var theoreticalDispersion = System.Math.Pow(_intervalEnd - _intervalStart, 2) / 12;
            var theoreticalStdDev = System.Math.Sqrt(theoreticalDispersion);

            TheoreticalCharacteristics = new DistributionStatisticalCharacteristics
            {
                Dispersion = theoreticalDispersion,
                Mean = theoreticalMean,
                StdDev = theoreticalStdDev
            };
        }

        public override Func<double, double?> GetDensityFunction()
        {
            var densityFunction =
                new Func<double, double?>(x => ContinuousUniformDensity(x, _intervalStart, _intervalEnd));
            return densityFunction;
        }

        protected override double CalculateIntervalHitProbability(double intervalStart, double intervalEnd)
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
        private static double ContinuousUniformDensity(double x, double intervalStart, double intervalEnd)
        {
            if (x >= intervalStart && x <= intervalEnd) return 1 / (intervalEnd - intervalStart);

            return 0;
        }
    }
}