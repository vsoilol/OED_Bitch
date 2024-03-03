using ExperimentalDataProcessing.Math.Distribution;

namespace ExperimentalDataProcessing.CommonForms.UserControls
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
            var stdDev = (double)stdDevInput.Value;
            var mean = (double)meanInput.Value;

            return new NormalDistribution(mean, stdDev);
        }
    }
}