using SimplExServer.View;
using System;
using System.Windows.Forms;

namespace SimplExServer
{
    public partial class StartSessionForm : Form, IStartSessionView
    {
        public string GroupName { get => groupNameBox.Text; set => groupNameBox.Text = value; }
        public bool SaveResults { get => saveResultsCheck.Checked; set => saveResultsCheck.Checked = value; }
        public bool Mixing { get => mixAnswersCheck.Checked; set => mixAnswersCheck.Checked = value; }
        public bool EnableChat { get => chatCheck.Checked; set => chatCheck.Checked = value; }
        public bool TrackStatusCheck { get => trackStatusCheck.Checked; set => trackStatusCheck.Checked = value; }

        public string TeacherName { get => nameBox.Text; set => nameBox.Text = value; }
        public string TeacherSurname { get => surnameBox.Text; set => surnameBox.Text = value; }
        public string TeacherPatronymic { get => patronymicBox.Text; set => patronymicBox.Text = value; }

        public int ReconnectionTime
        {
            get
            {
                if (waitReconnectionCheck.Checked)
                    return (int)reconnectTimeBox.Value;
                else return 0;
            }
            set
            {
                if (waitReconnectionCheck.Checked)
                    reconnectTimeBox.Value = value;
                else reconnectTimeBox.Value = 0;
            }
        }
        public int ViolationsLimit
        {
            get
            {
                if (trackViolationsCheck.Checked)
                    return (int)violationsLimitBox.Value;
                return -1;
            }
            set
            {
                if (trackViolationsCheck.Checked)
                    violationsLimitBox.Value = value;
                else violationsLimitBox.Value = 0;
            }
        }

        public event ViewActionHandler<IStartSessionView> Started;
        public event ViewActionHandler<IStartSessionView> Canceled;
        public StartSessionForm()
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
        public void ShowError(string message) => MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void StartSessionButtonClick(object sender, EventArgs e)
        {
            Started?.Invoke(this);
        }
        private void CancelButtonClick(object sender, EventArgs e)
        {
            Canceled?.Invoke(this);
        }
        private void WaitReconnectionCheckCheckedChanged(object sender, EventArgs e)
        {
            if (waitReconnectionCheck.Checked)
            {
                reconnectTimeBox.Enabled = true;
                reconnectionLabel.Enabled = true;
            }
            else
            {
                reconnectTimeBox.Enabled = false;
                reconnectionLabel.Enabled = false;
            }
        }

        private void TrackViolationsCheckCheckedChanged(object sender, EventArgs e)
        {
            if (trackViolationsCheck.Checked)
            {
                violationsLimitBox.Enabled = true;
                limitLabel.Enabled = true;
            }
            else
            {
                violationsLimitBox.Enabled = false;
                limitLabel.Enabled = false;
            }
        }

        private void NameTextChanged(object sender, EventArgs e)
        {
            startSessionButton.Enabled = !string.IsNullOrEmpty(nameBox.Text.Trim()) && !string.IsNullOrEmpty(surnameBox.Text.Trim()) && !string.IsNullOrEmpty(patronymicBox.Text.Trim()) && !string.IsNullOrEmpty(groupNameBox.Text.Trim());
        }
    }
}
