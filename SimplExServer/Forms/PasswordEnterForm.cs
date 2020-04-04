using SimplExServer.View;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimplExServer.Forms
{
    public partial class PasswordEnterForm : Form, IPasswordEnterView
    {
        public string Password { get => passwordBox.Text; set => passwordBox.Text = value; }

        public event ViewActionHandler<IPasswordEnterView> Entered;
        public event ViewActionHandler<IPasswordEnterView> Canceled;
        public PasswordEnterForm()
        {
            InitializeComponent();
            enterButton.BackColor = Color.FromArgb(171, 31, 47);
        }
        public new void Show()
        {
            ShowDialog();
        }
        private void EnterButtonClick(object sender, EventArgs e)
        {
            Entered?.Invoke(this);
        }
        private void CancelButtonClick(object sender, EventArgs e)
        {
            Canceled?.Invoke(this);
        }
    }
}
