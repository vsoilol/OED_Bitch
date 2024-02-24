using System;
using System.Linq;
using ExperimentalDataProcessing.Helpers;
using ExperimentalDataProcessing.Math.Models;
using MathNet.Numerics.Distributions;

namespace ExperimentalDataProcessing.Math.Distribution
{
    public class ContinuousUniformDistribution : BaseDistribution
    {
        private readonly int _valuesAmount;
        private readonly double _intervalStart;
        private readonly double _intervalEnd;

        public ContinuousUniformDistribution(int valuesAmount, double intervalStart, double intervalEnd)
        {
            _valuesAmount = valuesAmount;
            _intervalStart = intervalStart;
            _intervalEnd = intervalEnd;
        }

        public override void GeneratePseudorandomValues()
        {
            var continuousUniform = new ContinuousUniform(_intervalStart, _intervalEnd);

            var values = new double[_valuesAmount];

            for (var i = 0; i < _valuesAmount; i++)
            {
                values[i] = continuousUniform.Sample();
            }

            PseudorandomValues = values;
            DataSaver.SaveDataToFile(PseudorandomValues, "Равномерное");
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

        /// <summary>
        /// Функцию плотности равномерного распределения
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="intervalStart">Начало интервала</param>
        /// <param name="intervalEnd">Конец интервала</param>
        /// <returns></returns>
        private static double ContinuousUniformDensity(double x, double intervalStart, double intervalEnd)
        {
            if (x >= intervalStart && x <= intervalEnd)
            {
                return 1 / (intervalEnd - intervalStart);
            }

            return 0;
        }
    }
}