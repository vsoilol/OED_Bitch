using ExperimentalDataProcessing.Math.Distribution;

namespace ExperimentalDataProcessing.Lab1.Winform.UserControls
{
    public partial class ExponentialDistributionInputsPanel : BaseInputsPanel
    {
        public override int InitialHeight { get; }

        public ExponentialDistributionInputsPanel()
        {
            InitializeComponent();
            
            InitialHeight = panel1.Height;
        }
        
        public override BaseDistribution GetDistribution()
        {
            var valuesAmount = (int)System.Math.Round(valuesAmountInput.Value);
            var lambda = (double)lambdaInput.Value;

            return new ExponentialDistribution(valuesAmount, lambda);
        }
    }
}