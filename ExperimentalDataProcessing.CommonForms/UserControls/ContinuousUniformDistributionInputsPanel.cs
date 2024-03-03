using ExperimentalDataProcessing.Math.Distribution;

namespace ExperimentalDataProcessing.CommonForms.UserControls
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
            var intervalStart = (double)intervalStartInput.Value;
            var intervalEnd = (double)intervalEndInput.Value;

            return new ContinuousUniformDistribution(intervalStart, intervalEnd);
        }
    }
}