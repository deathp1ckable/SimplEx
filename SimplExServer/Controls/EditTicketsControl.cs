using SimplExServer.View;
using System;
using System.Windows.Forms;

namespace SimplExServer.Controls
{
    public partial class EditTicketsControl : UserControl, IEditTicketsView
    {
        public int TicketsCount { set => ticketsCount.Text = "Количество билетов: " + value; }
        public EditTicketsControl()
        {
            InitializeComponent();
        }
        public event ViewActionHandler<IEditTicketsView> TicketAdded;
        public event ViewActionHandler<IEditTicketsView> Shown;
        public new void Show()
        {
            base.Show();
            Shown?.Invoke(this);
        }
        public void Close() => Dispose();
        private void AddButtonClick(object sender, EventArgs e) => TicketAdded?.Invoke(this);
    }
}
