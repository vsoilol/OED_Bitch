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

        public override BaseDistribution GetDistribution(double estimateAccuracy)
        {
            var valuesAmount = (int)System.Math.Round(valuesAmountInput.Value);

            var stdDev = (double)stdDevInput.Value;
            var mean = (double)meanInput.Value;

            return new NormalDistribution(valuesAmount, estimateAccuracy, mean, stdDev);
        }
    }
}