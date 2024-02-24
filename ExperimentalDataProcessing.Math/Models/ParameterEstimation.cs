namespace ExperimentalDataProcessing.Math.Models
{
    public class ParameterEstimation
    {
        public string Name { get; set; }

        public double ExperimentalValue { get; set; }
        
        public double TheoreticalValue { get; set; }
        
        public double Deviation { get; set; }
        
        /// <summary>
        /// Пройдена ли проверка
        /// </summary>
        public bool HasPassedCheck { get; set; }
    }
}