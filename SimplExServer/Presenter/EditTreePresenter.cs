using SimplExServer.Builders;
using SimplExServer.Common;
using SimplExServer.View;
using System.Collections.Generic;
using System.Linq;

namespace SimplExServer.Presenter
{
    class EditTreePresenter : IntegrablePresenter<ExamBuilder, IEditTreeView>
    {
        private QuestionBuilder CopiedQuestionBuilder;
        private QuestionGroupBuilder CopiedQuestionGroupBuilder;
        public EditTreePresenter(IEditTreeView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.StructureChanged += StructureChanged;
            view.Searched += Searched;
            view.QuestionCopied += ViewQuestionCopied;
            view.QuestionPasted += ViewQuestionPasted;
            view.QuestionGroupCopied += ViewQuestionGroupCopied;
            view.QuestionGroupPasted += ViewQuestionGroupPasted;
        }

        private void ViewQuestionGroupPasted(IEditTreeView sender, QuestionGroupPastedArgs e)
        {
            QuestionGroupBuilder builder;
            if (e.TicketBuilder != null)
                builder = e.TicketBuilder.AddQuestionGroup(CopiedQuestionGroupBuilder.GetDuplicate());
            else
                builder = e.QuestionGroupBuilder.AddQuestionGroup(CopiedQuestionGroupBuilder.GetDuplicate());
            sender.RefreshObject(e.TicketBuilder as object ?? e.QuestionGroupBuilder as object);
            sender.SelectObject(builder);
        }

        private void ViewQuestionGroupCopied(IEditTreeView sender, QuestionGroupCopiedArgs e)
        {
            object builder = e.QuestionBuilder.ParentTicketBuilder as object ?? e.QuestionBuilder.ParentQuestionGroupBuilder as object;
            CopiedQuestionGroupBuilder = e.QuestionBuilder;
            if (e.IsCut)
            {
                CopiedQuestionGroupBuilder.ParentQuestionGroupBuilder?.RemoveQuestionGroup(e.QuestionBuilder);
                CopiedQuestionGroupBuilder.ParentTicketBuilder?.RemoveQuestionGroup(e.QuestionBuilder);
            }
            sender.RefreshObject(builder);
            sender.SelectObject(builder);
        }

        private void ViewQuestionPasted(IEditTreeView sender, QuestionPastedArgs e)
        {
            QuestionBuilder builder = e.QuestionGroupBuilder.AddQuestion(CopiedQuestionBuilder.GetDuplicate());
            sender.RefreshObject(builder.ParentQuestionGroupBuilder);
            sender.SelectObject(builder);
        }
        private void ViewQuestionCopied(IEditTreeView sender, QuestionCopiedArgs e)
        {
            QuestionGroupBuilder builder = e.QuestionBuilder.ParentQuestionGroupBuilder;
            CopiedQuestionBuilder = e.QuestionBuilder;
            if (e.IsCut)
                CopiedQuestionBuilder.ParentQuestionGroupBuilder.RemoveQuestion(e.QuestionBuilder);
            sender.RefreshObject(builder);
            sender.SelectObject(builder);
        }

        private void Searched(IEditTreeView sender)
        {
            List<object> result = new List<object>();
            result.AddRange(sender.ThemeBuilders.Where(a => a.ToString().Contains(sender.SearchText)));
            result.AddRange(sender.TicketBuilders.Where(a => a.ToString().Contains(sender.SearchText)));
            for (int i = 0; i < sender.TicketBuilders.Count; i++)
            {
                result.AddRange(sender.TicketBuilders[i].GetQuestionGroupBuilders().Where(a => a.ToString().Contains(sender.SearchText)));
                result.AddRange(sender.TicketBuilders[i].GetQuestionBuilders().Where(a => a.ToString().Contains(sender.SearchText)));
            }
            sender.SearchResult = result.ToArray();
        }
        private void StructureChanged(IEditTreeView sender, StructChangedArgs e)
        {
            if (e.NewParentGroup != null)
                e.Group.SetParent(e.NewParentGroup);
            else
                e.Group.SetParent(e.Ticket);
        }
        public override void Run(ExamBuilder argument)
        {
            Argument = argument;
            View.ThemeBuilders = Argument.ThemeBuilders;
            View.TicketBuilders = Argument.TicketBuilders;
        }
    }
}
