using System;
using System.Collections.Generic;

namespace SimplExClient.View
{
    public interface IView
    {
        void Show();
        void Close();
    }
    public interface IOneAnswerQuestionView : IHideableView
    {
        string QuestionText { get; set; }
        string Devider { get; set; }
        string Letters { get; set; }
        IList<string> Answers { get; set; }
        string Answer { get; set; }

        event ViewActionHandler<IOneAnswerQuestionView> Saved;
        event ViewActionHandler<IOneAnswerQuestionView> Answered;
    }
    public delegate void ViewActionHandler<TViewSender>(TViewSender sender) where TViewSender : IView;
    public delegate void ViewActionHandler<TViewSender, TEventArgs>(TViewSender sender, TEventArgs e) where TViewSender : IView where TEventArgs : EventArgs;
}

