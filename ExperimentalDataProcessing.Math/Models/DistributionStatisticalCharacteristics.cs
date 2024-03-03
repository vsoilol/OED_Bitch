namespace ExperimentalDataProcessing.Math.Models
{
    public class DistributionStatisticalCharacteristics
    {
        /// <summary>
        ///     Математическое ожидание
        /// </summary>
        public decimal Mean { get; set; }

        /// <summary>
        ///     Среднеквадратическое отклонение
        /// </summary>
        public decimal StdDev { get; set; }

        /// <summary>
        ///     Дисперсия
        /// </summary>
        public decimal Dispersion { get; set; }
    }
}