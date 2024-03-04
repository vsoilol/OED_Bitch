namespace ExperimentalDataProcessing.Math.Models
{
    public class ParameterEstimation
    {
        public ParameterEstimation(string name, double experimentalValue)
        {
            Name = name;
            ExperimentalValue = experimentalValue;
        }

        public ParameterEstimation(string name, double experimentalValue, double theoreticalValue, double deviation,
            bool hasPassedCheck)
        {
            Name = name;
            ExperimentalValue = experimentalValue;
            TheoreticalValue = theoreticalValue;
            Deviation = deviation;
            HasPassedCheck = hasPassedCheck;
        }

        public string Name { get; set; }

        public double ExperimentalValue { get; set; }

        public double? TheoreticalValue { get; set; }

        public double? Deviation { get; set; }

        /// <summary>
        ///     Пройдена ли проверка
        /// </summary>
        public bool? HasPassedCheck { get; set; }
    }
}