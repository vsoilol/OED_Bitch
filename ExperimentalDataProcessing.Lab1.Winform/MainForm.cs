﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ExperimentalDataProcessing.Lab1.Winform.UserControls;
using ExperimentalDataProcessing.Lab1.Winform.Сonstants;
using ExperimentalDataProcessing.Math.Distribution;
using ScottPlot;
using ScottPlot.Statistics;

namespace ExperimentalDataProcessing.Lab1.Winform
{
    public partial class MainForm : Form
    {
        private readonly Dictionary<string, BaseInputsPanel> _inputPanels = new Dictionary<string, BaseInputsPanel>
        {
            { DistributionComboBoxValues.Normal, UserControlManager.GetInstance<NormalDistributionInputsPanel>() },
            {
                DistributionComboBoxValues.Exponential,
                UserControlManager.GetInstance<ExponentialDistributionInputsPanel>()
            },
            {
                DistributionComboBoxValues.ContinuousUniform,
                UserControlManager.GetInstance<ContinuousUniformDistributionInputsPanel>()
            },
            {
                DistributionComboBoxValues.Poisson,
                UserControlManager.GetInstance<PoissonDistributionInputsPanel>()
            }
        };

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
            _currentInputsPanel = _inputPanels[distributionComboBox.SelectedItem.ToString()];

            _currentInputsPanel.Dock = DockStyle.Fill;
            inputsContainerPanel.Controls.Clear();
            inputsContainerPanel.Controls.Add(_currentInputsPanel);
            _currentInputsPanel.BringToFront();

            inputsContainerPanel.Height = _currentInputsPanel.InitialHeight;
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            formsPlot.Plot.Clear();
            AddAxisForPlot();

            _distribution = _currentInputsPanel.GetDistribution();

            _distribution.GeneratePseudorandomValues();

            DrawHistogram(_distribution.PseudorandomValues, _distribution.MinIntValue, _distribution.MaxIntValue);

            if (_distribution.IsDensityGraphingFromPoints)
            {
                DrawFunctionByDots(_distribution.GetDensityFunction(), _distribution.MinIntValue,
                    _distribution.MaxIntValue);
            }
            else
            {
                DrawFunction(_distribution.GetDensityFunction());
            }

            RefreshPlot();

            DisplayParametersEstimation();
        }

        private void DisplayParametersEstimation()
        {
            valuesResultTable.Rows.Clear();

            var estimateAccuracy = (double)estimateAccuracyInput.Value;
            var parametersEstimation = _distribution.CalculateParametersEstimation(estimateAccuracy);

            foreach (var parameterEstimation in parametersEstimation)
            {
                var parameterExperimentalValue = System.Math.Round(parameterEstimation.ExperimentalValue, 2);
                var parameterTheoreticalValue = System.Math.Round(parameterEstimation.TheoreticalValue, 2);
                var parameterDeviation = System.Math.Round(parameterEstimation.Deviation, 2);

                var passwdCheckText = parameterEstimation.HasPassedCheck ? "Да" : "Нет";

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