using SimplExClient.View;
using System.Windows.Forms;

namespace SimplExClient.Forms
{
    public partial class ResultForm : Form, IResultView
    {
        private ApplicationContext context;
        public string Result { set => resultBox.Text = value; }
        public string Points { set => pointsBox.Text = value; }
        public string Mark { set => markBox.Text = value; }

        public event ViewActionHandler<IResultView> Continued;
        public event ViewActionHandler<IResultView> Exited;
        public ResultForm(ApplicationContext context)
        {
            InitializeComponent();
            this.context = context;
        }
        public new void Show()
        {
            ShowDialog();
        }
        public void Exit()
        {
            context.MainForm = this;
            Close();
            Application.Exit();
        }
        private void ContinueButtonButtonClick(object sender, System.EventArgs e)
        {
            Continued?.Invoke(this);
        }

        private void ExitButtonClick(object sender, System.EventArgs e)
        {
            Exited?.Invoke(this);
        }
    }
}
