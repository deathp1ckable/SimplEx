using SimplExServer.Builders;
using System;
using System.Collections.Generic;

namespace SimplExServer.View
{
    public interface IEditQuestionView : IHideableView
    {
        int QuestionNumber { set; }
        Type QuestionType { set; }
        IList<ThemeBuilder> Themes { set; }
        ThemeBuilder Theme { get; set; }

        IEditOneAnswerQuestionView EditOneAnswerQuestionView { get; set; }

        event ViewActionHandler<IEditQuestionView> ThemeChanged;
        event ViewActionHandler<IEditQuestionView> Deleted;
        event ViewActionHandler<IEditQuestionView> Shown;
        event ViewActionHandler<IEditQuestionView> Hiden;
    }
}
