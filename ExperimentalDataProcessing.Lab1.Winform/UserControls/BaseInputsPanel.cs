using System.ComponentModel;
using System.Windows.Forms;
using ExperimentalDataProcessing.Math.Distribution;

namespace ExperimentalDataProcessing.Lab1.Winform.UserControls
{
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<BaseInputsPanel, UserControl>))]
    public abstract class BaseInputsPanel : UserControl
    {
        public abstract int InitialHeight { get; }

        public abstract BaseDistribution GetDistribution();
    }
}