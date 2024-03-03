using ExperimentalDataProcessing.Math.Distribution;

namespace ExperimentalDataProcessing.CommonForms.DistributionUserControls
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
            var lambda = (double)lambdaInput.Value;

            return new PoissonDistribution(lambda);
        }
    }
}