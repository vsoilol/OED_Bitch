using System.ComponentModel;
using System.Windows.Forms;
using ExperimentalDataProcessing.Math.Distribution;

namespace ExperimentalDataProcessing.CommonForms.UserControls
{
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<BaseInputsPanel, UserControl>))]
    public abstract class BaseInputsPanel : UserControl
    {
        public abstract int InitialHeight { get; }

        public abstract BaseDistribution GetDistribution(double estimateAccuracy);
    }
}