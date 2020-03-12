using SimplExServer.Controls;
using SimplExServer.Model;
using SimplExServer.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SimplExServer
{
    public partial class EditorForm : Form, IEditMainView
    {
        private ApplicationContext context;
        private Button disabledButton;
        private double maxPoints;
        private int questionCount;
        private DateTime lastChangeDate;
        private DateTime creationDate;
        public IEditMarkSystemPropertiesView MarkSystemPropertiesView { get; private set; }
        public IEditPropertiesView EditPropertiesView { get; private set; }
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
        public double MaxPoints
        {
            get => maxPoints;
            set
            {
                maxPoints = value;
                maxPointsLabel.Text = "Максимальный бал: " + value;
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
            ModifyProperties();
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
            ModifyMarkSystem();
            UserControl control = (UserControl)MarkSystemPropertiesView;
            control.Parent = propertiesPanel;
            control.Size = propertiesPanel.Size;
            control.Location = new Point(0, 0);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }
        public void SetEditTreeView(IEditTreeView view)
        {
            EditTreeView = view;
            UserControl control = (UserControl)EditTreeView;
            control.Parent = treePanel;
            control.Size = treePanel.Size;
            control.Location = new Point(0, 0);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }
        private void ModifyProperties()
        {
            propertiesButton.Text = "Параметры" + (EditPropertiesView.Saved ? "" : "*");
            unsavedPropertiesTip.Active = !EditPropertiesView.Saved;
        }
        private void ModifyMarkSystem()
        {
            markSystemButton.Text = "Система оценивания" + (MarkSystemPropertiesView.Saved ? "" : "*");
            unsavedMarkSystemToolTip.Active = !MarkSystemPropertiesView.Saved;
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
                    EditPropertiesView?.Show();
                    MarkSystemPropertiesView?.Hide();
                    break;
                case 1:
                    EditPropertiesView?.Hide();
                    MarkSystemPropertiesView?.Hide();
                    break;
                case 2:
                    EditPropertiesView?.Hide();
                    MarkSystemPropertiesView?.Show();
                    break;
                case 3:
                    EditPropertiesView?.Hide();
                    MarkSystemPropertiesView?.Hide();
                    break;
            }
        }
    }
}
