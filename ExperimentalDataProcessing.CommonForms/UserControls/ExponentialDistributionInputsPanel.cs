using ExperimentalDataProcessing.Math.Distribution;

namespace ExperimentalDataProcessing.CommonForms.UserControls
{
    public partial class ExponentialDistributionInputsPanel : BaseInputsPanel
    {
        public ExponentialDistributionInputsPanel()
        {
            InitializeComponent();

            InitialHeight = panel1.Height;
        }

        public override int InitialHeight { get; }

        public override BaseDistribution GetDistribution(double estimateAccuracy)
        {
            var valuesAmount = (int)System.Math.Round(valuesAmountInput.Value);
            var lambda = (double)lambdaInput.Value;

            return new ExponentialDistribution(valuesAmount, estimateAccuracy, lambda);
        }
    }
}