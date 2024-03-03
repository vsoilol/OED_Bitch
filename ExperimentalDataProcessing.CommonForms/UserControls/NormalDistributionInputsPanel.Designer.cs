using System.ComponentModel;

namespace ExperimentalDataProcessing.CommonForms.UserControls
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
            this.stdDevInput = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.meanInput = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.stdDevInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meanInput)).BeginInit();
            this.SuspendLayout();
            // 
            // stdDevInput
            // 
            this.stdDevInput.DecimalPlaces = 2;
            this.stdDevInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.stdDevInput.Location = new System.Drawing.Point(0, 62);
            this.stdDevInput.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.stdDevInput.Minimum = new decimal(new int[] { 1000, 0, 0, -2147483648 });
            this.stdDevInput.Name = "stdDevInput";
            this.stdDevInput.Size = new System.Drawing.Size(259, 22);
            this.stdDevInput.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(259, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Cреднее квадратическое отклонение (sigma)";
            // 
            // meanInput
            // 
            this.meanInput.DecimalPlaces = 2;
            this.meanInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.meanInput.Location = new System.Drawing.Point(0, 20);
            this.meanInput.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.meanInput.Minimum = new decimal(new int[] { 1000, 0, 0, -2147483648 });
            this.meanInput.Name = "meanInput";
            this.meanInput.Size = new System.Drawing.Size(259, 22);
            this.meanInput.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Mатематическое ожидание (alfa)";
            // 
            // NormalDistributionInputsPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.Controls.Add(this.stdDevInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.meanInput);
            this.Controls.Add(this.label2);
            this.Name = "NormalDistributionInputsPanel";
            this.Size = new System.Drawing.Size(259, 84);
            ((System.ComponentModel.ISupportInitialize)(this.stdDevInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meanInput)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.NumericUpDown stdDevInput;

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.NumericUpDown meanInput;

        private System.Windows.Forms.Label label2;

        #endregion
    }
}