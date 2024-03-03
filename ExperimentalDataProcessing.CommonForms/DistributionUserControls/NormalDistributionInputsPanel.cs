using ExperimentalDataProcessing.Math.Distribution;

namespace ExperimentalDataProcessing.CommonForms.DistributionUserControls
{
    public partial class NormalDistributionInputsPanel : BaseInputsPanel
    {
        public NormalDistributionInputsPanel()
        {
            InitializeComponent();

            InitialHeight = Height;
        }

        public override int InitialHeight { get; }

        public override BaseDistribution GetDistribution()
        {
            var stdDev = stdDevInput.Value;
            var mean = meanInput.Value;

            return new NormalDistribution(mean, stdDev);
        }
    }
}