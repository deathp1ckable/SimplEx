using SimplExServer.View;
using System;
using System.Windows.Forms;

namespace SimplExServer.Controls
{
    public partial class EditThemesControl : UserControl, IEditThemesView
    {
        public int ThemesCount { set => themesCount.Text = "Количество тем: " + value; }

        public event ViewActionHandler<IEditThemesView> ThemeAdded;
        public event ViewActionHandler<IEditThemesView> Shown;

        public EditThemesControl()
        {
            InitializeComponent();
        }
        public new void Show()
        {
            base.Show(); 
            Shown?.Invoke(this);
        }
        public void Close() => Dispose();
        private void AddButtonClick(object sender, EventArgs e) => ThemeAdded?.Invoke(this);
    }
}
