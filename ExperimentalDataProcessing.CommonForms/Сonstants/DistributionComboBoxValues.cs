using System.Collections.Generic;
using ExperimentalDataProcessing.CommonForms.UserControls;

namespace ExperimentalDataProcessing.CommonForms.Сonstants
{
    public static class DistributionComboBoxValues
    {
        public const string Normal = "Нормальное распределение";
        public const string Exponential = "Показательное распределение";
        public const string ContinuousUniform = "Равномерное распределение";
        public const string Poisson = "Распределение Пуассона";

        public static readonly object[] Values = { Normal, Exponential, ContinuousUniform, Poisson };

        public static readonly Dictionary<string, BaseInputsPanel> InputPanels =
            new Dictionary<string, BaseInputsPanel>
            {
                { Normal, UserControlManager.GetInstance<NormalDistributionInputsPanel>() },
                {
                    Exponential,
                    UserControlManager.GetInstance<ExponentialDistributionInputsPanel>()
                },
                {
                    ContinuousUniform,
                    UserControlManager.GetInstance<ContinuousUniformDistributionInputsPanel>()
                },
                {
                    Poisson,
                    UserControlManager.GetInstance<PoissonDistributionInputsPanel>()
                }
            };
    }
}