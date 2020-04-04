using SimplExServer.Builders;
using SimplExServer.View;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimplExServer.Controls
{
    public partial class EditQuestionGroupControl : UserControl, IEditQuestionGroupView
    {
        private Type tempType;
        private IList<Type> questionTypes;

        private int CurrentType { get => questionTypesList.SelectedIndex; set => questionTypesList.SelectedIndex = value; }

        public string GroupName { get => groupBox.Text; set => groupBox.Text = value; }
        public Type QuestionType
        {
            get => questionTypes[CurrentType]; set
            {
                if (questionTypes != null)
                {
                    for (int i = 0; i < questionTypes.Count; i++)
                        if (questionTypes[i] == value)
                        {
                            CurrentType = i;
                            return;
                        }
                    throw new Exception("Type not assigned.");
                }
                else tempType = value;
            }
        }
        public IList<Type> QuestionTypes
        {
            set
            {
                questionTypes = value;
                questionTypesList.Items.Clear();
                for (int i = 0; i < questionTypes.Count; i++)
                {
                    if (questionTypes[i] == typeof(OneAnswerQuestionBuilder))
                        questionTypesList.Items.Add("Обычная тестовый вопрос");
                }
                if (tempType != null)
                    QuestionType = tempType;
            }
        }
        public int GroupsCount { set => groupCountLabel.Text = "Количество групп вопросов: " + value; }
        public int QuestionsCount { set => questionsCountLabel.Text = "Количество вопросов: " + value; }

        public event ViewActionHandler<IEditQuestionGroupView> GroupAdded;
        public event ViewActionHandler<IEditQuestionGroupView> Saved;
        public event ViewActionHandler<IEditQuestionGroupView> QuestionAdded;
        public event ViewActionHandler<IEditQuestionGroupView> Import;
        public event ViewActionHandler<IEditQuestionGroupView> Deleted;
        public event ViewActionHandler<IEditQuestionGroupView> Changed;
        public event ViewActionHandler<IEditQuestionGroupView> Shown;
        public event ViewActionHandler<IEditQuestionGroupView> Hiden;

        public EditQuestionGroupControl()
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

        public void Close() => Dispose();

        private void AddGroupButtonClick(object sender, EventArgs e) => GroupAdded?.Invoke(this);
        private void SaveButtonClick(object sender, EventArgs e) => Saved?.Invoke(this);
        private void ImportButtonClick(object sender, EventArgs e) => Import?.Invoke(this);
        private void DeleteButtonClick(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить группу?", "Удаление группы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
                Deleted?.Invoke(this);
        }
        private void GroupBoxTextChanged(object sender, EventArgs e) => Changed?.Invoke(this);
        private void AddButtonClick(object sender, EventArgs e) => QuestionAdded?.Invoke(this);

        public void AskForSaving()
        {
            DialogResult dialogResult = MessageBox.Show("Сохранить группу?", "Изменения не сохранены", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
                Saved?.Invoke(this);
        }
    }
}
