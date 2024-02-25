using ExperimentalDataProcessing.Math.Distribution;

namespace ExperimentalDataProcessing.CommonForms.UserControls
{
    public partial class PoissonDistributionInputsPanel : BaseInputsPanel
    {
        public PoissonDistributionInputsPanel()
        {
            InitializeComponent();

            InitialHeight = Height;
        }

        public override int InitialHeight { get; }

        public override BaseDistribution GetDistribution()
        {
            var valuesAmount = (int)System.Math.Round(valuesAmountInput.Value);
            var lambda = (double)lambdaInput.Value;

            return new PoissonDistribution(valuesAmount, lambda);
        }
    }
}