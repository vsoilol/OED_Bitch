namespace ExperimentalDataProcessing.Lab2.Winform
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.resultsPanel = new System.Windows.Forms.Panel();
            this.valuesResultTable = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.theoreticalValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.experimental = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deviation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isCheckPassed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.IntervalNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntervalStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntervalEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Probability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TheoreticalFrequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainInputsContainerPanel = new System.Windows.Forms.Panel();
            this.calculateButton = new System.Windows.Forms.Button();
            this.intervalsAutomaticallyCheckBox = new System.Windows.Forms.CheckBox();
            this.intervalsAmountInput = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.significanceLevelInput = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.inputsContainerPanel = new System.Windows.Forms.Panel();
            this.estimateAccuracyInput = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.valuesAmountPanel = new System.Windows.Forms.Panel();
            this.valuesAmountInput = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.IsValuesFromFileCheckBox = new System.Windows.Forms.CheckBox();
            this.distributionComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.formsPlot = new ScottPlot.FormsPlot();
            this.fileUploadPanel = new ExperimentalDataProcessing.CommonForms.UserControls.FileUpload();
            this.resultsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valuesResultTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.mainInputsContainerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalsAmountInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.significanceLevelInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estimateAccuracyInput)).BeginInit();
            this.valuesAmountPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valuesAmountInput)).BeginInit();
            this.SuspendLayout();
            // 
            // resultsPanel
            // 
            this.resultsPanel.Controls.Add(this.valuesResultTable);
            this.resultsPanel.Controls.Add(this.dataGridView);
            this.resultsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.resultsPanel.Location = new System.Drawing.Point(0, 407);
            this.resultsPanel.Name = "resultsPanel";
            this.resultsPanel.Size = new System.Drawing.Size(1402, 351);
            this.resultsPanel.TabIndex = 0;
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
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.valuesResultTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.valuesResultTable.ColumnHeadersHeight = 50;
            this.valuesResultTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.valuesResultTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.theoreticalValue,
            this.experimental,
            this.deviation,
            this.isCheckPassed});
            this.valuesResultTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.valuesResultTable.Location = new System.Drawing.Point(768, 0);
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
            this.valuesResultTable.Size = new System.Drawing.Size(634, 351);
            this.valuesResultTable.TabIndex = 5;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.HeaderText = "Наименования";
            this.name.MinimumWidth = 120;
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
            this.theoreticalValue.Width = 115;
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
            this.deviation.Width = 93;
            // 
            // isCheckPassed
            // 
            this.isCheckPassed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.isCheckPassed.HeaderText = "Пройдена ли проверка";
            this.isCheckPassed.MinimumWidth = 6;
            this.isCheckPassed.Name = "isCheckPassed";
            this.isCheckPassed.ReadOnly = true;
            this.isCheckPassed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.isCheckPassed.Width = 148;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView.ColumnHeadersHeight = 50;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IntervalNumber,
            this.IntervalStart,
            this.IntervalEnd,
            this.Amount,
            this.Probability,
            this.TheoreticalFrequency});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView.Size = new System.Drawing.Size(768, 351);
            this.dataGridView.TabIndex = 4;
            // 
            // IntervalNumber
            // 
            this.IntervalNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IntervalNumber.DefaultCellStyle = dataGridViewCellStyle6;
            this.IntervalNumber.HeaderText = "Номер интервала";
            this.IntervalNumber.MinimumWidth = 6;
            this.IntervalNumber.Name = "IntervalNumber";
            this.IntervalNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IntervalNumber.Width = 117;
            // 
            // IntervalStart
            // 
            this.IntervalStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IntervalStart.DefaultCellStyle = dataGridViewCellStyle7;
            this.IntervalStart.HeaderText = "Начало интервала";
            this.IntervalStart.MinimumWidth = 6;
            this.IntervalStart.Name = "IntervalStart";
            this.IntervalStart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IntervalStart.Width = 123;
            // 
            // IntervalEnd
            // 
            this.IntervalEnd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IntervalEnd.DefaultCellStyle = dataGridViewCellStyle8;
            this.IntervalEnd.HeaderText = "Конец интервала";
            this.IntervalEnd.MinimumWidth = 6;
            this.IntervalEnd.Name = "IntervalEnd";
            this.IntervalEnd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IntervalEnd.Width = 114;
            // 
            // Amount
            // 
            this.Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle9;
            this.Amount.HeaderText = "Количество";
            this.Amount.MinimumWidth = 100;
            this.Amount.Name = "Amount";
            this.Amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Probability
            // 
            this.Probability.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Probability.DefaultCellStyle = dataGridViewCellStyle10;
            this.Probability.HeaderText = "Вероятность попадания";
            this.Probability.MinimumWidth = 6;
            this.Probability.Name = "Probability";
            this.Probability.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Probability.Width = 154;
            // 
            // TheoreticalFrequency
            // 
            this.TheoreticalFrequency.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TheoreticalFrequency.DefaultCellStyle = dataGridViewCellStyle11;
            this.TheoreticalFrequency.HeaderText = "Теоретическая частота";
            this.TheoreticalFrequency.MinimumWidth = 6;
            this.TheoreticalFrequency.Name = "TheoreticalFrequency";
            this.TheoreticalFrequency.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TheoreticalFrequency.Width = 153;
            // 
            // mainInputsContainerPanel
            // 
            this.mainInputsContainerPanel.Controls.Add(this.calculateButton);
            this.mainInputsContainerPanel.Controls.Add(this.intervalsAutomaticallyCheckBox);
            this.mainInputsContainerPanel.Controls.Add(this.intervalsAmountInput);
            this.mainInputsContainerPanel.Controls.Add(this.label4);
            this.mainInputsContainerPanel.Controls.Add(this.significanceLevelInput);
            this.mainInputsContainerPanel.Controls.Add(this.label1);
            this.mainInputsContainerPanel.Controls.Add(this.inputsContainerPanel);
            this.mainInputsContainerPanel.Controls.Add(this.estimateAccuracyInput);
            this.mainInputsContainerPanel.Controls.Add(this.label3);
            this.mainInputsContainerPanel.Controls.Add(this.valuesAmountPanel);
            this.mainInputsContainerPanel.Controls.Add(this.fileUploadPanel);
            this.mainInputsContainerPanel.Controls.Add(this.IsValuesFromFileCheckBox);
            this.mainInputsContainerPanel.Controls.Add(this.distributionComboBox);
            this.mainInputsContainerPanel.Controls.Add(this.label2);
            this.mainInputsContainerPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.mainInputsContainerPanel.Location = new System.Drawing.Point(0, 0);
            this.mainInputsContainerPanel.Name = "mainInputsContainerPanel";
            this.mainInputsContainerPanel.Padding = new System.Windows.Forms.Padding(5);
            this.mainInputsContainerPanel.Size = new System.Drawing.Size(385, 407);
            this.mainInputsContainerPanel.TabIndex = 1;
            // 
            // calculateButton
            // 
            this.calculateButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.calculateButton.Location = new System.Drawing.Point(5, 343);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(375, 41);
            this.calculateButton.TabIndex = 91;
            this.calculateButton.Text = "Рассчитать";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // intervalsAutomaticallyCheckBox
            // 
            this.intervalsAutomaticallyCheckBox.AutoSize = true;
            this.intervalsAutomaticallyCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.intervalsAutomaticallyCheckBox.Location = new System.Drawing.Point(5, 323);
            this.intervalsAutomaticallyCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.intervalsAutomaticallyCheckBox.Name = "intervalsAutomaticallyCheckBox";
            this.intervalsAutomaticallyCheckBox.Size = new System.Drawing.Size(375, 20);
            this.intervalsAutomaticallyCheckBox.TabIndex = 90;
            this.intervalsAutomaticallyCheckBox.Text = "Расчитать интервал автоматически";
            this.intervalsAutomaticallyCheckBox.UseVisualStyleBackColor = true;
            this.intervalsAutomaticallyCheckBox.CheckedChanged += new System.EventHandler(this.intervalsAutomaticallyCheckBox_CheckedChanged);
            // 
            // intervalsAmountInput
            // 
            this.intervalsAmountInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.intervalsAmountInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.intervalsAmountInput.Location = new System.Drawing.Point(5, 301);
            this.intervalsAmountInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.intervalsAmountInput.Name = "intervalsAmountInput";
            this.intervalsAmountInput.Size = new System.Drawing.Size(375, 22);
            this.intervalsAmountInput.TabIndex = 89;
            this.intervalsAmountInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(5, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(375, 20);
            this.label4.TabIndex = 88;
            this.label4.Text = "Количество интервалов";
            // 
            // significanceLevelInput
            // 
            this.significanceLevelInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.significanceLevelInput.DecimalPlaces = 3;
            this.significanceLevelInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.significanceLevelInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.significanceLevelInput.Location = new System.Drawing.Point(5, 259);
            this.significanceLevelInput.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.significanceLevelInput.Name = "significanceLevelInput";
            this.significanceLevelInput.Size = new System.Drawing.Size(375, 22);
            this.significanceLevelInput.TabIndex = 87;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(5, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(375, 20);
            this.label1.TabIndex = 86;
            this.label1.Text = "Уровень значимости";
            // 
            // inputsContainerPanel
            // 
            this.inputsContainerPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.inputsContainerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputsContainerPanel.Location = new System.Drawing.Point(5, 209);
            this.inputsContainerPanel.Name = "inputsContainerPanel";
            this.inputsContainerPanel.Size = new System.Drawing.Size(375, 30);
            this.inputsContainerPanel.TabIndex = 85;
            // 
            // estimateAccuracyInput
            // 
            this.estimateAccuracyInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.estimateAccuracyInput.DecimalPlaces = 3;
            this.estimateAccuracyInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.estimateAccuracyInput.Location = new System.Drawing.Point(5, 187);
            this.estimateAccuracyInput.Name = "estimateAccuracyInput";
            this.estimateAccuracyInput.Size = new System.Drawing.Size(375, 22);
            this.estimateAccuracyInput.TabIndex = 84;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(5, 167);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(375, 20);
            this.label3.TabIndex = 83;
            this.label3.Text = "Точность оценки";
            // 
            // valuesAmountPanel
            // 
            this.valuesAmountPanel.AutoSize = true;
            this.valuesAmountPanel.Controls.Add(this.valuesAmountInput);
            this.valuesAmountPanel.Controls.Add(this.label6);
            this.valuesAmountPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.valuesAmountPanel.Location = new System.Drawing.Point(5, 125);
            this.valuesAmountPanel.Name = "valuesAmountPanel";
            this.valuesAmountPanel.Size = new System.Drawing.Size(375, 42);
            this.valuesAmountPanel.TabIndex = 82;
            // 
            // valuesAmountInput
            // 
            this.valuesAmountInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.valuesAmountInput.Location = new System.Drawing.Point(0, 20);
            this.valuesAmountInput.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.valuesAmountInput.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.valuesAmountInput.Name = "valuesAmountInput";
            this.valuesAmountInput.Size = new System.Drawing.Size(375, 22);
            this.valuesAmountInput.TabIndex = 62;
            this.valuesAmountInput.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(375, 20);
            this.label6.TabIndex = 61;
            this.label6.Text = "Количество точек";
            // 
            // IsValuesFromFileCheckBox
            // 
            this.IsValuesFromFileCheckBox.AutoSize = true;
            this.IsValuesFromFileCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.IsValuesFromFileCheckBox.Location = new System.Drawing.Point(5, 52);
            this.IsValuesFromFileCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.IsValuesFromFileCheckBox.Name = "IsValuesFromFileCheckBox";
            this.IsValuesFromFileCheckBox.Size = new System.Drawing.Size(375, 20);
            this.IsValuesFromFileCheckBox.TabIndex = 59;
            this.IsValuesFromFileCheckBox.Text = "Получить данные с файла";
            this.IsValuesFromFileCheckBox.UseVisualStyleBackColor = true;
            this.IsValuesFromFileCheckBox.CheckedChanged += new System.EventHandler(this.IsValuesFromFileCheckBox_CheckedChanged);
            // 
            // distributionComboBox
            // 
            this.distributionComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.distributionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.distributionComboBox.FormattingEnabled = true;
            this.distributionComboBox.Location = new System.Drawing.Point(5, 28);
            this.distributionComboBox.Name = "distributionComboBox";
            this.distributionComboBox.Size = new System.Drawing.Size(375, 24);
            this.distributionComboBox.TabIndex = 33;
            this.distributionComboBox.SelectedIndexChanged += new System.EventHandler(this.distributionComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(5, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(375, 23);
            this.label2.TabIndex = 32;
            this.label2.Text = "Распределение";
            // 
            // formsPlot
            // 
            this.formsPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot.Location = new System.Drawing.Point(385, 0);
            this.formsPlot.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.formsPlot.Name = "formsPlot";
            this.formsPlot.Size = new System.Drawing.Size(1017, 407);
            this.formsPlot.TabIndex = 2;
            // 
            // fileUploadPanel
            // 
            this.fileUploadPanel.AutoSize = true;
            this.fileUploadPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.fileUploadPanel.Location = new System.Drawing.Point(5, 72);
            this.fileUploadPanel.Name = "fileUploadPanel";
            this.fileUploadPanel.Size = new System.Drawing.Size(375, 53);
            this.fileUploadPanel.TabIndex = 81;
            this.fileUploadPanel.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1402, 758);
            this.Controls.Add(this.formsPlot);
            this.Controls.Add(this.mainInputsContainerPanel);
            this.Controls.Add(this.resultsPanel);
            this.MinimumSize = new System.Drawing.Size(1420, 800);
            this.Name = "MainForm";
            this.Text = "Проверка гипотез о виде закона распределения";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.resultsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.valuesResultTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.mainInputsContainerPanel.ResumeLayout(false);
            this.mainInputsContainerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalsAmountInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.significanceLevelInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estimateAccuracyInput)).EndInit();
            this.valuesAmountPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.valuesAmountInput)).EndInit();
            this.ResumeLayout(false);

        }

        private ExperimentalDataProcessing.CommonForms.UserControls.FileUpload fileUploadPanel;

        private System.Windows.Forms.Panel valuesAmountPanel;
        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.CheckBox IsValuesFromFileCheckBox;

        private System.Windows.Forms.NumericUpDown valuesAmountInput;

        private System.Windows.Forms.Button calculateButton;

        private System.Windows.Forms.Panel inputsContainerPanel;

        private System.Windows.Forms.NumericUpDown significanceLevelInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown intervalsAmountInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox intervalsAutomaticallyCheckBox;

        private System.Windows.Forms.NumericUpDown estimateAccuracyInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox distributionComboBox;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntervalNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntervalStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntervalEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Probability;
        private System.Windows.Forms.DataGridViewTextBoxColumn TheoreticalFrequency;

        private System.Windows.Forms.DataGridView valuesResultTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn theoreticalValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn experimental;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviation;
        private System.Windows.Forms.DataGridViewTextBoxColumn isCheckPassed;

        private ScottPlot.FormsPlot formsPlot;

        private System.Windows.Forms.Panel mainInputsContainerPanel;

        private System.Windows.Forms.Panel resultsPanel;

        #endregion
    }
}