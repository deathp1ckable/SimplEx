using SimplExServer.Builders;
using SimplExServer.Common;
using SimplExServer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplExServer.Presenter
{
    class EditThemePresenter : IntegrablePresenter<EditArgumnet, IEditThemeView>
    {
        private ThemeBuilder currentThemeBuilder;
        public EditThemePresenter(IEditThemeView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.Shown += ViewShown;
            view.ThemeDeleted += ViewThemeDeleted;
            view.Hiden += ViewHiden;
        }
        private void ViewThemeDeleted(IEditThemeView sender)
        {
            Argumnet.ExamBuilder.RemoveTheme(currentThemeBuilder);
            Argumnet.EditTreeView.RefreshThemes();
        }
        private void ViewHiden(IEditThemeView sender)
        {
            if (currentThemeBuilder != null)
                currentThemeBuilder.ThemeName = sender.ThemeName;
        }
        private void ViewShown(IEditThemeView sender)
        {
            currentThemeBuilder = (Argumnet.EditTreeView.CurrentObject as ThemeBuilder);
            if (currentThemeBuilder != null)
            {
                sender.ThemeName = currentThemeBuilder.ThemeName;
                sender.QuestionsCount = Argumnet.ExamBuilder.GetQuestionBuilders().Where(a => ReferenceEquals(a.ThemeBuilder, currentThemeBuilder)).Count();
            }
        }
    }
}
