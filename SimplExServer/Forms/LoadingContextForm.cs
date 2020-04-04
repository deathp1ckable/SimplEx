using SimplExServer.View;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplExServer.Forms
{
    public partial class LoadingContextForm : Form, ILoadingContextView
    {
        public LoadingContextForm()
        {
            InitializeComponent();
        }
        public new void Show()
        {
            ShowDialog();
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
            await task;
            Close();
        }
    }
}
