using SimplExServer.Builders;
using SimplExServer.Common;
using SimplExServer.View;
using System.Linq;

namespace SimplExServer.Presenter
{
    class EditThemePresenter : IntegrablePresenter<EditContentArgumnet, IEditThemeView>
    {
        private ThemeBuilder currentThemeBuilder;
        private bool isSaved = true;
        private bool isHiding;
        public EditThemePresenter(IEditThemeView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.Shown += ViewShown;
            view.Deleted += ViewThemeDeleted;
            view.Hiden += ViewHiden;
            view.Saved += ViewSaved;
            view.Changed += ViewChanged;
        }
        private void ViewChanged(IEditThemeView sender) => isSaved = false;
        private void ViewSaved(IEditThemeView sender)
        {
            isSaved = true;
            if (currentThemeBuilder != null)
            {
                currentThemeBuilder.ThemeName = sender.ThemeName;
                Argument.EditTreeView.RefreshObject(currentThemeBuilder);
                if (!isHiding)
                    Argument.EditTreeView.SelectObject(currentThemeBuilder);
            }
        }
        private void ViewThemeDeleted(IEditThemeView sender)
        {
            isSaved = true;
            if (currentThemeBuilder != null)
            {
                currentThemeBuilder.ParentExamBuilder.RemoveTheme(currentThemeBuilder);
                Argument.EditTreeView.RefreshThemes();
                Argument.EditTreeView.SelectObject(Section.Themes);
            }
            currentThemeBuilder = null;
            sender.Hide();
        }
        private void ViewHiden(IEditThemeView sender)
        {
            if (!isHiding)
            {
                if (!isSaved)
                {
                    isHiding = true;
                    View.Show();
                    sender.AskForSaving();
                    View.Hide();
                    isHiding = false;
                }
                currentThemeBuilder = null;
                isSaved = true;
            }
        }
        private void ViewShown(IEditThemeView sender)
        {
            if (!isHiding)
            {
                currentThemeBuilder = Argument.EditTreeView.CurrentObject as ThemeBuilder;
                if (currentThemeBuilder != null)
                {
                    sender.ThemeName = currentThemeBuilder.ThemeName;
                    sender.QuestionsCount = currentThemeBuilder.ParentExamBuilder.GetQuestionBuilders().Where(a => ReferenceEquals(a.ThemeBuilder, currentThemeBuilder)).Count();
                }
                isSaved = true;
            }
        }
    }
}
