using System.ComponentModel;

namespace ExperimentalDataProcessing.Lab1.Winform
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.valuesResultPanel = new System.Windows.Forms.Panel();
            this.valuesResultTable = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.theoreticalValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.experimental = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deviation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isCheckPassed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.valuesPanel = new System.Windows.Forms.Panel();
            this.calculateButton = new System.Windows.Forms.Button();
            this.inputsContainerPanel = new System.Windows.Forms.Panel();
            this.estimateAccuracyInput = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.valuesAmountInput = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.distributionComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.formsPlot = new ScottPlot.FormsPlot();
            this.valuesResultPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valuesResultTable)).BeginInit();
            this.valuesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estimateAccuracyInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valuesAmountInput)).BeginInit();
            this.SuspendLayout();
            // 
            // valuesResultPanel
            // 
            this.valuesResultPanel.Controls.Add(this.valuesResultTable);
            this.valuesResultPanel.Controls.Add(this.label1);
            this.valuesResultPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.valuesResultPanel.Location = new System.Drawing.Point(0, 409);
            this.valuesResultPanel.Name = "valuesResultPanel";
            this.valuesResultPanel.Size = new System.Drawing.Size(869, 225);
            this.valuesResultPanel.TabIndex = 1;
            // 
            // valuesResultTable
            // 
            this.valuesResultTable.AllowUserToAddRows = false;
            this.valuesResultTable.AllowUserToDeleteRows = false;
            this.valuesResultTable.AllowUserToResizeColumns = false;
            this.valuesResultTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.valuesResultTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.valuesResultTable.BackgroundColor = System.Drawing.Color.White;
            this.valuesResultTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.valuesResultTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.valuesResultTable.ColumnHeadersHeight = 40;
            this.valuesResultTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.valuesResultTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.name, this.theoreticalValue, this.experimental, this.deviation, this.isCheckPassed });
            this.valuesResultTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.valuesResultTable.Location = new System.Drawing.Point(0, 29);
            this.valuesResultTable.Name = "valuesResultTable";
            this.valuesResultTable.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.valuesResultTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.valuesResultTable.RowHeadersVisible = false;
            this.valuesResultTable.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.valuesResultTable.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.valuesResultTable.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.valuesResultTable.RowTemplate.Height = 24;
            this.valuesResultTable.Size = new System.Drawing.Size(869, 196);
            this.valuesResultTable.TabIndex = 1;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.HeaderText = "Наименования";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // theoreticalValue
            // 
            this.theoreticalValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.theoreticalValue.HeaderText = "Теоретическое";
            this.theoreticalValue.MinimumWidth = 6;
            this.theoreticalValue.Name = "theoreticalValue";
            this.theoreticalValue.ReadOnly = true;
            this.theoreticalValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.theoreticalValue.Width = 116;
            // 
            // experimental
            // 
            this.experimental.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.experimental.HeaderText = "Экспериментальное";
            this.experimental.MinimumWidth = 6;
            this.experimental.Name = "experimental";
            this.experimental.ReadOnly = true;
            this.experimental.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.experimental.Width = 148;
            // 
            // deviation
            // 
            this.deviation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.deviation.HeaderText = "Отклонение";
            this.deviation.MinimumWidth = 6;
            this.deviation.Name = "deviation";
            this.deviation.ReadOnly = true;
            this.deviation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.deviation.Width = 95;
            // 
            // isCheckPassed
            // 
            this.isCheckPassed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.isCheckPassed.HeaderText = "Пройдена ли проверка";
            this.isCheckPassed.MinimumWidth = 6;
            this.isCheckPassed.Name = "isCheckPassed";
            this.isCheckPassed.ReadOnly = true;
            this.isCheckPassed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.isCheckPassed.Width = 166;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(869, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Результаты";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // valuesPanel
            // 
            this.valuesPanel.Controls.Add(this.calculateButton);
            this.valuesPanel.Controls.Add(this.inputsContainerPanel);
            this.valuesPanel.Controls.Add(this.estimateAccuracyInput);
            this.valuesPanel.Controls.Add(this.label3);
            this.valuesPanel.Controls.Add(this.valuesAmountInput);
            this.valuesPanel.Controls.Add(this.label4);
            this.valuesPanel.Controls.Add(this.distributionComboBox);
            this.valuesPanel.Controls.Add(this.label2);
            this.valuesPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.valuesPanel.Location = new System.Drawing.Point(0, 0);
            this.valuesPanel.Name = "valuesPanel";
            this.valuesPanel.Padding = new System.Windows.Forms.Padding(8);
            this.valuesPanel.Size = new System.Drawing.Size(374, 409);
            this.valuesPanel.TabIndex = 2;
            // 
            // calculateButton
            // 
            this.calculateButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.calculateButton.Location = new System.Drawing.Point(8, 212);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(358, 41);
            this.calculateButton.TabIndex = 48;
            this.calculateButton.Text = "Рассчитать";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // inputsContainerPanel
            // 
            this.inputsContainerPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.inputsContainerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputsContainerPanel.Location = new System.Drawing.Point(8, 139);
            this.inputsContainerPanel.Name = "inputsContainerPanel";
            this.inputsContainerPanel.Size = new System.Drawing.Size(358, 73);
            this.inputsContainerPanel.TabIndex = 42;
            // 
            // estimateAccuracyInput
            // 
            this.estimateAccuracyInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.estimateAccuracyInput.DecimalPlaces = 3;
            this.estimateAccuracyInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.estimateAccuracyInput.Location = new System.Drawing.Point(8, 117);
            this.estimateAccuracyInput.Name = "estimateAccuracyInput";
            this.estimateAccuracyInput.Size = new System.Drawing.Size(358, 22);
            this.estimateAccuracyInput.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(8, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(358, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "Точность оценки";
            // 
            // valuesAmountInput
            // 
            this.valuesAmountInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.valuesAmountInput.Location = new System.Drawing.Point(8, 75);
            this.valuesAmountInput.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.valuesAmountInput.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            this.valuesAmountInput.Name = "valuesAmountInput";
            this.valuesAmountInput.Size = new System.Drawing.Size(358, 22);
            this.valuesAmountInput.TabIndex = 33;
            this.valuesAmountInput.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(8, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(358, 20);
            this.label4.TabIndex = 32;
            this.label4.Text = "Количество точек";
            // 
            // distributionComboBox
            // 
            this.distributionComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.distributionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.distributionComboBox.FormattingEnabled = true;
            this.distributionComboBox.Location = new System.Drawing.Point(8, 31);
            this.distributionComboBox.Name = "distributionComboBox";
            this.distributionComboBox.Size = new System.Drawing.Size(358, 24);
            this.distributionComboBox.TabIndex = 1;
            this.distributionComboBox.SelectedIndexChanged += new System.EventHandler(this.distributionComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(358, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Распределение";
            // 
            // formsPlot
            // 
            this.formsPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot.Location = new System.Drawing.Point(374, 0);
            this.formsPlot.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.formsPlot.Name = "formsPlot";
            this.formsPlot.Size = new System.Drawing.Size(495, 409);
            this.formsPlot.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 634);
            this.Controls.Add(this.formsPlot);
            this.Controls.Add(this.valuesPanel);
            this.Controls.Add(this.valuesResultPanel);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.valuesResultPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.valuesResultTable)).EndInit();
            this.valuesPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.estimateAccuracyInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valuesAmountInput)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button calculateButton;

        private System.Windows.Forms.Panel inputsContainerPanel;

        private System.Windows.Forms.NumericUpDown valuesAmountInput;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.NumericUpDown estimateAccuracyInput;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.ComboBox distributionComboBox;

        private System.Windows.Forms.Label label2;

        private ScottPlot.FormsPlot formsPlot;

        private System.Windows.Forms.Panel valuesPanel;

        private System.Windows.Forms.DataGridViewTextBoxColumn name;

        private System.Windows.Forms.DataGridViewTextBoxColumn theoreticalValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn experimental;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviation;
        private System.Windows.Forms.DataGridViewTextBoxColumn isCheckPassed;

        private System.Windows.Forms.DataGridView valuesResultTable;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Panel valuesResultPanel;

        #endregion
    }
}