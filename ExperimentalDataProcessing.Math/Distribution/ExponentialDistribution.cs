using System;
using System.Collections.Generic;
using ExperimentalDataProcessing.Helpers;
using ExperimentalDataProcessing.Math.Models;
using MathNet.Numerics.Distributions;

namespace ExperimentalDataProcessing.Math.Distribution
{
    public class ExponentialDistribution : BaseDistribution
    {
        private readonly int _valuesAmount;
        private readonly double _lambda;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="valuesAmount">Количество значений</param>
        /// <param name="lambda">Параметр интенсивности (лямбда)</param>
        public ExponentialDistribution(int valuesAmount, double lambda)
        {
            _valuesAmount = valuesAmount;
            _lambda = lambda;
        }

        public override void GeneratePseudorandomValues()
        {
            PseudorandomValues = GeneratePseudorandomValuesUseFormulas();
            DataSaver.SaveDataToFile(PseudorandomValues, "Показательное");
        }
        
        private IEnumerable<double> GeneratePseudorandomValuesUseFormulas()
        {
            var values = new double[_valuesAmount];

            for (var i = 0; i < _valuesAmount; i++)
            {
                values[i] = (-1 / _lambda) * System.Math.Log(this.GenerateUniform());
            }

            return values;
        }
        
        private IEnumerable<double> GeneratePseudorandomValuesUseLibrary()
        {
            var exponential = new Exponential(_lambda);

            var values = new double[_valuesAmount];

            for (var i = 0; i < _valuesAmount; i++)
            {
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
                StdDev = theoreticalStdDev
            };
        }

        public override Func<double, double?> GetDensityFunction()
        {
            var densityFunction = new Func<double, double?>(x => ExponentialDensity(x, _lambda));
            return densityFunction;
        }

        /// <summary>
        /// Функцию плотности нормального распределения
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="lambda">Параметр интенсивности (лямбда)</param>
        /// <returns></returns>
        private static double ExponentialDensity(double x, double lambda)
        {
            if (x < 0)
            {
                return 0;
            }

            return lambda * System.Math.Exp(-lambda * x);
        }
    }
}