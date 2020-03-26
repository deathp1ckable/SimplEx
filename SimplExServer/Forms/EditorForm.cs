using SimplExServer.Builders;
using SimplExServer.View;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimplExServer
{
    public partial class EditorForm : Form, IEditMainView
    {
        private ApplicationContext context;
        private Button disabledButton;
        private int questionCount;
        private DateTime lastChangeDate;
        private DateTime creationDate;
        public IEditMarkSystemPropertiesView MarkSystemPropertiesView { get; private set; }
        public IEditPropertiesView EditPropertiesView { get; private set; }
        public IEditThemesView EditThemesView { get; private set; }
        public IEditThemeView EditThemeView { get; private set; }
        public IEditTicketsView EditTicketsView { get; private set; }
        public IEditTreeView EditTreeView { get; private set; }
        public DateTime CreationDate
        {
            get => creationDate;
            set
            {
                creationDate = value;
                creationDateLabel.Text = "Дата создания: " + value.ToString("yy:MM:dd");
            }
        }
        public DateTime LastChangeDate
        {
            get => lastChangeDate;
            set
            {
                lastChangeDate = value;
                lastChangeDateLabel.Text = "Дата изменения: " + value.ToString("yy:MM:dd");
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
            context.MainForm = this;
            base.Show();
        }
        public void SetEditPropertiesView(IEditPropertiesView view)
        {
            view.Changed += ModifyProperties;
            view.CancelChanges += ModifyProperties;
            view.SaveChanges += ModifyProperties;
            if (EditPropertiesView != null)
            {
                EditPropertiesView.Changed -= ModifyProperties;
                EditPropertiesView.CancelChanges -= ModifyProperties;
                EditPropertiesView.SaveChanges -= ModifyProperties;
            }
            EditPropertiesView = view;
            ModifyProperties(view);
            UserControl control = (UserControl)EditPropertiesView;
            control.Parent = propertiesPanel;
            control.Size = propertiesPanel.Size;
            control.Location = new Point(0, 0);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }
        public void SetEditMarkSystemPropertiesView(IEditMarkSystemPropertiesView view)
        {
            view.CancelChanges += ModifyMarkSystem;
            view.SaveChanges += ModifyMarkSystem;
            view.Changed += ModifyMarkSystem;
            if (MarkSystemPropertiesView != null)
            {
                MarkSystemPropertiesView.CancelChanges -= ModifyMarkSystem;
                MarkSystemPropertiesView.SaveChanges -= ModifyMarkSystem;
                MarkSystemPropertiesView.Changed -= ModifyMarkSystem;
            }
            MarkSystemPropertiesView = view;
            ModifyMarkSystem(view);
            UserControl control = (UserControl)MarkSystemPropertiesView;
            control.Parent = propertiesPanel;
            control.Size = propertiesPanel.Size;
            control.Location = new Point(0, 0);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }
        public void SetEditTreeView(IEditTreeView view)
        {
            if (EditTreeView != null)
            {
                EditTreeView.GoToProperties -= EditTreeViewGoToProperties;
                EditTreeView.NodeChanged -= EditTreeViewNodeChanged;
            }
            EditTreeView = view;
            EditTreeView.GoToProperties += EditTreeViewGoToProperties;
            EditTreeView.NodeChanged += EditTreeViewNodeChanged;
            UserControl control = (UserControl)EditTreeView;
            control.Parent = treePanel;
            control.Size = treePanel.Size;
            control.Location = new Point(0, 0);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }
        public void SetEditThemesView(IEditThemesView view)
        {
            EditThemesView = view;
            UserControl control = (UserControl)EditThemesView;
            control.Parent = propertiesPanel;
            control.Size = propertiesPanel.Size;
            control.Location = new Point(0, 0);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }
        public void SetEditThemeView(IEditThemeView view)
        {
            EditThemeView = view;
            UserControl control = (UserControl)EditThemeView;
            control.Parent = propertiesPanel;
            control.Size = propertiesPanel.Size;
            control.Location = new Point(0, 0);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }
        public void SetEditTicketsView(IEditTicketsView view)
        {
            EditTicketsView = view;
            UserControl control = (UserControl)EditTicketsView;
            control.Parent = propertiesPanel;
            control.Size = propertiesPanel.Size;
            control.Location = new Point(0, 0);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void EditTreeViewGoToProperties(IEditTreeView sender)
        {
            disabledButton.BackColor = Color.FromArgb(171, 31, 47);
            disabledButton.Enabled = true;
            disabledButton = contentButton;
            disabledButton.BackColor = SystemColors.ControlLight;
            disabledButton.Enabled = false;
            EditPropertiesView?.Hide();
            MarkSystemPropertiesView?.Hide();
            EditTreeViewNodeChanged(sender);
        }
        private void ModifyProperties(IEditPropertiesView sender)
        {
            propertiesButton.Text = "Параметры" + (sender.Saved ? "" : "*");
            unsavedPropertiesTip.Active = !sender.Saved;
        }
        private void ModifyMarkSystem(IEditMarkSystemPropertiesView sender)
        {
            markSystemButton.Text = "Система оценивания" + (sender.Saved ? "" : "*");
            unsavedMarkSystemToolTip.Active = !sender.Saved;
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
                    MarkSystemPropertiesView?.Show();
                    break;
                case 2:
                    OpenPropertiesPanel();
                    break;
                case 3:
                    HideAllProperties();
                    break;
            }
        }

        private void OpenPropertiesPanel()
        {
            HideAllProperties();
            if (EditTreeView.CurrentObject == null)
            {
                if (EditTreeView.CurrentSection == Section.Themes)
                    EditThemesView.Show();
                else if (EditTreeView.CurrentSection == Section.Tickets)
                    EditTicketsView.Show();
            }
            else
            {
                if (EditTreeView.CurrentObject is ThemeBuilder)
                    EditThemeView.Show();
            }
        }
        private void HideAllProperties()
        {
            EditPropertiesView?.Hide();
            MarkSystemPropertiesView?.Hide();
            EditThemesView?.Hide();
            EditTicketsView?.Hide();
            EditThemeView.Hide();
        }
        private void EditTreeViewNodeChanged(IEditTreeView sender)
        {
            if (int.Parse(disabledButton.Tag.ToString()) == 2)
                OpenPropertiesPanel();
        }
    }
}
