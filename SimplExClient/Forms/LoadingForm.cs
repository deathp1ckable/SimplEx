using SimplExClient.View;
using System;
using System.Timers;
using System.Windows.Forms;
namespace SimplExClient
{
    public partial class LoadingForm : Form, ILoadingView
    {
        private ApplicationContext context;
        public event ViewActionHandler<ILoadingView> Loaded;
        public LoadingForm(ApplicationContext context)
        {
            InitializeComponent();
            System.Timers.Timer timer = new System.Timers.Timer(2000);
            timer.Elapsed += TimerElapsed;
            timer.Start();
            this.context = context;
        }
        public new void Show()
        {
            context.MainForm = this;
            base.Show();
        }
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            ((System.Timers.Timer)sender).Dispose();
            Action action = () =>
            {
                Hide();
                Loaded?.Invoke(this);
            };
            Invoke(action);
        }
        private void MainFormFormClosed(object sender, FormClosedEventArgs e) => Close();
    }
    public delegate void Action();
}
