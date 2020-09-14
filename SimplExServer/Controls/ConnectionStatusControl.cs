using SimplExModel.NetworkData;
using SimplExServer.View;
using System;
using System.Windows.Forms;

namespace SimplExServer.Controls
{
    public partial class ConnectionStatusControl : UserControl, IConnectionStatusView
    {
        private ClientStatus clientStatus;
        private int executedQuestions = -1;
        private bool trackViolations;
        private bool trackStatus;

        public string ConnectionName { set => connectionNameBox.Text = value; }
        public string ConnectionSurname { set => connectionSurnameBox.Text = value; }
        public string ConnectionPatronimyc { set => connectionPatronymicBox.Text = value; }
        public string TicketName { set => ticketBox.Text = value; }

        public bool TrackStatus
        {
            get => trackStatus; set
            {
                trackStatus = value;
                CheckToggles(clientStatus);
                currentQuestionBox.Text = trackStatus || clientStatus == ClientStatus.Connected ? currentQuestionBox.Text : "-";
                executedQuestionBox.Text = trackStatus || clientStatus == ClientStatus.Connected ? executedQuestionBox.Text : "-";
            }
        }

        public ClientStatus ClientStatus
        {
            set
            {
                clientStatus = value;
                CheckToggles(value);
            }
        }

        public bool TrackViolations
        {
            get => trackViolations; set
            {
                trackViolations = value;
                CheckToggles(clientStatus);
                if (!trackViolations)
                {
                    violationsList.Items.Clear();
                    violationsList.Items.Add("Нарушения не отслеживаются.");
                }
            }
        }

        public string ViolationContent { get => violationContentBox.Text; set => violationContentBox.Text = value; }
        public double Points
        {
            set
            {
                if (clientStatus == ClientStatus.Executed)
                    pointsBox.Text = value.ToString("F2");
                else pointsBox.Text = "-";
            }
        }
        public double Mark
        {
            set
            {
                if (clientStatus == ClientStatus.Executed)
                    markBox.Text = value.ToString("F2");
                else markBox.Text = "-";
            }
        }

        public event ViewActionHandler<IConnectionStatusView> ViolationAdded;
        public event ViewActionHandler<IConnectionStatusView> Disconnected;
        public event ViewActionHandler<IConnectionStatusView> WathcResult;
        public event ViewActionHandler<IConnectionStatusView> Shown;
        public event ViewActionHandler<IConnectionStatusView> Hiden;

        public ConnectionStatusControl()
        {
            InitializeComponent();
        }
        public new void Show()
        {
            base.Show();
            Shown?.Invoke(this);
        }
        public new void Hide()
        {
            base.Hide();
            Hiden?.Invoke(this);
        }
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void Invoke(Action action)
        {
            try
            {
                base.Invoke(action);
            }
            catch { }
        }
        public void AddViolation(string content, double offset)
        {
            if (!TrackViolations)
                throw new Exception();
            violationsList.Items.Add(content);
            executionChart.Series["violationsSeries"].Points.AddXY(Math.Round(offset, 2), executedQuestions);
        }
        public void AddStatus(int currentQuestion, int executedQuestions, double offset)
        {
            if (!TrackStatus)
                throw new Exception();
            executedQuestionBox.Text = executedQuestions.ToString();
            currentQuestionBox.Text = $"№{currentQuestion}";
            if (executedQuestions != this.executedQuestions)
                executionChart.Series["executionSeries"].Points.AddXY(Math.Round(offset, 2), executedQuestions);
            this.executedQuestions = executedQuestions;
        }
        public void ClearStatuses()
        {
            executionChart.Series["executionSeries"].Points.Clear();
        }
        public void ClearViolations()
        {
            violationsList.Items.Clear();
            executionChart.Series["violationsSeries"].Points.Clear();
        }
        public void Close()
        {
            Dispose();
        }
        private void ToggleViolation(bool enabled)
        {
            violationLabel.Enabled = violationsList.Enabled =
            violationContentLabel.Enabled = violationContentBox.Enabled =
            addViolationButton.Enabled = enabled;
        }
        private void ToggleStatus(bool enabled)
        {
            executedQuestionLabel.Enabled = currentQuestionBox.Enabled =
            executedQuestionBox.Enabled = currentQuestionLabel.Enabled =
            executionChart.Enabled = chartLabel.Enabled = enabled;
        }
        private void ToggleConnectionControl(bool enabled)
        {
            connectionLabel.Enabled = disconnectButton.Enabled = enabled;
        }
        private void ToggleOpenResult(bool enabled)
        {
            markLabel.Enabled = markBox.Enabled =
            pointsLabel.Enabled = pointsBox.Enabled =
            resultLabel.Enabled = openResultButton.Enabled = enabled;
        }
        private void CheckToggles(ClientStatus value)
        {
            switch (value)
            {
                case ClientStatus.Connected:
                    statusBox.Text = "Ожидание начала сессии";
                    ToggleStatus(false);
                    ToggleViolation(false);
                    ToggleOpenResult(false);
                    ToggleConnectionControl(true);
                    break;
                case ClientStatus.Executing:
                    statusBox.Text = "Выполнение";
                    ToggleStatus(TrackStatus);
                    ToggleViolation(TrackViolations);
                    ToggleOpenResult(false);
                    ToggleConnectionControl(true);
                    break;
                case ClientStatus.Reconnecting:
                    statusBox.Text = "Переподключение";
                    ToggleStatus(false);
                    ToggleViolation(false);
                    ToggleOpenResult(false);
                    ToggleConnectionControl(true);
                    break;
                case ClientStatus.Executed:
                    ToggleStatus(false);
                    ToggleViolation(false);
                    ToggleOpenResult(true);
                    ToggleConnectionControl(false);
                    statusBox.Text = "Выполнено";
                    break;
            }
        }

        private void AddViolationButtonClick(object sender, EventArgs e)
        {
            ViolationAdded?.Invoke(this);
        }
        private void OpenResultButtonClick(object sender, EventArgs e)
        {
            WathcResult?.Invoke(this);
        }
        private void DisconnectButtonClick(object sender, EventArgs e)
        {
            Disconnected?.Invoke(this);
        }
    }
}
