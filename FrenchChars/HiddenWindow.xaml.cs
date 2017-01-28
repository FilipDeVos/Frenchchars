using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Shell;

namespace FrenchChars
{
    public partial class HiddenWindow : Window
    {
        private readonly BackgroundWorker _worker = new BackgroundWorker() { WorkerReportsProgress = true};
        private AutoResetEvent _resetEvent = new AutoResetEvent(false);
        public event ProgressChangedEventHandler ProgressChanged;

        public HiddenWindow()
        {
            InitializeComponent();
            _worker.DoWork += worker_DoWork;
            _worker.ProgressChanged += HandleProgressChanged;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(10);
                (sender as BackgroundWorker)?.ReportProgress(i); 
            }
            _resetEvent.Set(); 
        }

        private void HandleProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (ProgressChanged != null)
                ProgressChanged.Invoke(this, e);

            TaskbarItemInfo.ProgressValue = (double)e.ProgressPercentage / 100;
        }

        public void ShowProgress()
        {
            Show();
            _worker.RunWorkerAsync();
            _resetEvent.WaitOne();
            TaskbarItemInfo.ProgressState = TaskbarItemProgressState.None;
        }
    }
}
