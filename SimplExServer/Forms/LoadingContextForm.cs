using SimplExServer.View;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SimplExServer.Forms
{
    public partial class LoadingContextForm : Form, ILoadingContextView
    {
        private bool isHiden;
        public LoadingContextForm()
        {
            InitializeComponent();
        }
        public new void Show()
        {
            if (!isHiden)
                ShowDialog();
            else
                Hide();
        }
        public void Invoke(Action action)
        {
            try
            {
                base.Invoke(action);
            }
            catch { }
        }
        public async void AwaitTask(Task task)
        {
            isHiden = false;
            await task;
            Hide();
            isHiden = true;
        }
        private void LoadingContextFormFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
