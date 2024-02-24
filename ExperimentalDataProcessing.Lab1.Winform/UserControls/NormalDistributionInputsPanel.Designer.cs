﻿using System.ComponentModel;

namespace ExperimentalDataProcessing.Lab1.Winform.UserControls
{
    partial class NormalDistributionInputsPanel
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.stdDevInput = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.meanInput = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.valuesAmountInput = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stdDevInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meanInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valuesAmountInput)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.stdDevInput);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.meanInput);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.valuesAmountInput);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(323, 129);
            this.panel1.TabIndex = 0;
            // 
            // stdDevInput
            // 
            this.stdDevInput.DecimalPlaces = 2;
            this.stdDevInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.stdDevInput.Location = new System.Drawing.Point(0, 104);
            this.stdDevInput.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.stdDevInput.Minimum = new decimal(new int[] { 1000, 0, 0, -2147483648 });
            this.stdDevInput.Name = "stdDevInput";
            this.stdDevInput.Size = new System.Drawing.Size(323, 22);
            this.stdDevInput.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(323, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Cреднее квадратическое отклонение (sigma)";
            // 
            // meanInput
            // 
            this.meanInput.DecimalPlaces = 2;
            this.meanInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.meanInput.Location = new System.Drawing.Point(0, 62);
            this.meanInput.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.meanInput.Minimum = new decimal(new int[] { 1000, 0, 0, -2147483648 });
            this.meanInput.Name = "meanInput";
            this.meanInput.Size = new System.Drawing.Size(323, 22);
            this.meanInput.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(323, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Mатематическое ожидание (alfa)";
            // 
            // valuesAmountInput
            // 
            this.valuesAmountInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.valuesAmountInput.Location = new System.Drawing.Point(0, 20);
            this.valuesAmountInput.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.valuesAmountInput.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            this.valuesAmountInput.Name = "valuesAmountInput";
            this.valuesAmountInput.Size = new System.Drawing.Size(323, 22);
            this.valuesAmountInput.TabIndex = 16;
            this.valuesAmountInput.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(323, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Количество точек";
            // 
            // NormalDistributionInputsPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel1);
            this.Name = "NormalDistributionInputsPanel";
            this.Size = new System.Drawing.Size(323, 129);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stdDevInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meanInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valuesAmountInput)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.NumericUpDown stdDevInput;

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.NumericUpDown meanInput;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.NumericUpDown valuesAmountInput;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Panel panel1;

        #endregion
    }
}