using System;
using System.Collections.Generic;
using System.Threading;
using ExperimentalDataProcessing.Helpers;
using ExperimentalDataProcessing.Math.Models;
using MathNet.Numerics.Distributions;

namespace ExperimentalDataProcessing.Math.Distribution
{
    public sealed class PoissonDistribution : BaseDistribution
    {
        private readonly decimal _lambda;

        public PoissonDistribution(decimal lambda)
        {
            _lambda = lambda;

            CalculateTheoreticalCharacteristics();
        }

        public override bool IsDensityGraphingFromPoints { get; protected set; } = true;

        public override void GeneratePseudorandomValues(int valuesAmount, decimal estimateAccuracy,
            CancellationToken cancellationToken)
        {
            do
            {
                if (cancellationToken.IsCancellationRequested) throw new OperationCanceledException();

                PseudorandomValues = GeneratePseudorandomValuesUseFormulas(valuesAmount, cancellationToken);
            } while (!IsCheckPassed(estimateAccuracy));

            DataSaver.SaveDataToFile(PseudorandomValues, "Пуассона");
        }

        /// <summary>
        ///     На этом же свойстве основан популярный алгоритм Кнута.
        ///     Вместо суммы экспоненциальных величин, каждую из которых можно получить
        ///     методом инверсии через -ln(U),
        ///     используется произведение равномерных случайных величин:
        /// </summary>
        /// <returns></returns>
        private IEnumerable<decimal> GeneratePseudorandomValuesUseFormulas(int valuesAmount,
            CancellationToken cancellationToken)
        {
            var values = new decimal[valuesAmount];

            var expRateInv = MathHelper.Exp(-_lambda);

            for (var i = 0; i < valuesAmount; i++)
            {
                if (cancellationToken.IsCancellationRequested) throw new OperationCanceledException();

                decimal k = 0;
                var prod = GenerateUniform();

                while (prod > expRateInv)
                {
                    prod *= GenerateUniform();
                    ++k;
                }

                values[i] = k;
            }

            return values;
        }

        private IEnumerable<decimal> GeneratePseudorandomValuesUseLibrary(int valuesAmount,
            CancellationToken cancellationToken)
        {
            var exponential = new Poisson((double)_lambda);

            var values = new decimal[valuesAmount];

            for (var i = 0; i < valuesAmount; i++)
            {
                if (cancellationToken.IsCancellationRequested) throw new OperationCanceledException();

                values[i] = exponential.Sample();
            }

            return values;
        }

        protected override void CalculateTheoreticalCharacteristics()
        {
            var theoreticalMean = _lambda;
            var theoreticalDispersion = _lambda;
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
            var densityFunction = new Func<double, decimal?>(x => (decimal)PoissonDensity(x, (double)_lambda));
            return densityFunction;
        }

        protected override decimal CalculateIntervalHitProbability(decimal intervalStart, decimal intervalEnd)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Функцию плотности распределения Пуассона
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="lambda">Ламбда</param>
        /// <returns></returns>
        private double PoissonDensity(double x, double lambda)
        {
            double factorial = 1;
            for (var i = 2; i <= x; i++) factorial *= i;

            return System.Math.Pow(lambda, x) * System.Math.Exp(-lambda) / factorial;
        }
    }
}