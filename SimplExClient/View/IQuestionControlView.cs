using SimplExModel.Model;

namespace SimplExClient.View
{
    public interface IQuestionControlView : IHideableView
    {
        Answer Answer { get; set; }

        event ViewActionHandler<IQuestionControlView> Shown;
        event ViewActionHandler<IQuestionControlView> Hiden;
        event ViewActionHandler<IQuestionControlView> Answered;
        event ViewActionHandler<IQuestionControlView> AnswerCanceled;
        event ViewActionHandler<IQuestionControlView> AnswerChanged;

        void AskForSaving();
    }

}

