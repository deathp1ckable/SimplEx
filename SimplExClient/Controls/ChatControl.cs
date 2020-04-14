using SimplExClient.View;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimplExClient.Controls
{
    public partial class ChatControl : UserControl, IChatView
    {
        private IList<string> messages;

        public IList<string> Messages
        {
            get => messages;
            set
            {
                if (EnableChat)
                {
                    messages = value;
                    chatBox.Text = string.Empty;
                    for (int i = 0; i < messages.Count; i++)
                        chatBox.Text += messages[i] + Environment.NewLine;
                    chatBox.Text = EnableChat ? chatBox.Text : "Чат неактивен.";
                }
            }
        }
        public string Message
        {
            get => textBox.Text; set
            {
                if (EnableChat)
                    textBox.Text = value;
            }
        }
        public bool EnableChat
        {
            get => messageLabel.Enabled;
            set
            {
                chatLabel.Enabled = chatBox.Enabled = messageLabel.Enabled = textBox.Enabled = sendButton.Enabled = chatLabel.Enabled = value;
                chatBox.Text = value ? chatBox.Text : "Чат неактивен.";
            }
        }
        public bool IsActive
        {
            get => messageLabel.Enabled;
            set
            {
                chatLabel.Enabled = chatBox.Enabled = messageLabel.Enabled = textBox.Enabled = sendButton.Enabled = chatLabel.Enabled = value;
            }
        }
        public event ViewActionHandler<IChatView> Shown;
        public event ViewActionHandler<IChatView> Hiden;
        public event ViewActionHandler<IChatView> MessageSended;

        public ChatControl()
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
        public void Invoke(Action action)
        {
            try
            {
                base.Invoke(action);
            }
            catch { }
        }

        private void SendButtonClick(object sender, EventArgs e)
        {
            MessageSended?.Invoke(this);
            textBox.Text = string.Empty;
            sendButton.Enabled = textBox.Text.Length != 0;
        }

        private void TextBoxTextChanged(object sender, EventArgs e)
        {
            sendButton.Enabled = textBox.Text.Length != 0;
        }
    }
}
