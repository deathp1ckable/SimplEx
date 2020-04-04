using System;
using System.Collections.Generic;

namespace SimplExServer.View
{
    public interface IEditQuestionGroupView : IHideableView
    {
        string GroupName { get; set; }
        Type QuestionType { get; set; }
        IList<Type> QuestionTypes { set; }
        int GroupsCount { set; }
        int QuestionsCount { set; }

        event ViewActionHandler<IEditQuestionGroupView> GroupAdded;
        event ViewActionHandler<IEditQuestionGroupView> Saved;
        event ViewActionHandler<IEditQuestionGroupView> QuestionAdded;
        event ViewActionHandler<IEditQuestionGroupView> Import;
        event ViewActionHandler<IEditQuestionGroupView> Deleted;
        event ViewActionHandler<IEditQuestionGroupView> Changed;
        event ViewActionHandler<IEditQuestionGroupView> Shown;
        event ViewActionHandler<IEditQuestionGroupView> Hiden;

        void AskForSaving();
    }
}
