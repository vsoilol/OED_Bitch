using System.ComponentModel;

namespace ExperimentalDataProcessing.Lab1.Winform.UserControls
{
    partial class PoissonDistributionInputsPanel
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
            this.lambdaInput = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.valuesAmountInput = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lambdaInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valuesAmountInput)).BeginInit();
            this.SuspendLayout();
            // 
            // lambdaInput
            // 
            this.lambdaInput.DecimalPlaces = 2;
            this.lambdaInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.lambdaInput.Location = new System.Drawing.Point(0, 62);
            this.lambdaInput.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.lambdaInput.Minimum = new decimal(new int[] { 1000, 0, 0, -2147483648 });
            this.lambdaInput.Name = "lambdaInput";
            this.lambdaInput.Size = new System.Drawing.Size(357, 22);
            this.lambdaInput.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(357, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Среднее количество событий в интервале (лямбда)";
            // 
            // valuesAmountInput
            // 
            this.valuesAmountInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.valuesAmountInput.Location = new System.Drawing.Point(0, 20);
            this.valuesAmountInput.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.valuesAmountInput.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            this.valuesAmountInput.Name = "valuesAmountInput";
            this.valuesAmountInput.Size = new System.Drawing.Size(357, 22);
            this.valuesAmountInput.TabIndex = 21;
            this.valuesAmountInput.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(357, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Количество точек";
            // 
            // PoissonDistributionInputsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lambdaInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.valuesAmountInput);
            this.Controls.Add(this.label3);
            this.Name = "PoissonDistributionInputsPanel";
            this.Size = new System.Drawing.Size(357, 85);
            ((System.ComponentModel.ISupportInitialize)(this.lambdaInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valuesAmountInput)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.NumericUpDown lambdaInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown valuesAmountInput;
        private System.Windows.Forms.Label label3;

        #endregion
    }
}