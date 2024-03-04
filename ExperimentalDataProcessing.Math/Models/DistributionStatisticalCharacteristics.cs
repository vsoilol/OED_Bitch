namespace ExperimentalDataProcessing.Math.Models
{
    public class DistributionStatisticalCharacteristics
    {
        /// <summary>
        ///     Математическое ожидание
        /// </summary>
        public double Mean { get; set; }

        /// <summary>
        ///     Среднеквадратическое отклонение
        /// </summary>
        public double StdDev { get; set; }

        /// <summary>
        ///     Дисперсия
        /// </summary>
        public double Dispersion { get; set; }

        /// <summary>
        ///     Коэффициент асимметрии
        /// </summary>
        public double Skewness { get; set; }

        /// <summary>
        ///     Коэффициент эксцесса
        /// </summary>
        public double Kurtosis { get; set; }

        public double FirstCorrectedCentralMoment { get; set; }

        public double SecondCorrectedCentralMoment { get; set; }

        public double ThirdCorrectedCentralMoment { get; set; }

        public double FourthCorrectedCentralMoment { get; set; }
    }
}