﻿using System.ComponentModel;

namespace ExperimentalDataProcessing.Lab1.Winform.UserControls
{
    partial class ContinuousUniformDistributionInputsPanel
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.valuesAmountInput = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.intervalStartInput = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.intervalEndInput = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.valuesAmountInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalStartInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalEndInput)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Количество точек";
            // 
            // valuesAmountInput
            // 
            this.valuesAmountInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.valuesAmountInput.Location = new System.Drawing.Point(0, 20);
            this.valuesAmountInput.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.valuesAmountInput.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            this.valuesAmountInput.Name = "valuesAmountInput";
            this.valuesAmountInput.Size = new System.Drawing.Size(169, 22);
            this.valuesAmountInput.TabIndex = 18;
            this.valuesAmountInput.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Начало интервала (a)";
            // 
            // intervalStartInput
            // 
            this.intervalStartInput.DecimalPlaces = 2;
            this.intervalStartInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.intervalStartInput.Location = new System.Drawing.Point(0, 62);
            this.intervalStartInput.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.intervalStartInput.Minimum = new decimal(new int[] { 1000, 0, 0, -2147483648 });
            this.intervalStartInput.Name = "intervalStartInput";
            this.intervalStartInput.Size = new System.Drawing.Size(169, 22);
            this.intervalStartInput.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Конец интервала (b)";
            // 
            // intervalEndInput
            // 
            this.intervalEndInput.DecimalPlaces = 2;
            this.intervalEndInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.intervalEndInput.Location = new System.Drawing.Point(0, 104);
            this.intervalEndInput.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.intervalEndInput.Minimum = new decimal(new int[] { 1000, 0, 0, -2147483648 });
            this.intervalEndInput.Name = "intervalEndInput";
            this.intervalEndInput.Size = new System.Drawing.Size(169, 22);
            this.intervalEndInput.TabIndex = 22;
            // 
            // ContinuousUniformDistributionInputsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.intervalEndInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.intervalStartInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.valuesAmountInput);
            this.Controls.Add(this.label3);
            this.Name = "ContinuousUniformDistributionInputsPanel";
            this.Size = new System.Drawing.Size(169, 126);
            ((System.ComponentModel.ISupportInitialize)(this.valuesAmountInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalStartInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalEndInput)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.NumericUpDown intervalStartInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown intervalEndInput;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.NumericUpDown valuesAmountInput;

        private System.Windows.Forms.Label label3;

        #endregion
    }
}