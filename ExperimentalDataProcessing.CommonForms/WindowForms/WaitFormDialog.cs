using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExperimentalDataProcessing.CommonForms.WindowForms
{
    public partial class WaitFormDialog : Form
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public WaitFormDialog(Action<CancellationToken> worker)
        {
            InitializeComponent();

            Worker = worker;
        }

        public CancellationToken CancellationToken => _cancellationTokenSource.Token;

        public Action<CancellationToken> Worker { get; }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel();
        }

        private void WaitFormDialog_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => Worker(CancellationToken), CancellationToken)
                .ContinueWith(t =>
                {
                    DialogResult = t.IsCanceled || (t.IsFaulted && t.Exception != null)
                        ? DialogResult.Cancel
                        : DialogResult.OK;

                    Close();
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}