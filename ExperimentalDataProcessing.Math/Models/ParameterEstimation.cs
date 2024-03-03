namespace ExperimentalDataProcessing.Math.Models
{
    public class ParameterEstimation
    {
        public string Name { get; set; }

        public decimal ExperimentalValue { get; set; }

        public decimal TheoreticalValue { get; set; }

        public decimal Deviation { get; set; }

        /// <summary>
        ///     Пройдена ли проверка
        /// </summary>
        public bool HasPassedCheck { get; set; }
    }
}