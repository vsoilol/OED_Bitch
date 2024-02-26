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
        private readonly double _mean;
        private readonly double _stdDev;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mean">Математическое ожидание</param>
        /// <param name="stdDev">Среднеквадратическое отклонение</param>
        /// <param name="valuesAmount">Количество значений</param>
        /// <param name="estimateAccuracy">Точность оценки</param>
        public NormalDistribution(int valuesAmount, double estimateAccuracy, double mean, double stdDev)
            : base(valuesAmount, estimateAccuracy)
        {
            _mean = mean;
            _stdDev = stdDev;

            CalculateTheoreticalCharacteristics();
        }

        public override void GeneratePseudorandomValues(CancellationToken cancellationToken)
        {
            do
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    throw new OperationCanceledException();
                }

                PseudorandomValues = GeneratePseudorandomValuesBasedOnCentralLimitTheorem(cancellationToken);
                CalculateExperimentalCharacteristics();
            } while (!IsCheckPassed());

            DataSaver.SaveDataToFile(PseudorandomValues, "Нормальное");
        }

        /// <summary>
        /// Метод, основанный на центральной предельной теореме
        /// https://intuit.ru/studies/courses/2260/156/lecture/27247?page=3
        /// Согласно центральной предельной теореме,
        /// при сложении достаточно большого количества независимых случайных
        /// величин с произвольным законом распределения получается случайная величина,
        /// распределенная по нормальному закону.
        /// https://ru.wikipedia.org/wiki/%D0%A6%D0%B5%D0%BD%D1%82%D1%80%D0%B0%D0%BB%D1%8C%D0%BD%D0%B0%D1%8F_%D0%BF%D1%80%D0%B5%D0%B4%D0%B5%D0%BB%D1%8C%D0%BD%D0%B0%D1%8F_%D1%82%D0%B5%D0%BE%D1%80%D0%B5%D0%BC%D0%B0
        /// </summary>
        /// <returns></returns>
        private IEnumerable<double> GeneratePseudorandomValuesBasedOnCentralLimitTheorem(
            CancellationToken cancellationToken)
        {
            var values = new double[ValuesAmount];

            for (var i = 0; i < ValuesAmount; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    throw new OperationCanceledException();
                }

                var n = 100; // Количество равномерно распределенных чисел для одного "эксперимента"

                double sum = 0;
                for (var a = 0; a < n; a++)
                {
                    sum += GenerateUniform();
                }

                var sampleMean = sum / n; // Среднее значение выборки

                // Нормализация с использованием ЦПТ
                var normalizedValue = _stdDev * (sampleMean - 0.5) * System.Math.Sqrt(12 * n) + _mean;

                values[i] = normalizedValue;
            }

            return values;
        }

        private IEnumerable<double> GeneratePseudorandomValuesUseLibrary(CancellationToken cancellationToken)
        {
            var normal = new Normal(_mean, _stdDev);

            var values = new double[ValuesAmount];

            for (var i = 0; i < ValuesAmount; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    throw new OperationCanceledException();
                }

                values[i] = normal.Sample();
            }

            return values;
        }

        protected override void CalculateTheoreticalCharacteristics()
        {
            var theoreticalMean = _mean;
            var theoreticalStdDev = _stdDev;
            var theoreticalDispersion = System.Math.Pow(_stdDev, 2);

            TheoreticalCharacteristics = new DistributionStatisticalCharacteristics
            {
                Dispersion = theoreticalDispersion,
                Mean = theoreticalMean,
                StdDev = theoreticalStdDev
            };
        }

        public override Func<double, double?> GetDensityFunction()
        {
            var densityFunction = new Func<double, double?>(x => NormalDensity(x, _mean, _stdDev));
            return densityFunction;
        }

        /// <summary>
        ///     Функция плотности нормального распределения
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="mean">Математическое ожидание</param>
        /// <param name="stdDev">Среднее квадратическое отклонение</param>
        /// <returns></returns>
        private static double NormalDensity(double x, double mean, double stdDev)
        {
            return 1.0 / (stdDev * System.Math.Sqrt(2 * System.Math.PI)) *
                   System.Math.Exp(-0.5 * System.Math.Pow((x - mean) / stdDev, 2));
        }
    }
}