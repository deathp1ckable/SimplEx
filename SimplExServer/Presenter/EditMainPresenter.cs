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
            Argumnet = argumnet;
            ApplicationController.Run<EditExamPresenter, ExamBuilder>(Argumnet).Integrate(View.SetEditPropertiesView);
            ApplicationController.Run<EditMarkSystemPresenter, ExamBuilder>(Argumnet).Integrate(View.SetEditMarkSystemPropertiesView);
            ApplicationController.Run<EditTreePresenter, ExamBuilder>(Argumnet).Integrate(View.SetEditTreeView);
            ApplicationController.Run<EditThemesPresenter, EditArgumnet>(new EditArgumnet(Argumnet, View.EditTreeView)).Integrate(View.SetEditThemesView);
            ApplicationController.Run<EditTicketsPresenter, EditArgumnet>(new EditArgumnet(Argumnet, View.EditTreeView)).Integrate(View.SetEditTicketsView);
            ApplicationController.Run<EditThemePresenter, EditArgumnet>(new EditArgumnet(Argumnet, View.EditTreeView)).Integrate(View.SetEditThemeView);
            if (Argumnet.Instance.CreationDate == null)
                View.EditPropertiesView.Saved = false;
            View.CreationDate = Argumnet.CreationDate.Value;
            View.LastChangeDate = Argumnet.LastChangeDate.Value;
            View.QuestionCount = Argumnet.GetQuestionBuilders().Length;
            View.Show();
        }
    }
}
