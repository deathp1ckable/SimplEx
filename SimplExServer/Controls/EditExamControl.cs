using SimplExServer.View;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SimplExServer.Controls
{
    public partial class EditExamControl : UserControl, IEditPropertiesView
    {
        public string ExamName { get => nameBox.Text; set => nameBox.Text = value; }
        public string Discipline { get => disciplineBox.Text; set => disciplineBox.Text = value; }
        public string CreatorName { get => creatorNameBox.Text; set => creatorNameBox.Text = value; }
        public string CreatorSurname { get => creatorSurnameBox.Text; set => creatorSurnameBox.Text = value; }
        public string CreatorPatronymic { get => creatorPatronymicBox.Text; set => creatorPatronymicBox.Text = value; }
        public int FirstNumber { get => (int)firstNumberUD.Value; set => firstNumberUD.Value = value; }
        public string Description { get => descriptionBox.Text; set => descriptionBox.Text = value; }
        public string Password
        {
            get
            {
                if (!passwordCheck.Checked)
                    return null;
                return passwordBox.Text;
            }
            set
            {
                if (value != null && value.Length != 0)
                {
                    passwordBox.Text = value;
                    passwordCheck.Checked = true;
                    PasswordCheckCheckedChanged(passwordCheck, null);
                }
                else
                {
                    passwordCheck.Checked = false;
                    PasswordCheckCheckedChanged(passwordCheck, null);
                }
            }
        }
        public double ExaminationTime
        {
            get
            {
                if (!timeRestrictCheck.Checked)
                    return 0;
                return (double)(hourUD.Value * 3600 + minuteUD.Value * 60 + secondsUD.Value);
            }
            set
            {
                if (value == 0)
                {
                    timeRestrictCheck.Checked = false;
                    TimeRestrictCheckCheckedChanged(timeRestrictCheck, null);
                    return;
                }
                timeRestrictCheck.Checked = true;
                TimeSpan timeSpan = TimeSpan.FromSeconds(value);
                hourUD.Value = timeSpan.Hours;
                minuteUD.Value = timeSpan.Minutes;
                secondsUD.Value = timeSpan.Seconds;
            }
        }
        public string RepeatPassword { get => repeatBox.Text; set => repeatBox.Text = value; }
        public bool IsSaved { get; set; }
        public EditExamControl()
        {
            InitializeComponent();
            timeRestrictCheck.CheckedChanged += TimeRestrictCheckCheckedChanged;
            passwordCheck.CheckedChanged += PasswordCheckCheckedChanged;
        }
  
        public event ViewActionHandler<IEditPropertiesView> ChangesSaved;
        public event ViewActionHandler<IEditPropertiesView> ChangesCanceled;
        public event ViewActionHandler<IEditPropertiesView> Changed;

        public void MessageWrongExamName(string reason) => nameToolTip.Show(reason, nameBox, 2000);
        public void MessageWrongDiscipline(string reason) => disciplineToolTip.Show(reason, disciplineBox, 2000);
        public void MessageWrongCreatorName(string reason) => aNameToolTip.Show(reason, creatorNameBox, 2000);
        public void MessageWrongCreatorSurname(string reason) => aSurnameToolTip.Show(reason, creatorSurnameBox, 2000);
        public void MessageWrongCreatorPatronymic(string reason) => aPatronymicToolTip.Show(reason, creatorPatronymicBox, 2000);
        public void MessageWrongPassword(string reason) => passwordToolTip.Show(reason, passwordBox, 2000);
        public void MessageWrongRepeat(string reason) => repeatToolTip.Show(reason, repeatBox, 2000);
        private void TimeRestrictCheckCheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            hourUD.Enabled = checkBox.Checked;
            minuteUD.Enabled = checkBox.Checked;
            secondsUD.Enabled = checkBox.Checked;
            secondsLabel.Enabled = checkBox.Checked;
            minutesLabel.Enabled = checkBox.Checked;
            hoursLabel.Enabled = checkBox.Checked;
            restrictLabel.Enabled = checkBox.Checked;
        }
        private void PasswordCheckCheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            passwordBox.Enabled = checkBox.Checked;
            repeatBox.Enabled = checkBox.Checked;
            repeatLabel.Enabled = checkBox.Checked;
            passwordLabel.Enabled = checkBox.Checked;
        }
        private void CancelButtonClick(object sender, EventArgs e)
        {
            if (ExaminationTime == 0)
            {
                timeRestrictCheck.Checked = false;
                TimeRestrictCheckCheckedChanged(timeRestrictCheck, null);
            }
            ChangesCanceled?.Invoke(this);
        }
        private void SaveButtonClick(object sender, EventArgs e)
        {
            if (ExaminationTime == 0)
            {
                timeRestrictCheck.Checked = false;
                TimeRestrictCheckCheckedChanged(timeRestrictCheck, null);
            }
            ChangesSaved?.Invoke(this);
        }
        private void PropsChanged(object sender, EventArgs e) => Changed?.Invoke(this);
        public void Close()
        {
            Dispose();
        }
    }
}
