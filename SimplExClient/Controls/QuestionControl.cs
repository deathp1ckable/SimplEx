using SimplExClient.View;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimplExClient.Controls
{
    public partial class QuestionControl : UserControl, IQuestionView
    {
        private IOneAnswerQuestionView oneAnswerQuestionView;

        public IOneAnswerQuestionView OneAnswerQuestionView
        {
            get => oneAnswerQuestionView;
            set
            {
                oneAnswerQuestionView = value;
                UserControl control = (UserControl)oneAnswerQuestionView;
                control.Parent = propertiesPanel;
                control.Size = propertiesPanel.Size;
                control.Location = new Point(0, 0);
                control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
        }
        public string ThemeName { set => themeBox.Text = value; }
        public string QuestionTitle { set => questionTitleLabel.Text = value; }
        public double Points { set => pointsLabel.Text = "Балл за вопрос: " + value.ToString("F2"); }
        public bool NextExisting { set => nextButtonEnabled.Enabled = value; }
        public bool PrevExisting { set => prevButton.Enabled = value; }


        public event ViewActionHandler<IQuestionView> Shown;
        public event ViewActionHandler<IQuestionView> NextQuestion;
        public event ViewActionHandler<IQuestionView> PrevQuestion;

        public QuestionControl()
        {
            InitializeComponent();
        }
        public new void Show()
        {
            base.Show();
            Shown?.Invoke(this);
        }
        public void Close()
        {
            Dispose();
        }

        private void PrevButtonClick(object sender, EventArgs e)
        {
            PrevQuestion?.Invoke(this);
        }
        private void NextButtonEnabledClick(object sender, EventArgs e)
        {
            NextQuestion?.Invoke(this);
        }

        public void Invoke(Action action)
        {
            try
            {
                base.Invoke(action);
            }
            catch { }
        }
    }
}
