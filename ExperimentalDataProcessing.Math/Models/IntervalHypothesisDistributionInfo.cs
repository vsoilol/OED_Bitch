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
        public decimal IntervalStart { get; set; }

        /// <summary>
        ///     Конец интервала
        /// </summary>
        public decimal IntervalEnd { get; set; }

        /// <summary>
        ///     Количество значений в интервале
        /// </summary>
        public int ValuesCount { get; set; }

        /// <summary>
        ///     Вероятность попадания в интервал
        /// </summary>
        public decimal HitProbability { get; set; }

        /// <summary>
        ///     Теоретическая частота
        /// </summary>
        public decimal TheoreticalFrequencies { get; set; }
    }
}