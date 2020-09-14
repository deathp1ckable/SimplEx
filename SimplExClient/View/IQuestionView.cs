using System;

namespace SimplExClient.View
{
    public interface IQuestionView : IHideableView
    {
        IOneAnswerQuestionView OneAnswerQuestionView { get; set; }

        string QuestionTitle { set; }
        string ThemeName { set; }
        double Points { set; }

        bool NextExisting { set; }
        bool PrevExisting { set; }

        event ViewActionHandler<IQuestionView> Shown;
        event ViewActionHandler<IQuestionView> NextQuestion;
        event ViewActionHandler<IQuestionView> PrevQuestion;

        void Invoke(Action action);
    }

}

