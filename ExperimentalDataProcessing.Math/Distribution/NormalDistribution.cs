using System;
using System.Linq;
using ExperimentalDataProcessing.Helpers;
using ExperimentalDataProcessing.Math.Models;
using MathNet.Numerics.Distributions;

namespace ExperimentalDataProcessing.Math.Distribution
{
    public class NormalDistribution : BaseDistribution
    {
        private readonly double _mean;
        private readonly double _stdDev;
        private readonly int _valuesAmount;

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="mean">Математическое ожидание</param>
        /// <param name="stdDev">Среднеквадратическое отклонение</param>
        /// <param name="valuesAmount">Количество значений</param>
        public NormalDistribution(double mean, double stdDev, int valuesAmount)
        {
            _mean = mean;
            _stdDev = stdDev;
            _valuesAmount = valuesAmount;
        }

        public override void GeneratePseudorandomValues()
        {
            var normal = new Normal(_mean, _stdDev);

            var values = new double[_valuesAmount];

            for (var i = 0; i < _valuesAmount; i++)
            {
                values[i] = normal.Sample();
            }

            PseudorandomValues = values;
            DataSaver.SaveDataToFile(PseudorandomValues, "Нормальное");
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