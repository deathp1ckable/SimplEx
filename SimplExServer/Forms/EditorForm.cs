using SimplExServer.Builders;
using SimplExServer.View;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimplExServer
{
    public partial class EditorForm : Form, IEditMainView
    {
        object currentObject;
        private ApplicationContext context;
        private Button disabledButton;
        private int questionCount;
        private DateTime lastChangeDate;
        private DateTime creationDate;

        private IEditMarkSystemPropertiesView editMarkSystemView;
        private IEditPropertiesView editPropertiesView;
        private IEditThemesView editThemesView;
        private IEditThemeView editThemeView;
        private IEditTicketsView editTicketsView;
        private IEditTicketView editTicketView;
        private IEditTreeView editTreeView;
        private IEditQuestionGroupView editQuestionGroupView;
        private IEditQuestionView editQuestionView;
        private IEditSavingView editSavingView;

        public IEditMarkSystemPropertiesView EditMarkSystemView
        {
            get => editMarkSystemView;
            set
            {
                value.Canceled += ModifyMarkSystem;
                value.Saved += ModifyMarkSystem;
                value.Changed += ModifyMarkSystem;
                if (editMarkSystemView != null)
                {
                    editMarkSystemView.Canceled -= ModifyMarkSystem;
                    editMarkSystemView.Saved -= ModifyMarkSystem;
                    editMarkSystemView.Changed -= ModifyMarkSystem;
                }
                editMarkSystemView = value;
                if (!editMarkSystemView.IsSaved)
                    ModifyMarkSystem(value);
                UserControl control = (UserControl)editMarkSystemView;
                control.Parent = propertiesPanel;
                control.Size = propertiesPanel.Size;
                control.Location = new Point(0, 0);
                control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
        }
        public IEditPropertiesView EditPropertiesView
        {
            get => editPropertiesView;
            set
            {
                if (editPropertiesView != null)
                {
                    editPropertiesView.Changed -= ModifyProperties;
                    editPropertiesView.ChangesCanceled -= ModifyProperties;
                    editPropertiesView.ChangesSaved -= ModifyProperties;
                }
                value.Changed += ModifyProperties;
                value.ChangesCanceled += ModifyProperties;
                value.ChangesSaved += ModifyProperties;
                editPropertiesView = value;
                if (!editPropertiesView.IsSaved)
                    ModifyProperties(value);
                UserControl control = (UserControl)editPropertiesView;
                control.Parent = propertiesPanel;
                control.Size = propertiesPanel.Size;
                control.Location = new Point(0, 0);
                control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
        }
        public IEditThemeView EditThemeView
        {
            get => editThemeView;
            set
            {
                editThemeView = value;
                UserControl control = (UserControl)editThemeView;
                control.Parent = propertiesPanel;
                control.Size = propertiesPanel.Size;
                control.Location = new Point(0, 0);
                control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
        }
        public IEditThemesView EditThemesView
        {
            get => editThemesView;
            set
            {
                editThemesView = value;
                UserControl control = (UserControl)editThemesView;
                control.Parent = propertiesPanel;
                control.Size = propertiesPanel.Size;
                control.Location = new Point(0, 0);
                control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
        }
        public IEditTicketsView EditTicketsView
        {
            get => editTicketsView;
            set
            {
                editTicketsView = value;
                UserControl control = (UserControl)editTicketsView;
                control.Parent = propertiesPanel;
                control.Size = propertiesPanel.Size;
                control.Location = new Point(0, 0);
                control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
        }
        public IEditTicketView EditTicketView
        {
            get => editTicketView; set
            {
                editTicketView = value;
                UserControl control = (UserControl)editTicketView;
                control.Parent = propertiesPanel;
                control.Size = propertiesPanel.Size;
                control.Location = new Point(0, 0);
                control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
        }
        public IEditSavingView EditSavingView
        {
            get => editSavingView;
            set
            {
                editSavingView = value;
                UserControl control = (UserControl)editSavingView;
                control.Parent = propertiesPanel;
                control.Size = propertiesPanel.Size;
                control.Location = new Point(0, 0);
                control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
        }
        public IEditQuestionGroupView EditQuestionGroupView
        {
            get => editQuestionGroupView;
            set
            {
                editQuestionGroupView = value;
                UserControl control = (UserControl)editQuestionGroupView;
                control.Parent = propertiesPanel;
                control.Size = propertiesPanel.Size;
                control.Location = new Point(0, 0);
                control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
        }
        public IEditQuestionView EditQuestionView
        {
            get => editQuestionView;
            set
            {
                editQuestionView = value;
                UserControl control = (UserControl)editQuestionView;
                control.Parent = propertiesPanel;
                control.Size = propertiesPanel.Size;
                control.Location = new Point(0, 0);
                control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
        }
        public IEditTreeView EditTreeView
        {
            get => editTreeView;
            set
            {
                if (editTreeView != null)
                {
                    editTreeView.GoToProperties -= EditTreeViewGoToProperties;
                    editTreeView.NodeChanged -= EditTreeViewNodeChanged;
                }
                editTreeView = value;
                editTreeView.GoToProperties += EditTreeViewGoToProperties;
                editTreeView.NodeChanged += EditTreeViewNodeChanged;
                UserControl control = (UserControl)editTreeView;
                control.Parent = treePanel;
                control.Size = treePanel.Size;
                control.Location = new Point(0, 0);
                control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
        }
        public DateTime CreationDate
        {
            get => creationDate;
            set
            {
                creationDate = value;
                creationDateLabel.Text = "Дата создания: " + value.ToString("yyyy:MM:dd");
            }
        }
        public DateTime LastChangeDate
        {
            get => lastChangeDate;
            set
            {
                lastChangeDate = value;
                lastChangeDateLabel.Text = "Дата изменения: " + value.ToString("yyyy:MM:dd");
            }
        }
        public int QuestionCount
        {
            get => questionCount;
            set
            {
                questionCount = value;
                questionCountLabel.Text = "Количество вопросов: " + value;
            }
        }

        public EditorForm(ApplicationContext context)
        {
            InitializeComponent();
            unsavedPropertiesTip.SetToolTip(propertiesButton, "Некоторые параметры следует сохранить.");
            unsavedMarkSystemToolTip.SetToolTip(markSystemButton, "Некоторые параметры следует сохранить.");
            this.context = context;
            disabledButton = propertiesButton;
            headerPanel.BackColor = Color.FromArgb(171, 31, 47);
        }
        public new void Show()
        {
            //   context.MainForm = this;
            ShowDialog();
        }
        private void EditTreeViewGoToProperties(IEditTreeView sender)
        {
            if (!ReferenceEquals(disabledButton, contentButton) || !ReferenceEquals(editTreeView.CurrentObject, currentObject))
            {
                disabledButton.BackColor = Color.FromArgb(171, 31, 47);
                disabledButton.Enabled = true;
                disabledButton = contentButton;
                disabledButton.BackColor = SystemColors.ControlLight;
                disabledButton.Enabled = false;
                EditPropertiesView?.Hide();
                EditMarkSystemView?.Hide();
                currentObject = editTreeView.CurrentObject;
                EditTreeViewNodeChanged(sender);
            }
        }
        private void ModifyProperties(IEditPropertiesView sender)
        {
            propertiesButton.Text = "Параметры" + (sender.IsSaved ? "" : "*");
            unsavedPropertiesTip.Active = !sender.IsSaved;
        }
        private void ModifyMarkSystem(IEditMarkSystemPropertiesView sender)
        {
            markSystemButton.Text = "Система оценивания" + (sender.IsSaved ? "" : "*");
            unsavedMarkSystemToolTip.Active = !sender.IsSaved;
        }

        private void TabStopClick(object sender, EventArgs e)
        {
            Button senderButton = (Button)sender;
            senderButton.BackColor = SystemColors.ControlLight;
            disabledButton.BackColor = Color.FromArgb(171, 31, 47);
            disabledButton.Enabled = true;
            senderButton.Enabled = false;
            disabledButton = senderButton;
            switch (int.Parse(senderButton.Tag.ToString()))
            {
                case 0:
                    HideAllProperties();
                    EditPropertiesView?.Show();
                    break;
                case 1:
                    HideAllProperties();
                    EditMarkSystemView?.Show();
                    break;
                case 2:
                    OpenContentPanel();
                    break;
                case 3:
                    HideAllProperties();
                    EditSavingView.Show();
                    break;
            }
        }
        private void OpenContentPanel()
        {
            HideAllProperties();
            if (EditTreeView.CurrentObject == null)
            {
                if (EditTreeView.CurrentSection == Section.Themes)
                    EditThemesView?.Show();
                else if (EditTreeView.CurrentSection == Section.Tickets)
                    EditTicketsView?.Show();
            }
            else
            {
                if (EditTreeView.CurrentObject is ThemeBuilder)
                    EditThemeView?.Show();
                else if (EditTreeView.CurrentObject is TicketBuilder)
                    EditTicketView?.Show();
                else if (EditTreeView.CurrentObject is QuestionGroupBuilder)
                    EditQuestionGroupView?.Show();
                else if (EditTreeView.CurrentObject is QuestionBuilder)
                    EditQuestionView?.Show();
            }
        }
        private void HideAllProperties()
        {
            EditPropertiesView?.Hide();
            EditMarkSystemView?.Hide();
            EditThemesView?.Hide();
            EditTicketsView?.Hide();
            EditThemeView?.Hide();
            EditTicketView?.Hide();
            EditQuestionGroupView?.Hide();
            EditQuestionView?.Hide();
            EditSavingView?.Hide();
        }
        private void EditTreeViewNodeChanged(IEditTreeView sender)
        {
            if (int.Parse(disabledButton.Tag.ToString()) == 2)
                OpenContentPanel();
        }

        private void EditorFormFormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Закрыть редактор экзаменов?", "Выход из окна редактора", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
                e.Cancel = true;
        }
    }
}
