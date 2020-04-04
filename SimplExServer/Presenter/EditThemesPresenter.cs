using SimplExServer.Builders;
using SimplExServer.Common;
using SimplExServer.View;
namespace SimplExServer.Presenter
{
    class EditThemesPresenter : IntegrablePresenter<EditContentArgumnet, IEditThemesView>
    {
        public EditThemesPresenter(IEditThemesView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.ThemeAdded += ViewThemeAdded;
            view.Shown += ViewShown;
        }
        private void ViewShown(IEditThemesView sender) => sender.ThemesCount = Argument.ExamBuilder.ThemeBuilders.Count;
        private void ViewThemeAdded(IEditThemesView sender)
        {
            ThemeBuilder builder = Argument.ExamBuilder.AddTheme("Новая тема");
            Argument.EditTreeView.RefreshThemes();
            Argument.EditTreeView.SelectObject(builder);
        }
    }
}
