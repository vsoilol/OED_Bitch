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
        public static double GetCriticalChiSquareValue(int degreesOfFreedom, double alpha)
        {
            return ChiSquared.InvCDF(degreesOfFreedom, 1 - alpha);
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
    }
}