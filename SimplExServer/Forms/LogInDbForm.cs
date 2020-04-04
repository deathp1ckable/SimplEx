using SimplExServer.View;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimplExServer.Forms
{
    public partial class LogInDbForm : Form, ILogInDbView
    {
        public string Host { get => hostBox.Text; set => hostBox.Text = value; }
        public uint Port { get => (uint)portBox.Value; set => portBox.Value = value; }
        public string Username { get => usernameBox.Text; set => usernameBox.Text = value; }
        public string Password { get => passwordBox.Text; set => passwordBox.Text = value; }
        public LogInDbForm()
        {
            InitializeComponent();
            connectButton.BackColor = Color.FromArgb(171, 31, 47);
        }
        public new void Show()
        {
            ShowDialog();
        }
        public event ViewActionHandler<ILogInDbView> LoggedIn;
        public event ViewActionHandler<ILogInDbView> Skipped;
        public void ShowError(string message) => MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void ConnectButtonClick(object sender, EventArgs e) => LoggedIn?.Invoke(this);
        private void SkipButtonClick(object sender, EventArgs e) => Skipped?.Invoke(this);
    }
}
