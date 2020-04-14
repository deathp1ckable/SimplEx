using SimplExClient.View;
using SimplExModel.Model;
using SimplExModel.Model.Inherited;
using SimplExModel.NetworkData;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimplExClient.Controls
{
    public partial class SessionInformationControl : UserControl, ISessionInformationView
    {
        private IList<Ticket> tickets;

        public string ExamName { set => nameBox.Text = value; }
        public string Discipline { set => disciplineBox.Text = value; }
        public string Description { set => descriptionBox.Text = value; }
        public string CreatorName { set => creatorNameBox.Text = value; }
        public string CreatorSurname { set => creatorSurnameBox.Text = value; }
        public string CreatorPatronymic { set => creatorPatronymicBox.Text = value; }
        public double ExaminationTime
        {
            set
            {
                if (value == 0)
                {
                    timeRestrictCheck.Checked = false;
                    return;
                }
                timeRestrictCheck.Checked = true;
                TimeSpan timeSpan = TimeSpan.FromSeconds(value);
                hourBox.Text = timeSpan.Hours.ToString();
                minuteBox.Text = timeSpan.Minutes.ToString();
                secondBox.Text = timeSpan.Seconds.ToString();
            }
        }
        public int FirstQuestionNumber { set => firstNumberBox.Text = value.ToString(); }
        public Type MarkSystemType
        {
            set
            {
                if (value == typeof(FiveStepMarkSystem))
                    markSystemTypeBox.Text = "Обычная пятиступенчатая";
            }
        }
        public string MarkSystemDescription { set => markSystemDescriptionBox.Text = value; }

        public string TeacherName { set => teacherNameBox.Text = value; }
        public string TeacherSurname { set => teacherSurnameBox.Text = value; }
        public string TeacherPatronymic { set => teacherPatronymicBox.Text = value; }

        public string GroupName { set => groupBox.Text = value; }
        public double ReconnectionTime
        {
            set
            {
                waitReconnectionCheck.Checked = value > 0;
                if (value <= 0)
                    reconnectionTimeBox.Text = "-";
                else
                    reconnectionTimeBox.Text = value.ToString();
            }
        }
        public int ViolationsLimit
        {
            set
            {
                trackViolationsCheck.Checked = value >= 0;
                if (value < 0)
                    violationLimitBox.Text = "-";
                else
                    violationLimitBox.Text = value.ToString();
            }
        }
        public bool EnableChat { set => chatCheck.Checked = value; }
        public bool Mixing { set => mixingCheck.Checked = value; }
        public bool SaveResults { set => saveResultsCheck.Checked = value; }
        public bool TrackStatus { set => trackStatusCheck.Checked = value; }

        public string ConnectionName { get => connectionNameBox.Text; set => connectionNameBox.Text = value; }
        public string ConnectionSurname { get => connectionSurnameBox.Text; set => connectionSurnameBox.Text = value; }
        public string ConnectionPatronymic { get => connectionPatronymicBox.Text; set => connectionPatronymicBox.Text = value; }
        public Ticket CurrentTicket { get => tickets[ticketsList.SelectedIndex]; set => ticketsList.SelectedIndex = tickets.IndexOf(value); }
        public ClientStatus ClientStatus
        {
            set
            {
                switch (value)
                {
                    case ClientStatus.Connected:
                        statusBox.Text = "Статус: Ожидание начала сессии";
                        ToggleClientDataControls(true);
                        break;
                    case ClientStatus.Executing:
                        statusBox.Text = "Статус: Выполнение";
                        ticketBox.Text = $"Билет '{CurrentTicket.TicketName}'";
                        ToggleClientDataControls(false);
                        break;
                    case ClientStatus.Reconnecting:
                        statusBox.Text = "Статус: Переподключение";
                        ToggleClientDataControls(false);
                        break;
                    case ClientStatus.Executed:
                        statusBox.Text = "Статус: Выполнено";
                        ToggleClientDataControls(false);
                        break;
                }
            }
        }

        public int CurrentQuestionNumber { set => currentQuestionBox.Text = value.ToString(); }
        public int ExecutedQuestions { set => executedQuestionBox.Text = value.ToString(); }
        public IList<string> Violations
        {
            set
            {
                violationsList.Items.Clear();
                for (int i = 0; i < value.Count; i++)
                    violationsList.Items.Add(value[i]);
                if (violationsList.Items.Count == 0)
                    violationsList.Items.Add("Нет нарушений.");
            }
        }

        public IList<Ticket> Tickets
        {
            get => tickets; set
            {
                tickets = value;
                ticketsList.Items.Clear();
                for (int i = 0; i < tickets.Count; i++)
                    ticketsList.Items.Add($"Билет '{tickets[i].TicketName}'");
            }
        }

        public event ViewActionHandler<ISessionInformationView> ClientDataChanged;
        public event ViewActionHandler<ISessionInformationView> Shown;
        public SessionInformationControl() => InitializeComponent();
        public new void Show()
        {
            base.Show();
            Shown?.Invoke(this);
        }
        public void Close() => Dispose();

        public void Invoke(Action action)
        {
            try
            {
                base.Invoke(action);
            }
            catch { }
        }
        private void ToggleClientDataControls(bool enable)
        {
            connectionSurnameBox.ReadOnly = connectionPatronymicBox.ReadOnly = connectionNameBox.ReadOnly = !enable;
            ticketBox.Visible = !enable;
            ticketsList.Visible = enable;
            saveDataButton.Enabled = enable;
        }

        private void SaveDataButtonClick(object sender, EventArgs e)
        {
            ClientDataChanged?.Invoke(this);
            saveDataButton.Enabled = false;
        }

        private void DataTextChanged(object sender, EventArgs e)
        {
            saveDataButton.Enabled = true;
        }

        private void TicketsListSelectedIndexChanged(object sender, EventArgs e)
        {
            saveDataButton.Enabled = true;
        }
    }
}
