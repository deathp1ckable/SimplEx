using System;
using System.Timers;
using System.Windows.Forms;

namespace SimplExServer
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
            System.Timers.Timer timer = new System.Timers.Timer(1650);
            timer.Elapsed += TimerElapsed;
            timer.Start();
        }
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            ((System.Timers.Timer)sender).Dispose();          
            Invoke(new Action(() => {
                Hide(); }));
        }

        private void MainFormFormClosed(object sender, FormClosedEventArgs e) => Close();
    }
}
