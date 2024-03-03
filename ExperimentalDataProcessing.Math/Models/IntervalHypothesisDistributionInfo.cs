namespace ExperimentalDataProcessing.Math.Models
{
    public class IntervalHypothesisDistributionInfo
    {
        /// <summary>
        ///     Номер интервала
        /// </summary>
        public int IntervalNumber { get; set; }

        /// <summary>
        ///     Начало интервала
        /// </summary>
        public double IntervalStart { get; set; }

        /// <summary>
        ///     Конец интервала
        /// </summary>
        public double IntervalEnd { get; set; }

        /// <summary>
        ///     Количество значений в интервале
        /// </summary>
        public int ValuesCount { get; set; }

        /// <summary>
        ///     Вероятность попадания в интервал
        /// </summary>
        public double HitProbability { get; set; }

        /// <summary>
        ///     Теоретическая частота
        /// </summary>
        public double TheoreticalFrequencies { get; set; }
    }
}