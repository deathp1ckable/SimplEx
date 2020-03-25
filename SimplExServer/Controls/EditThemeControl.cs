using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimplExServer.View;

namespace SimplExServer.Controls
{
    public partial class EditThemeControl : UserControl, IEditThemeView
    {
        public event ViewActionHandler<IEditThemeView> ThemeDeleted;
        public event ViewActionHandler<IEditThemeView> Shown;
        public event ViewActionHandler<IEditThemeView> Hiden;
        public EditThemeControl()
        {
            InitializeComponent();
        }
        public new void Show()
        {
            Shown?.Invoke(this);
            base.Show();
        }
        public new void Hide()
        {
            Hiden?.Invoke(this);
            base.Hide();
        }
        public string ThemeName { get => themeBox.Text; set => themeBox.Text = value; }
        public int QuestionsCount { set => countLabel.Text = "Количество вопросов: " + value; }

        public void Close() => Dispose();

        private void DeleteButtonClick(object sender, EventArgs e) => ThemeDeleted?.Invoke(this);
    }
}
