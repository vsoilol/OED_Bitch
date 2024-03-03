using MathNet.Numerics.Distributions;

namespace ExperimentalDataProcessing.Math
{
    public static class MathHelper
    {
        /// <summary>
        ///     Получение табличного значения критерия Пирсона
        /// </summary>
        /// <param name="degreesOfFreedom">Число степеней свободы</param>
        /// <param name="alpha">Уровень значимости</param>
        /// <returns></returns>
        public static decimal GetCriticalChiSquareValue(int degreesOfFreedom, decimal alpha)
        {
            return (decimal)ChiSquared.InvCDF(degreesOfFreedom, 1 - (double)alpha);
        }

        /// <summary>
        ///     Рассчитать количество интервалов используя правило Стёрджеса
        /// </summary>
        /// <param name="n">Количество значений</param>
        /// <returns></returns>
        public static int CalculateIntervalsAmountUseSturgesRule(int n)
        {
            return (int)System.Math.Ceiling(System.Math.Log(n, 2) + 1);
        }

        public static decimal Pow(decimal x, double y)
        {
            return (decimal)System.Math.Pow((double)x, y);
        }

        public static decimal Sqrt(decimal x)
        {
            return (decimal)System.Math.Sqrt((double)x);
        }

        public static decimal Sqrt(double x)
        {
            return (decimal)System.Math.Sqrt(x);
        }

        public static decimal Log(decimal x)
        {
            return (decimal)System.Math.Log((double)x);
        }

        public static decimal Exp(decimal x)
        {
            return (decimal)System.Math.Exp((double)x);
        }
    }
}