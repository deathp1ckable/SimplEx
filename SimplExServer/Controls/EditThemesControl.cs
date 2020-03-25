using SimplExServer.View;
using System;
using System.Windows.Forms;

namespace SimplExServer.Controls
{
    public partial class EditThemesControl : UserControl, IEditThemesView
    {
        public event ViewActionHandler<IEditThemesView> ThemeAdded;
        public EditThemesControl()
        {
            InitializeComponent();
        }       
        public void Close() => Dispose();
        private void AddButtonClick(object sender, EventArgs e) => ThemeAdded?.Invoke(this);
    }
}
