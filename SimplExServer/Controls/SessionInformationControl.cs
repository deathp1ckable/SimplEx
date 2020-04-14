using SimplExModel.Model.Inherited;
using SimplExServer.View;
using System;
using System.Windows.Forms;

namespace SimplExServer.Controls
{
    public partial class SessionInformationControl : UserControl, ISessionInformationView
    {
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

        public SessionInformationControl() => InitializeComponent();

        public void Close() => Dispose();
    }
}
