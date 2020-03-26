using SimplExServer.Builders;
using SimplExServer.Common;
using SimplExServer.View;
namespace SimplExServer.Presenter
{
    class EditMainPresenter : Presenter<ExamBuilder, IEditMainView>
    {
        public EditMainPresenter(IEditMainView view, IApplicationController applicationController) : base(view, applicationController) { }
        public override void Run(ExamBuilder argumnet)
        {
            Argument = argumnet;
            ApplicationController.Run<EditExamPresenter, ExamBuilder>(Argument).Integrate(View.SetEditPropertiesView);
            ApplicationController.Run<EditMarkSystemPresenter, ExamBuilder>(Argument).Integrate(View.SetEditMarkSystemPropertiesView);
            ApplicationController.Run<EditTreePresenter, ExamBuilder>(Argument).Integrate(View.SetEditTreeView);
            ApplicationController.Run<EditThemesPresenter, EditArgumnet>(new EditArgumnet(Argument, View.EditTreeView)).Integrate(View.SetEditThemesView);
            ApplicationController.Run<EditTicketsPresenter, EditArgumnet>(new EditArgumnet(Argument, View.EditTreeView)).Integrate(View.SetEditTicketsView);
            ApplicationController.Run<EditThemePresenter, EditArgumnet>(new EditArgumnet(Argument, View.EditTreeView)).Integrate(View.SetEditThemeView);
            if (Argument.Instance.CreationDate == null)
                View.EditPropertiesView.Saved = false;
            View.CreationDate = Argument.CreationDate.Value;
            View.LastChangeDate = Argument.LastChangeDate.Value;
            View.QuestionCount = Argument.GetQuestionBuilders().Length;
            View.Show();
        }
    }
}
