using SimplExServer.Builders;
using SimplExServer.View;
using System;
using System.Windows.Forms;
namespace SimplExServer.Controls
{
    public partial class EditThemeControl : UserControl, IEditThemeView
    {

        public event ViewActionHandler<IEditThemeView> Saved;
        public event ViewActionHandler<IEditThemeView> Deleted;
        public event ViewActionHandler<IEditThemeView> Changed;
        public event ViewActionHandler<IEditThemeView> Shown;
        public event ViewActionHandler<IEditThemeView> Hiden;

        public EditThemeControl()
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
        public string ThemeName { get => themeBox.Text; set => themeBox.Text = value; }
        public int QuestionsCount { set => countLabel.Text = "Количество вопросов: " + value; }

        public void Close() => Dispose();
        private void DeleteButtonClick(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить тему?", "Удаление темы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
                Deleted?.Invoke(this);
        }

        private void SaveButtonClick(object sender, EventArgs e) => Saved?.Invoke(this);
        public void AskForSaving()
        {
            DialogResult dialogResult = MessageBox.Show("Сохранить тему?", "Изменения не сохранены", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
                Saved?.Invoke(this);
        }
        private void ThemeBoxTextChanged(object sender, EventArgs e) => Changed?.Invoke(this);
        public void Save() => Saved?.Invoke(this);
    }
}
