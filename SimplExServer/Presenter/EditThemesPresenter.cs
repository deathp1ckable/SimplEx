using SimplExServer.Builders;
using SimplExServer.Common;
using SimplExServer.View;

namespace SimplExServer.Presenter
{
    class EditThemesPresenter : IntegrablePresenter<EditArgumnet, IEditThemesView>
    {
        public EditThemesPresenter(IEditThemesView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.ThemeAdded += ViewThemeAdded;
        }
        private void ViewThemeAdded(IEditThemesView sender)
        {
            ThemeBuilder builder = Argument.ExamBuilder.AddTheme("Новая Тема");
            Argument.EditTreeView.RefreshThemes();
            Argument.EditTreeView.SelectObject(builder);
        }
    }
    class EditArgumnet
    {
        public ExamBuilder ExamBuilder { get; private set; }
        public IEditTreeView EditTreeView { get; private set; }
        public EditArgumnet(ExamBuilder examBuilder, IEditTreeView editTreeView)
        {
            ExamBuilder = examBuilder;
            EditTreeView = editTreeView;
        }
    }
}
