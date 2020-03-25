using SimplExServer.View;
using System;
using System.Windows.Forms;

namespace SimplExServer.Controls
{
    public partial class EditTicketsControl : UserControl,IEditTicketsView
    {
        public EditTicketsControl()
        {
            InitializeComponent();
        }
        public event ViewActionHandler<IEditTicketsView> TicketAdded;
        public void Close() => Dispose();
        private void AddButtonClick(object sender, EventArgs e) => TicketAdded?.Invoke(this);
    }
}
