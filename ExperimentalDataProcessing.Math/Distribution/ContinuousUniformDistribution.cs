using System;
using System.Collections.Generic;
using ExperimentalDataProcessing.Helpers;
using ExperimentalDataProcessing.Math.Models;
using MathNet.Numerics.Distributions;

namespace ExperimentalDataProcessing.Math.Distribution
{
    public sealed class ContinuousUniformDistribution : BaseDistribution
    {
        private readonly double _intervalStart;
        private readonly double _intervalEnd;

        public ContinuousUniformDistribution(int valuesAmount, double estimateAccuracy, double intervalStart,
            double intervalEnd) : base(valuesAmount, estimateAccuracy)
        {
            _intervalStart = intervalStart;
            _intervalEnd = intervalEnd;
            
            CalculateTheoreticalCharacteristics();
        }

        public override void GeneratePseudorandomValues()
        {
            do
            {
                PseudorandomValues = GeneratePseudorandomValuesUseFormulas();
                CalculateExperimentalCharacteristics();
            } while (!IsCheckPassed());
            
            DataSaver.SaveDataToFile(PseudorandomValues, "Равномерное");
        }

        private IEnumerable<double> GeneratePseudorandomValuesUseFormulas()
        {
            var values = new double[ValuesAmount];

            for (var i = 0; i < ValuesAmount; i++)
            {
                values[i] = (_intervalEnd - _intervalStart) * this.GenerateUniform() + _intervalStart;
            }

            return values;
        }

        private IEnumerable<double> GeneratePseudorandomValuesUseLibrary()
        {
            var continuousUniform = new ContinuousUniform(_intervalStart, _intervalEnd);

            var values = new double[ValuesAmount];

            for (var i = 0; i < ValuesAmount; i++)
            {
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