using SimplExServer.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplExServer
{
    public partial class StartSessionForm : Form, IStartSessionView
    {
        public string GroupName { get => groupNameBox.Text; set => groupNameBox.Text = value; }
        public bool SaveResults { get => saveResultsCheck.Checked; set => saveResultsCheck.Checked = value; }
        public bool MixAnswers { get => mixAnswersCheck.Checked; set => mixAnswersCheck.Checked = value; }
        public bool EnableChat { get => chatCheck.Checked; set => chatCheck.Checked = value; }
        public bool WaitForReconnection { get => waitReconnectionCheck.Checked; set => waitReconnectionCheck.Checked = value; }
        public int ReconnectionTime { get => (int)reconnectTimeBox.Value; set => reconnectTimeBox.Value = value; }
        public bool TrackViolations { get => trackViolationsCheck.Checked; set => trackViolationsCheck.Checked = value; }
        public int ViolationsLimit { get => (int)violationsLimitBox.Value; set => violationsLimitBox.Value = value; }
        public bool TrackStatusCheck { get => trackStatusCheck.Checked; set => trackStatusCheck.Checked = value; }

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

        private void GroupNameBoxTextChanged(object sender, EventArgs e)
        {
            startSessionButton.Enabled = groupNameBox.Text.Length != 0;
        }
    }
}
