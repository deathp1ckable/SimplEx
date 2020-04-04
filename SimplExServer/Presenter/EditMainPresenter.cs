using SimplExServer.Builders;
using SimplExServer.Common;
using SimplExServer.Services.DatabaseHandling;
using SimplExServer.View;
using System;
using System.Collections.Generic;

namespace SimplExServer.Presenter
{
    class EditMainPresenter : Presenter<EditArgumnet, IEditMainView>
    {
        private ExamBuilder ExamBuilder;
        public EditMainPresenter(IEditMainView view, IApplicationController applicationController) : base(view, applicationController) { }
        public override void Run(EditArgumnet argument)
        {
            Argument = argument;
            ExamBuilder = Argument.ExamBuilder;

            View.EditPropertiesView = ApplicationController.Run<EditExamPresenter, ExamBuilder>(ExamBuilder).View;
            View.EditMarkSystemView = ApplicationController.Run<EditMarkSystemPresenter, ExamBuilder>(ExamBuilder).View;
            View.EditTreeView = ApplicationController.Run<EditTreePresenter, ExamBuilder>(ExamBuilder).View;

            EditContentArgumnet editArgumnet = new EditContentArgumnet(ExamBuilder, View.EditTreeView);

            View.EditThemesView = ApplicationController.Run<EditThemesPresenter, EditContentArgumnet>(editArgumnet).View;
            View.EditTicketsView = ApplicationController.Run<EditTicketsPresenter, EditContentArgumnet>(editArgumnet).View;
            View.EditThemeView = ApplicationController.Run<EditThemePresenter, EditContentArgumnet>(editArgumnet).View;
            View.EditTicketView = ApplicationController.Run<EditTicketPresenter, EditContentArgumnet>(editArgumnet).View;
            View.EditQuestionGroupView = ApplicationController.Run<EditQuestionGroupPresenter, EditContentArgumnet>(editArgumnet).View;
            View.EditQuestionView = ApplicationController.Run<EditQuestionPresenter, EditContentArgumnet>(editArgumnet).View;

            View.EditSavingView = ApplicationController.Run<EditSavingPresenter, EditArgumnet>(Argument).View;

            View.CreationDate = ExamBuilder.CreationDate.Value;
            View.LastChangeDate = ExamBuilder.LastChangeDate.Value;
            View.QuestionCount = ExamBuilder.GetQuestionBuilders().Length;
            View.EditTreeView.Refreshed += EditTreeViewRefreshed;
            View.Show();
        }
        private void EditTreeViewRefreshed(IEditTreeView sender) => View.QuestionCount = ExamBuilder.GetQuestionBuilders().Length;
    }
}
