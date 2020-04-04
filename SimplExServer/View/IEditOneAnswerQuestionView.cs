using System.Collections.Generic;
namespace SimplExServer.View
{
    public interface IEditOneAnswerQuestionView : IHideableView
    {
        string QuestionText { get; set; }
        string Devider { get; set; }
        string Letters { get; set; }
        double Points { get; set; }
        IList<string> Answers { get; set; }
        int RightAnswerIndex { get; set; }

        event ViewActionHandler<IEditOneAnswerQuestionView> Saved;
        event ViewActionHandler<IEditOneAnswerQuestionView> Changed;
        event ViewActionHandler<IEditOneAnswerQuestionView> Shown;
        event ViewActionHandler<IEditOneAnswerQuestionView> Hiden;

        void AskForSaving();
    }
}
