using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ExperimentalDataProcessing.CommonForms.DistributionUserControls;
using ExperimentalDataProcessing.CommonForms.WindowForms;
using ExperimentalDataProcessing.CommonForms.Сonstants;
using ExperimentalDataProcessing.Math.Distribution;
using ScottPlot;
using ScottPlot.Statistics;

namespace ExperimentalDataProcessing.Lab1.Winform
{
    public partial class MainForm : Form
    {
        private BaseInputsPanel _currentInputsPanel;
        private BaseDistribution _distribution;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            distributionComboBox.Items.AddRange(DistributionComboBoxValues.Values);
            distributionComboBox.SelectedItem = DistributionComboBoxValues.Normal;

            AddAxisForPlot();
        }

        private void distributionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentInputsPanel = DistributionComboBoxValues.InputPanels[distributionComboBox.SelectedItem.ToString()];

            _currentInputsPanel.Dock = DockStyle.Fill;
            inputsContainerPanel.Controls.Clear();
            inputsContainerPanel.Controls.Add(_currentInputsPanel);
            _currentInputsPanel.BringToFront();

            inputsContainerPanel.Height = _currentInputsPanel.InitialHeight;
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            calculateButton.Enabled = false;

            valuesResultTable.Rows.Clear();
            formsPlot.Plot.Clear();
            AddAxisForPlot();

            var estimateAccuracy = (double)estimateAccuracyInput.Value;
            _distribution = _currentInputsPanel.GetDistribution();

            var valuesAmount = (int)System.Math.Round(valuesAmountInput.Value);

            Action<CancellationToken> generatePseudorandomValuesWorker = cancellationToken =>
                _distribution.GeneratePseudorandomValues(valuesAmount, estimateAccuracy, cancellationToken);

            using (var waitFormDialog = new WaitFormDialog(generatePseudorandomValuesWorker))
            {
                var dialogResult = waitFormDialog.ShowDialog(this);

                if (dialogResult == DialogResult.Cancel)
                {
                    calculateButton.Enabled = true;
                    return;
                }
            }

            DrawHistogram(_distribution.PseudorandomValues, _distribution.ValuesLeftBorderInt,
                _distribution.ValuesRightBorderInt);

            if (_distribution.IsDensityGraphingFromPoints)
                DrawFunctionByDots(_distribution.GetDensityFunction(), _distribution.ValuesLeftBorderInt,
                    _distribution.ValuesRightBorderInt);
            else
                DrawFunction(_distribution.GetDensityFunction());

            RefreshPlot();

            DisplayParametersEstimation(estimateAccuracy);

            calculateButton.Enabled = true;
        }

        private void DisplayParametersEstimation(double estimateAccuracy)
        {
            var parametersEstimation = _distribution
                .CalculateParametersEstimation(estimateAccuracy);

            foreach (var parameterEstimation in parametersEstimation)
            {
                var parameterExperimentalValue = System.Math.Round(parameterEstimation.ExperimentalValue, 2);
                var parameterTheoreticalValue = parameterEstimation.TheoreticalValue.HasValue
                    ? System.Math.Round(parameterEstimation.TheoreticalValue.Value, 2)
                        .ToString(CultureInfo.InvariantCulture)
                    : "-";
                var parameterDeviation = parameterEstimation.Deviation.HasValue
                    ? System.Math.Round(parameterEstimation.Deviation.Value, 2).ToString(CultureInfo.InvariantCulture)
                    : "-";

                var passwdCheckText = parameterEstimation.HasPassedCheck.HasValue
                    ? parameterEstimation.HasPassedCheck.Value ? "Да" : "Нет"
                    : "-";

                valuesResultTable.Rows.Add(parameterEstimation.Name, parameterTheoreticalValue,
                    parameterExperimentalValue, parameterDeviation,
                    passwdCheckText);
            }
        }

        private void DrawHistogram(IEnumerable<double> values, int min, int max)
        {
            var binCount = System.Math.Abs(max - min);
            var hist = new Histogram(min, max, binCount);

            hist.AddRange(values);
            var probabilities = hist.GetProbability();

            var bar = formsPlot.Plot.AddBar(probabilities, hist.Bins);
            bar.BarWidth = 1;
        }

        private void DrawFunction(Func<double, double?> function)
        {
            formsPlot.Plot.AddFunction(function, lineWidth: 4);
        }

        private void DrawFunctionByDots(Func<double, double?> function, int min, int max)
        {
            var xValues = new double[max - min + 1];
            var yValues = new double[max - min + 1];

            for (var x = min; x <= max; x++)
            {
                xValues[x - min] = x;
                yValues[x - min] = function(x) ?? 0;
            }

            var plt = formsPlot.Plot;
            var scatterPlot = plt.AddScatter(xValues, yValues, lineWidth: 4);
            scatterPlot.MarkerShape = MarkerShape.none;
        }

        private void RefreshPlot()
        {
            formsPlot.Plot.AxisAuto();
            formsPlot.Refresh();
        }

        private void AddAxisForPlot()
        {
            formsPlot.Plot.XLabel("m");
            formsPlot.Plot.YLabel("P");

            formsPlot.Plot.AddVerticalLine(0);
            formsPlot.Plot.AddHorizontalLine(0);

            formsPlot.Plot.AxisAuto();
            formsPlot.Refresh();
        }
    }
}