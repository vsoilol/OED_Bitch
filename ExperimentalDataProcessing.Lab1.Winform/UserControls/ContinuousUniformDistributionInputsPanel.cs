using ExperimentalDataProcessing.Math.Distribution;

namespace ExperimentalDataProcessing.Lab1.Winform.UserControls
{
    public partial class ContinuousUniformDistributionInputsPanel : BaseInputsPanel
    {
        public override int InitialHeight { get; }
        
        public ContinuousUniformDistributionInputsPanel()
        {
            InitializeComponent();

            InitialHeight = this.Height;
        }

        public override BaseDistribution GetDistribution()
        {
            var valuesAmount = (int)System.Math.Round(valuesAmountInput.Value);
          
            var intervalStart = (double)intervalStartInput.Value;
            var intervalEnd = (double)intervalEndInput.Value;

            return new ContinuousUniformDistribution(valuesAmount, intervalStart, intervalEnd);
        }
    }
}