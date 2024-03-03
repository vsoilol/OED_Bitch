using ExperimentalDataProcessing.Math.Distribution;

namespace ExperimentalDataProcessing.CommonForms.DistributionUserControls
{
    public partial class ExponentialDistributionInputsPanel : BaseInputsPanel
    {
        public ExponentialDistributionInputsPanel()
        {
            InitializeComponent();

            InitialHeight = Height;
        }

        public override int InitialHeight { get; }

        public override BaseDistribution GetDistribution()
        {
            var lambda = lambdaInput.Value;

            return new ExponentialDistribution(lambda);
        }
    }
}