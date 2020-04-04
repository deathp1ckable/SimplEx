using System;
using System.Windows.Forms;
using SimplExServer.View;
using SimplExServer.Builders;
using System.Drawing;
using System.Collections.Generic;

namespace SimplExServer.Controls
{
    public partial class EditQuestionControl : UserControl, IEditQuestionView
    {
        private IList<ThemeBuilder> themeBuilders;
        private ThemeBuilder tempBuilder;
        private IEditOneAnswerQuestionView editOneAnswerQuestionView;

        private int CurrentType
        {
            get => themesList.SelectedIndex; set
            {
                if (themesList.Items.Count > 0)
                    themesList.SelectedIndex = value;
            }
        }
        public int QuestionNumber { set => numberLabel.Text = "Номер вопроса: " + value; }
        public Type QuestionType
        {
            set
            {
                if (value == typeof(OneAnswerQuestionBuilder))
                    questionTypeLabel.Text = "Тип вопроса: Обычная тестовый вопрос";
            }
        }
        public IList< ThemeBuilder> Themes
        {
            set
            {
                themeBuilders = value;
                themesList.Items.Clear();
                for (int i = 0; i < themeBuilders.Count; i++)
                {
                    themesList.Items.Add($"Тема '{themeBuilders[i].ThemeName}'");
                }
                if (tempBuilder != null)
                    Theme = tempBuilder;
            }
        }
        public ThemeBuilder Theme
        {
            get
            {
                if (themeBuilders == null || themeBuilders.Count == 0)
                    return null;
                return themeBuilders[CurrentType];
            }

            set
            {
                if (themeBuilders != null)
                {
                    for (int i = 0; i < themeBuilders.Count; i++)
                        if (themeBuilders[i] == value)
                        {
                            CurrentType = i;
                            return;
                        }
                    CurrentType = 0;
                    ThemeChanged?.Invoke(this);
                }
                else tempBuilder = value;
            }
        }

        public IEditOneAnswerQuestionView EditOneAnswerQuestionView
        {
            get => editOneAnswerQuestionView; set
            {
                editOneAnswerQuestionView = value;
                UserControl control = (UserControl)editOneAnswerQuestionView;
                control.Parent = propertiesPanel;
                control.Size = propertiesPanel.Size;
                control.Location = new Point(0, 0);
                control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
        }
        public event ViewActionHandler<IEditQuestionView> ThemeChanged;
        public event ViewActionHandler<IEditQuestionView> Deleted;
        public event ViewActionHandler<IEditQuestionView> Shown;
        public event ViewActionHandler<IEditQuestionView> Hiden;

        public EditQuestionControl()
        {
            InitializeComponent();
        }
        public void Close() => Dispose();
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
        private void DeleteButtonClick(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить вопрос?", "Удаление вопроса", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
                Deleted?.Invoke(this);
        }
        private void ThemesListSelectedIndexChanged(object sender, EventArgs e) => ThemeChanged?.Invoke(this);
    }
}
