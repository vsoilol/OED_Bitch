using ExperimentalDataProcessing.Math.Distribution;

namespace ExperimentalDataProcessing.Lab1.Winform.UserControls
{
    public partial class PoissonDistributionInputsPanel : BaseInputsPanel
    {
        public override int InitialHeight { get; }

        public PoissonDistributionInputsPanel()
        {
            InitializeComponent();

            InitialHeight = this.Height;
        }

        public override BaseDistribution GetDistribution()
        {
            var valuesAmount = (int)System.Math.Round(valuesAmountInput.Value);
            var lambda = (double)lambdaInput.Value;

            return new PoissonDistribution(valuesAmount, lambda);
        }
    }
}