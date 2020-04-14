using SimplExClient.View;
using System.Threading;
using System.Windows.Forms;
namespace SimplExClient.Forms
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
                Invoke(action);
            }
            catch
            { }
        }
        private void LoadingContextFormFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
