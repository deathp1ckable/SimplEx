using SimplExServer.Builders;
using SimplExServer.Common;
using SimplExServer.View;
using System.Linq;

namespace SimplExServer.Presenter
{
    class EditThemePresenter : IntegrablePresenter<EditArgumnet, IEditThemeView>
    {
        private ThemeBuilder currentThemeBuilder;
        private bool isSaved = true;
        public EditThemePresenter(IEditThemeView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.Shown += ViewShown;
            view.ThemeDeleted += ViewThemeDeleted;
            view.Hiden += ViewHiden;
            view.Saved += ViewSaved;
            view.Changed += ViewChanged;
        }

        private void ViewChanged(IEditThemeView sender) => isSaved = false;
        private void ViewSaved(IEditThemeView sender)
        {
            if (currentThemeBuilder != null)
            {
                currentThemeBuilder.ThemeName = sender.ThemeName;
                Argument.EditTreeView.RefreshObject(currentThemeBuilder);
            }
            isSaved = true;
        }
        private void ViewThemeDeleted(IEditThemeView sender)
        {
            isSaved = true;
            if (currentThemeBuilder != null)
            {
                Argument.ExamBuilder.RemoveTheme(currentThemeBuilder);
                Argument.EditTreeView.RefreshThemes();
                Argument.EditTreeView.SelectObject(Section.Themes);
            }
            currentThemeBuilder = null;
            View.Hide();
        }
        private void ViewHiden(IEditThemeView sender)
        {
            if (!isSaved)
                sender.AskForSaving();
            currentThemeBuilder = null;
            isSaved = true;
        }
        private void ViewShown(IEditThemeView sender)
        {
            currentThemeBuilder = (Argument.EditTreeView.CurrentObject as ThemeBuilder);
            if (currentThemeBuilder != null)
            {
                sender.ThemeName = currentThemeBuilder.ThemeName;
                sender.QuestionsCount = Argument.ExamBuilder.GetQuestionBuilders().Where(a => ReferenceEquals(a.ThemeBuilder, currentThemeBuilder)).Count();
            }
            isSaved = true;
        }
    }
}
