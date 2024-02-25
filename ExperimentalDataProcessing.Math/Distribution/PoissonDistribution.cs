using System;
using System.Collections.Generic;
using ExperimentalDataProcessing.Helpers;
using ExperimentalDataProcessing.Math.Models;
using MathNet.Numerics.Distributions;

namespace ExperimentalDataProcessing.Math.Distribution
{
    public sealed class PoissonDistribution : BaseDistribution
    {
        private readonly double _lambda;
        
        public override bool IsDensityGraphingFromPoints { get; protected set; } = true;

        public PoissonDistribution(int valuesAmount, double estimateAccuracy, double lambda)
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
            
            DataSaver.SaveDataToFile(PseudorandomValues, "Пуассона");
        }

        /// <summary>
        /// На этом же свойстве основан популярный алгоритм Кнута.
        /// Вместо суммы экспоненциальных величин, каждую из которых можно получить
        /// методом инверсии через -ln(U),
        /// используется произведение равномерных случайных величин:
        /// </summary>
        /// <returns></returns>
        private IEnumerable<double> GeneratePseudorandomValuesUseFormulas()
        {
            var values = new double[ValuesAmount];

            var expRateInv = System.Math.Exp(-_lambda);

            for (var i = 0; i < ValuesAmount; i++)
            {
                double k = 0;
                var prod = this.GenerateUniform();

                while (prod > expRateInv)
                {
                    prod *= this.GenerateUniform();
                    ++k;
                }

                values[i] = k;
            }

            return values;
        }

        private IEnumerable<double> GeneratePseudorandomValuesUseLibrary()
        {
            var exponential = new Poisson(_lambda);

            var values = new double[ValuesAmount];

            for (var i = 0; i < ValuesAmount; i++)
            {
                values[i] = exponential.Sample();
            }

            return values;
        }

        protected override void CalculateTheoreticalCharacteristics()
        {
            var theoreticalMean = _lambda;
            var theoreticalDispersion = _lambda;
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
            var densityFunction = new Func<double, double?>(x => PoissonDensity(x, _lambda));
            return densityFunction;
        }

        /// <summary>
        /// Функцию плотности распределения Пуассона
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="lambda">Ламбда</param>
        /// <returns></returns>
        private double PoissonDensity(double x, double lambda)
        {
            double factorial = 1;
            for (var i = 2; i <= x; i++)
            {
                factorial *= i;
            }

            return System.Math.Pow(lambda, x) * System.Math.Exp(-lambda) / factorial;
        }
    }
}