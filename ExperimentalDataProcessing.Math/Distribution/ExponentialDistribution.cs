using System;
using System.Collections.Generic;
using ExperimentalDataProcessing.Helpers;
using ExperimentalDataProcessing.Math.Models;
using MathNet.Numerics.Distributions;

namespace ExperimentalDataProcessing.Math.Distribution
{
    public sealed class ExponentialDistribution : BaseDistribution
    {
        private readonly double _lambda;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="valuesAmount">Количество значений</param>
        /// <param name="estimateAccuracy">Точность оценки</param>
        /// <param name="lambda">Параметр интенсивности (лямбда)</param>
        public ExponentialDistribution(int valuesAmount, double estimateAccuracy, double lambda)
            : base(valuesAmount, estimateAccuracy)
        {
            _lambda = lambda;
            
            CalculateTheoreticalCharacteristics();
        }

        public override void GeneratePseudorandomValues()
        {
            do
            {
                PseudorandomValues = GeneratePseudorandomValuesUseFormulas();
                CalculateExperimentalCharacteristics();
            } while (!IsCheckPassed());
            
            DataSaver.SaveDataToFile(PseudorandomValues, "Показательное");
        }
        
        private IEnumerable<double> GeneratePseudorandomValuesUseFormulas()
        {
            var values = new double[ValuesAmount];

            for (var i = 0; i < ValuesAmount; i++)
            {
                values[i] = (-1 / _lambda) * System.Math.Log(this.GenerateUniform());
            }

            return values;
        }
        
        private IEnumerable<double> GeneratePseudorandomValuesUseLibrary()
        {
            var exponential = new Exponential(_lambda);

            var values = new double[ValuesAmount];

            for (var i = 0; i < ValuesAmount; i++)
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