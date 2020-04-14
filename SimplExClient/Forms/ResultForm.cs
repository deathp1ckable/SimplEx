using SimplExClient.View;
using System.Windows.Forms;

namespace SimplExClient.Forms
{
    public partial class ResultForm : Form, IResultView
    {
        public string Result { set => resultBox.Text = value; }
        public string Points { set => pointsBox.Text = value; }
        public string Mark { set => markBox.Text = value; }

        public event ViewActionHandler<IResultView> Continued;
        public ResultForm()
        {
            InitializeComponent();
        }
        public new void Show()
        {
            ShowDialog();
        }
        private void ConnectButtonClick(object sender, System.EventArgs e)
        {
            Continued?.Invoke(this);
        }
    }
}
