using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ExperimentalDataProcessing.CommonForms.DistributionUserControls;
using ExperimentalDataProcessing.CommonForms.WindowForms;
using ExperimentalDataProcessing.CommonForms.Сonstants;
using ExperimentalDataProcessing.Math.Distribution;
using ScottPlot;
using ScottPlot.Statistics;

namespace ExperimentalDataProcessing.Lab2.Winform
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


        private void IsValuesFromFileCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            valuesAmountPanel.Visible = !IsValuesFromFileCheckBox.Checked;
            fileUploadPanel.Visible = IsValuesFromFileCheckBox.Checked;
        }

        private void intervalsAutomaticallyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            intervalsAmountInput.Enabled = !intervalsAutomaticallyCheckBox.Checked;
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
            dataGridView.Rows.Clear();
            formsPlot.Plot.Clear();
            AddAxisForPlot();

            var estimateAccuracy = (double)estimateAccuracyInput.Value;
            _distribution = _currentInputsPanel.GetDistribution();

            var valuesAmount = IsValuesFromFileCheckBox.Checked
                ? null
                : (int?)System.Math.Round(valuesAmountInput.Value);

            var isSetPseudorandomValuesSuccess = TrySetPseudorandomValues(estimateAccuracy, valuesAmount);

            if (!isSetPseudorandomValuesSuccess) return;

            DrawHistogram(_distribution.PseudorandomValues, _distribution.ValuesLeftBorderInt,
                _distribution.ValuesRightBorderInt);

            if (_distribution.IsDensityGraphingFromPoints)
                DrawFunctionByDots(_distribution.GetDensityFunction(), _distribution.ValuesLeftBorderInt,
                    _distribution.ValuesRightBorderInt);
            else
                DrawFunction(_distribution.GetDensityFunction());

            RefreshPlot();

            DisplayParametersEstimation(estimateAccuracy);

            try
            {
                DisplayHypothesisDistributionIntervals();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Для данного распределения не реализована проверка");
            }

            calculateButton.Enabled = true;
        }

        private bool TrySetPseudorandomValues(double estimateAccuracy, int? valuesAmount = null)
        {
            if (IsValuesFromFileCheckBox.Checked || !valuesAmount.HasValue)
            {
                var pseudorandomValues = GetValuesFromFile();

                if (pseudorandomValues is null) return false;

                _distribution.PseudorandomValues = pseudorandomValues;
                return true;
            }

            Action<CancellationToken> generatePseudorandomValuesWorker = cancellationToken =>
                _distribution.GeneratePseudorandomValues(valuesAmount.Value, estimateAccuracy, cancellationToken);

            using (var waitFormDialog = new WaitFormDialog(generatePseudorandomValuesWorker))
            {
                var dialogResult = waitFormDialog.ShowDialog(this);

                if (dialogResult == DialogResult.Cancel)
                {
                    calculateButton.Enabled = true;
                    return false;
                }
            }

            return true;
        }

        private void DisplayHypothesisDistributionIntervals()
        {
            var significanceLevel = (double)significanceLevelInput.Value;
            var intervalsAmount = intervalsAutomaticallyCheckBox.Checked
                ? null
                : (int?)System.Math.Ceiling(intervalsAmountInput.Value);

            var verifyHypothesisDistributionResult = _distribution
                .VerifyHypothesisDistribution(significanceLevel, intervalsAmount);

            foreach (var interval in verifyHypothesisDistributionResult.Intervals)
                dataGridView.Rows.Add(interval.IntervalNumber,
                    System.Math.Round(interval.IntervalStart, 3),
                    System.Math.Round(interval.IntervalEnd, 3),
                    interval.ValuesCount,
                    System.Math.Round(interval.HitProbability, 3),
                    System.Math.Round(interval.TheoreticalFrequencies, 3));

            valuesResultTable.Rows.Add("Число степеней свободы", "-",
                verifyHypothesisDistributionResult.DegreesOfFreedom, "-", "-");

            valuesResultTable.Rows.Add("Количество интервалов", "-",
                verifyHypothesisDistributionResult.IntervalsAmount, "-", "-");

            valuesResultTable.Rows.Add("Критерий согласия", "-",
                System.Math.Round(verifyHypothesisDistributionResult.CriterionOfConsent, 3), "-", "-");

            valuesResultTable.Rows.Add("Критическое значение", "-",
                System.Math.Round(verifyHypothesisDistributionResult.CriticalChiSquareValue, 3), "-", "-");

            valuesResultTable.Rows.Add("Опровергается ли гипотеза", "-",
                verifyHypothesisDistributionResult.IsHypothesisRefuted ? "Да" : "Нет", "-", "-");
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

        private IEnumerable<double> GetValuesFromFile()
        {
            var filePath = fileUploadPanel.FilePath;

            var values = new List<double>();

            try
            {
                // Check if the file exists
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Файла не существует");
                    return null;
                }

                // Read all lines from the file
                var lines = File.ReadAllLines(filePath);

                // Iterate through each line and convert it to double
                foreach (var line in lines)
                {
                    // Check for empty lines and skip them
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    // Try to parse the line as a double
                    if (double.TryParse(line, out var value))
                    {
                        // Add the parsed value to the list
                        values.Add(value);
                    }
                    else
                    {
                        // Show a message box if a line cannot be parsed as double
                        MessageBox.Show($"Невозможно преобразовать значение: {line}");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                // Show a message box if an exception occurs
                MessageBox.Show($"Ошибка чтения из файла: {ex.Message}");
                return null;
            }

            return values;
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