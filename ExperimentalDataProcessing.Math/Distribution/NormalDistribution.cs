using System;
using System.Collections.Generic;
using System.Threading;
using ExperimentalDataProcessing.Helpers;
using ExperimentalDataProcessing.Math.Models;
using MathNet.Numerics.Distributions;

namespace ExperimentalDataProcessing.Math.Distribution
{
    public sealed class NormalDistribution : BaseDistribution
    {
        private readonly decimal _mean;
        private readonly decimal _stdDev;

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="mean">Математическое ожидание</param>
        /// <param name="stdDev">Среднеквадратическое отклонение</param>
        public NormalDistribution(decimal mean, decimal stdDev)
        {
            _mean = mean;
            _stdDev = stdDev;

            CalculateTheoreticalCharacteristics();
        }

        public override void GeneratePseudorandomValues(int valuesAmount, decimal estimateAccuracy,
            CancellationToken cancellationToken)
        {
            do
            {
                if (cancellationToken.IsCancellationRequested) throw new OperationCanceledException();

                PseudorandomValues =
                    GeneratePseudorandomValuesBasedOnCentralLimitTheorem(valuesAmount, cancellationToken);
            } while (!IsCheckPassed(estimateAccuracy));

            DataSaver.SaveDataToFile(PseudorandomValues, "Нормальное");
        }

        /// <summary>
        ///     Метод, основанный на центральной предельной теореме
        ///     https://intuit.ru/studies/courses/2260/156/lecture/27247?page=3
        ///     Согласно центральной предельной теореме,
        ///     при сложении достаточно большого количества независимых случайных
        ///     величин с произвольным законом распределения получается случайная величина,
        ///     распределенная по нормальному закону.
        ///     https://ru.wikipedia.org/wiki/%D0%A6%D0%B5%D0%BD%D1%82%D1%80%D0%B0%D0%BB%D1%8C%D0%BD%D0%B0%D1%8F_%D0%BF%D1%80%D0%B5%D0%B4%D0%B5%D0%BB%D1%8C%D0%BD%D0%B0%D1%8F_%D1%82%D0%B5%D0%BE%D1%80%D0%B5%D0%BC%D0%B0
        /// </summary>
        /// <returns></returns>
        private IEnumerable<decimal> GeneratePseudorandomValuesBasedOnCentralLimitTheorem(int valuesAmount,
            CancellationToken cancellationToken)
        {
            var values = new decimal[valuesAmount];

            for (var i = 0; i < valuesAmount; i++)
            {
                if (cancellationToken.IsCancellationRequested) throw new OperationCanceledException();

                var n = 100; // Количество равномерно распределенных чисел для одного "эксперимента"

                decimal sum = 0;
                for (var a = 0; a < n; a++) sum += GenerateUniform();

                var sampleMean = sum / n; // Среднее значение выборки

                // Нормализация с использованием ЦПТ
                var normalizedValue = _stdDev * (sampleMean - 0.5m) * MathHelper.Sqrt(12m * n) + _mean;

                values[i] = normalizedValue;
            }

            return values;
        }

        private IEnumerable<decimal> GeneratePseudorandomValuesUseLibrary(int valuesAmount,
            CancellationToken cancellationToken)
        {
            var normal = new Normal((double)_mean, (double)_stdDev);

            var values = new decimal[valuesAmount];

            for (var i = 0; i < valuesAmount; i++)
            {
                if (cancellationToken.IsCancellationRequested) throw new OperationCanceledException();

                values[i] = (decimal)normal.Sample();
            }

            return values;
        }

        protected override void CalculateTheoreticalCharacteristics()
        {
            var theoreticalMean = _mean;
            var theoreticalStdDev = _stdDev;
            var theoreticalDispersion = MathHelper.Pow(_stdDev, 2);

            TheoreticalCharacteristics = new DistributionStatisticalCharacteristics
            {
                Dispersion = theoreticalDispersion,
                Mean = theoreticalMean,
                StdDev = theoreticalStdDev
            };
        }

        public override Func<double, decimal?> GetDensityFunction()
        {
            var densityFunction = new Func<double, decimal?>(x => NormalDensity(x, _mean, _stdDev));
            return densityFunction;
        }

        protected override decimal CalculateIntervalHitProbability(decimal intervalStart, decimal intervalEnd)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Функция плотности нормального распределения
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="mean">Математическое ожидание</param>
        /// <param name="stdDev">Среднее квадратическое отклонение</param>
        /// <returns></returns>
        private static decimal NormalDensity(double x, decimal mean, decimal stdDev)
        {
            return 1.0m / (stdDev * MathHelper.Sqrt(2 * System.Math.PI)) *
                   MathHelper.Exp(-0.5m * MathHelper.Pow(((decimal)x - mean) / stdDev, 2));
        }
    }
}