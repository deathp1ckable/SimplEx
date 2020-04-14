using SimplExServer.Service;
using SimplExServer.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SimplExServer
{
    public partial class SessionForm : Form, ISessionView
    {
        private TimeSpan timeSpan;
        private SessionStatus sessionStatus;
        private bool closingByPresenter;
        private Button disabledButton;
        private SessionClient currentSessionClient;
        private IList<SessionClient> sessionClients;
        private ISessionInformationView sessionInformationView;
        private IChatView chatView;
        private IConnectionStatusView connectionStatusView;

        public double Time { get => timeSpan.TotalSeconds; set => timeSpan = TimeSpan.FromSeconds(value); }
        public string GroupName { set => groupLabel.Text = $"Группа: {value}"; }
        public SessionStatus SessionStatus
        {
            set
            {
                sessionStatus = value;
                switch (value)
                {
                    case SessionStatus.NotStarted:
                        sessionStatusLabel.Text = "Статус: Сессия не запущена";
                        break;
                    case SessionStatus.WaitingForConnections:
                        sessionStatusLabel.Text = "Статус: Ожидание подключений";
                        break;
                    case SessionStatus.ExecutionInProgress:
                        sessionStatusLabel.Text = "Статус: Выполнение";
                        break;
                    case SessionStatus.Finished:
                        sessionStatusLabel.Text = "Статус: Сессия окончена";
                        break;
                }
            }
        }
        public SessionClient CurrentSessionClient { get => currentSessionClient; set => clientsList.SelectedIndex = sessionClients.IndexOf(value); }
        public IList<SessionClient> SessionClients
        {
            get => sessionClients; set
            {
                sessionClients = value;
                clientsList.Items.Clear();
                for (int i = 0; i < sessionClients.Count; i++)
                    clientsList.Items.Add($"{sessionClients[i].Surname} {sessionClients[i].Name} {sessionClients[i].Patronymic}");
                if (sessionClients.Count == 0)
                {
                    clientsList.Items.Add("Нет подключений");
                    startStopSessionButton.Enabled = false;
                }
                else
                    startStopSessionButton.Enabled = true;
                int index = sessionClients.IndexOf(currentSessionClient);
                if (index < 0)
                    TabStopClick(sesionInfoButton, EventArgs.Empty);
                else
                {
                    CurrentSessionClient = currentSessionClient;
                }
                CheckProperties();
                disabledButton.BackColor = SystemColors.Control;
                disabledButton.Enabled = false;
            }
        }

        public ISessionInformationView SessionInformationView
        {
            get => sessionInformationView; set
            {
                sessionInformationView = value;
                UserControl control = (UserControl)sessionInformationView;
                control.Parent = propertiesPanel;
                control.Size = propertiesPanel.Size;
                control.Location = new Point(0, 0);
                control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
        }
        public IConnectionStatusView ConnectionStatusView
        {
            get => connectionStatusView;
            set
            {
                connectionStatusView = value;
                UserControl control = (UserControl)connectionStatusView;
                control.Parent = propertiesPanel;
                control.Size = propertiesPanel.Size;
                control.Location = new Point(0, 0);
                control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
        }
        public IChatView ChatView
        {
            get => chatView; set
            {
                chatView = value;
                UserControl control = (UserControl)chatView;
                control.Parent = propertiesPanel;
                control.Size = propertiesPanel.Size;
                control.Location = new Point(0, 0);
                control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
        }

        public event ViewActionHandler<ISessionView> ClientChanged;
        public event ViewActionHandler<ISessionView> SessionAborted;
        public event ViewActionHandler<ISessionView> SessionStarted;
        public event ViewActionHandler<ISessionView> SessionStoped;

        public SessionForm()
        {
            InitializeComponent();
            disabledButton = sesionInfoButton;
            connectionControlButton.Enabled = additionButton.Enabled = false;
            connectionControlButton.BackColor = additionButton.BackColor = SystemColors.Control;
            connectionControlButton.FlatAppearance.BorderSize = additionButton.FlatAppearance.BorderSize = 1;
        }
        public new void Show()
        {
            ShowDialog();
        }
        public new void Close()
        {
            closingByPresenter = true;
            base.Close();
        }
        public void ShowMessage(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void Invoke(Action action)
        {
            try
            {
                base.Invoke(action);
            }
            catch { }
        }
        public void ShowClientToolTip(SessionClient sessionClient, string title, string caption, bool isWarning)
        {
            Control temp = ActiveControl;
            clientsList.Focus();
            connectionsListToolTip.ToolTipTitle = title;
            connectionsListToolTip.ToolTipIcon = isWarning ? ToolTipIcon.Warning : ToolTipIcon.Info;
            Rectangle rectangle = clientsList.GetItemRectangle(sessionClients.IndexOf(sessionClient));
            connectionsListToolTip.Show(caption, clientsList, rectangle.X + rectangle.Width / 2, rectangle.Y + rectangle.Height / 2, 3000);
            temp.Focus();
        }
        private void TabStopClick(object sender, EventArgs e)
        {
            Button senderButton = (Button)sender;

            disabledButton.BackColor = Color.FromArgb(171, 31, 47);
            senderButton.BackColor = SystemColors.Control;

            disabledButton.Enabled = true;
            senderButton.Enabled = false;
            disabledButton = senderButton;
            switch (int.Parse(senderButton.Tag.ToString()))
            {
                case 0:
                    HideAllProperties();
                    sessionInformationView?.Show();
                    break;
                case 1:
                    HideAllProperties();
                    ConnectionStatusView?.Show();
                    break;
                case 2:
                    HideAllProperties();
                    ChatView?.Show();
                    break;
            }
        }

        private void ClientsListMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sessionClients.Count != 0)
            {
                ClientChanged?.Invoke(this);

            }
        }

        private void ClientsListSelectedIndexChanged(object sender, EventArgs e)
        {
            if (clientsList.SelectedIndex >= 0 && clientsList.SelectedIndex < sessionClients.Count)
                currentSessionClient = sessionClients[clientsList.SelectedIndex];
            CheckProperties();
            disabledButton.BackColor = SystemColors.Control;
            disabledButton.Enabled = false;
        }
        private void CheckProperties()
        {
            if (sessionClients.Count > 0 && clientsList.SelectedIndex >= 0 && clientsList.SelectedIndex < sessionClients.Count)
            {
                connectionControlButton.Enabled = additionButton.Enabled = true;
                connectionControlButton.BackColor = additionButton.BackColor = Color.FromArgb(171, 31, 47);
                ClientChanged?.Invoke(this);
            }
            else
            {
                connectionControlButton.Enabled = additionButton.Enabled = false;
                connectionControlButton.BackColor = additionButton.BackColor = SystemColors.Control;
            }
        }
        private void HideAllProperties()
        {
            SessionInformationView?.Hide();
            ConnectionStatusView?.Hide();
            ChatView?.Hide();
        }

        private void SessionFormFormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closingByPresenter && sessionStatus != SessionStatus.Finished)
            {
                DialogResult dialogResult = MessageBox.Show("Остановить сессию принудительно?", "Принудительная остановка сессии", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                    SessionAborted?.Invoke(this);
                else e.Cancel = true;
            }
            closingByPresenter = false;
        }

        private void StartStopSessionButtonClick(object sender, EventArgs e)
        {
            if (sessionStatus == SessionStatus.WaitingForConnections)
            {
                if (Time > 0)
                {
                    startStopSessionButton.Text = "Остановить сессию";
                    timeLabel.Text = $"Осталось времени: {timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
                    timer.Start();
                }
                SessionStarted?.Invoke(this);
            }
            else
            {
                SessionStarted?.Invoke(this);
                Time = 1;
                timer.Stop();
                Time = 0;
                startStopSessionButton.Enabled = false;
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            timeSpan = TimeSpan.FromSeconds(timeSpan.TotalSeconds - 1);
            if (timeSpan.TotalSeconds >= 0)
            {
                timeLabel.Text = $"Осталось времени: {timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
                timer.Start();
            }
            else
                timeLabel.Text = $"Осталось времени: 00:00:00";
        }
    }
}
