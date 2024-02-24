using System;
using ExperimentalDataProcessing.Helpers;
using ExperimentalDataProcessing.Math.Models;
using MathNet.Numerics.Distributions;

namespace ExperimentalDataProcessing.Math.Distribution
{
    public class PoissonDistribution : BaseDistribution
    {
        private readonly int _valuesAmount;
        private readonly double _lambda;

        public PoissonDistribution(int valuesAmount, double lambda)
        {
            _valuesAmount = valuesAmount;
            _lambda = lambda;
        }

        public override bool IsDensityGraphingFromPoints { get; protected set; } = true;

        public override void GeneratePseudorandomValues()
        {
            var exponential = new Poisson(_lambda);

            var values = new double[_valuesAmount];

            for (var i = 0; i < _valuesAmount; i++)
            {
                values[i] = exponential.Sample();
            }

            PseudorandomValues = values;
            DataSaver.SaveDataToFile(PseudorandomValues, "Пуассона");
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