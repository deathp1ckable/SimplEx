using SimplExClient.View;
using System.Windows.Forms;
using System;
namespace SimplExClient.Forms
{
    public partial class LogInForm : Form, ILogInView
    {
        private ApplicationContext context;
        public string ViewName { get => nameBox.Text; set => nameBox.Text = value; }
        public string Surname { get => surnameBox.Text; set => surnameBox.Text = value; }
        public string Patronymic { get => patronymicBox.Text; set => patronymicBox.Text = value; }
        public bool AllowConnect { get => connectButton.Enabled; set => connectButton.Enabled = value; }
        public event ViewActionHandler<ILogInView> Connected;
        public event ViewActionHandler<ILogInView> ViewShown;

        public LogInForm(ApplicationContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        public void Message(string message)
        {
            MessageBox.Show(message);
        }

        public new void Show()
        {
            context.MainForm = this;
            base.Show();
            ViewShown?.Invoke(this);
        }
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ConnectButtonClick(object sender, EventArgs e)
        {
            Connected?.Invoke(this);
        }
        public void Invoke(Action action)
        {
            try
            {
                base.Invoke(action);
            }
            catch { }
        }

        private void NameBoxTextChanged(object sender, EventArgs e)
        {
            CheckConnectionEnabled();
        }

        private void SurnameBoxTextChanged(object sender, EventArgs e)
        {
            CheckConnectionEnabled();
        }

        private void PatronymicBoxTextChanged(object sender, EventArgs e)
        {
            CheckConnectionEnabled();
        }
        private void CheckConnectionEnabled()
        {
            connectButton.Enabled = !string.IsNullOrEmpty(nameBox.Text.Trim()) && !string.IsNullOrEmpty(surnameBox.Text.Trim()) && !string.IsNullOrEmpty(patronymicBox.Text.Trim());
        }
    }
}
