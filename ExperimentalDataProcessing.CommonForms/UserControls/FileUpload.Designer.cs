using System.ComponentModel;

namespace ExperimentalDataProcessing.CommonForms.UserControls
{
    partial class FileUpload
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
            this.uploadFileInput = new System.Windows.Forms.TextBox();
            this.uploadFileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uploadFileInput
            // 
            this.uploadFileInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.uploadFileInput.Location = new System.Drawing.Point(0, 0);
            this.uploadFileInput.Name = "uploadFileInput";
            this.uploadFileInput.Size = new System.Drawing.Size(205, 22);
            this.uploadFileInput.TabIndex = 0;
            // 
            // uploadFileButton
            // 
            this.uploadFileButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.uploadFileButton.Location = new System.Drawing.Point(0, 22);
            this.uploadFileButton.Name = "uploadFileButton";
            this.uploadFileButton.Size = new System.Drawing.Size(205, 31);
            this.uploadFileButton.TabIndex = 1;
            this.uploadFileButton.Text = "Загрузить файл";
            this.uploadFileButton.UseVisualStyleBackColor = true;
            this.uploadFileButton.Click += new System.EventHandler(this.uploadFileButton_Click);
            // 
            // FileUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.uploadFileButton);
            this.Controls.Add(this.uploadFileInput);
            this.Name = "FileUpload";
            this.Size = new System.Drawing.Size(205, 53);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button uploadFileButton;

        private System.Windows.Forms.TextBox uploadFileInput;

        #endregion
    }
}