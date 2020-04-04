using SimplExServer.Builders;
using SimplExServer.View;
using System.ComponentModel;
using System;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace SimplExServer.Controls
{
    public partial class EditSaveControl : UserControl, IEditSavingView
    {
        private IList<TicketBuilder> ticketBuiders;
        private TicketBuilder tempBuilder;
        private int CurrentType { get => ticketsList.SelectedIndex; set => ticketsList.SelectedIndex = value; }
        public TicketBuilder CurrentTicket
        {
            get
            {
                if (ticketBuiders == null || ticketBuiders.Count == 0)
                    return null;
                return ticketBuiders[CurrentType];
            }

            set
            {
                if (ticketBuiders != null)
                {
                    for (int i = 0; i < ticketBuiders.Count; i++)
                        if (ticketBuiders[i] == value)
                        {
                            CurrentType = i;
                            return;
                        }
                    CurrentType = 0;
                }
                else tempBuilder = value;
            }
        }
        public IList<TicketBuilder> TicketBuiders
        {
            get => ticketBuiders;
            set
            {
                ticketBuiders = value;
                ticketsList.Items.Clear();
                for (int i = 0; i < ticketBuiders.Count; i++)
                {
                    ticketsList.Items.Add($"Тема '{ticketBuiders[i].TicketName}'");
                }
                if (tempBuilder != null)
                    CurrentTicket = tempBuilder;
                watchKeyButton.Enabled = true;
                watchTaskButton.Enabled = true;
                setRightAnswerCheck.Enabled = true;
                watchBlankButton.Enabled = true;
                watchClientViewButton.Enabled = true;
                if (ticketBuiders.Count == 0)
                {
                    watchKeyButton.Enabled = false;
                    watchTaskButton.Enabled = false;
                    setRightAnswerCheck.Enabled = false;
                    watchBlankButton.Enabled = false;
                    watchClientViewButton.Enabled = false;
                }
            }
        }
        public bool AllowSave { get => saveButton.Enabled; set => saveButton.Enabled = value; }
        public bool SetRightAnswers { get => setRightAnswerCheck.Checked; }
        public IList<string> Warnings
        {
            get => warningsList.Items.Cast<string>().ToList();
            set
            {
                warningsList.Items.Clear();
                for (int i = 0; i < value.Count; i++)
                    warningsList.Items.Add(value[i]);
                if (value.Count == 0)
                    warningsList.Items.Add("Нет предупреждений.");
            }
        }

        public event ViewActionHandler<IEditSavingView> Saved;
        public event ViewActionHandler<IEditSavingView> SavedDb;
        public event ViewActionHandler<IEditSavingView> WatchKey;
        public event ViewActionHandler<IEditSavingView> WatchTask;
        public event ViewActionHandler<IEditSavingView> WatchBlank;
        public event ViewActionHandler<IEditSavingView> WatchClientView;
        public event ViewActionHandler<IEditSavingView> Shown;
        public event ViewActionHandler<IEditSavingView> Hiden;
        public event ViewActionHandler<IEditSavingView, SaveExamEventArgs> SavedAs;

        public EditSaveControl()
        {
            InitializeComponent();
            warningsList.Items.Add("Нет предупреждений.");
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
        private void SaveButtonClick(object sender, EventArgs e) => Saved?.Invoke(this);
        private void SaveAsButtonClick(object sender, EventArgs e) => saveFileDialog.ShowDialog();
        private void SaveToDbClick(object sender, EventArgs e) => SavedDb?.Invoke(this);
        private void WatchKeyButtonClick(object sender, EventArgs e) => WatchKey?.Invoke(this);
        private void WatchTaskButtonClick(object sender, EventArgs e) => WatchTask?.Invoke(this);
        private void WatchBlankButtonClick(object sender, EventArgs e) => WatchBlank?.Invoke(this);
        private void WatchClientViewButtonClick(object sender, EventArgs e) => WatchClientView?.Invoke(this);
        private void SaveFileDialogFileOk(object sender, CancelEventArgs e) => SavedAs?.Invoke(this, new SaveExamEventArgs(Path.GetFullPath(saveFileDialog.FileName)));
        public void ShowError(string message) => MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
