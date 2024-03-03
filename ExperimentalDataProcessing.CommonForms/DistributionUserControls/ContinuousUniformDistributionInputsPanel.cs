using ExperimentalDataProcessing.Math.Distribution;

namespace ExperimentalDataProcessing.CommonForms.DistributionUserControls
{
    public partial class ContinuousUniformDistributionInputsPanel : BaseInputsPanel
    {
        public ContinuousUniformDistributionInputsPanel()
        {
            InitializeComponent();

            InitialHeight = Height;
        }

        public override int InitialHeight { get; }

        public override BaseDistribution GetDistribution()
        {
            var intervalStart = intervalStartInput.Value;
            var intervalEnd = intervalEndInput.Value;

            return new ContinuousUniformDistribution(intervalStart, intervalEnd);
        }
    }
}