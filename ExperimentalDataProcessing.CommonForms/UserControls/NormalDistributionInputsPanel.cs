using ExperimentalDataProcessing.Math.Distribution;

namespace ExperimentalDataProcessing.CommonForms.UserControls
{
    public partial class NormalDistributionInputsPanel : BaseInputsPanel
    {
        public NormalDistributionInputsPanel()
        {
            InitializeComponent();

            InitialHeight = panel1.Height;
        }

        public override int InitialHeight { get; }

        public override BaseDistribution GetDistribution()
        {
            var valuesAmount = (int)System.Math.Round(valuesAmountInput.Value);

            var stdDev = (double)stdDevInput.Value;
            var mean = (double)meanInput.Value;

            return new NormalDistribution(mean, stdDev, valuesAmount);
        }
    }
}