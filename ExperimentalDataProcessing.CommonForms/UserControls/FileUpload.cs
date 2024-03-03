using System;
using System.Windows.Forms;

namespace ExperimentalDataProcessing.CommonForms.UserControls
{
    public partial class FileUpload : UserControl
    {
        public FileUpload()
        {
            InitializeComponent();
        }

        public string FilePath => uploadFileInput.Text;

        private void uploadFileButton_Click(object sender, EventArgs e)
        {
            using (var fileDialog = new OpenFileDialog())
            {
                if (fileDialog.ShowDialog() == DialogResult.Cancel)
                    return;

                var filePath = fileDialog.FileName;
                uploadFileInput.Text = filePath;
            }
        }
    }
}