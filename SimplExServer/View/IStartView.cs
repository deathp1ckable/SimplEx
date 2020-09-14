using SimplExModel.Model;
using SimplExServer.Service;
using System;
using System.Collections.Generic;

namespace SimplExServer.View
{
    public interface IStartView : IHideableView
    {
        bool IsExamLoading { get; set; }
        bool IsListLoading { get; set; }
        bool SetRightAnswer { get; set; }
        string DbInfoText { get; set; }
        IExamSaver CurrentExamSaver { get; set; }
        Exam CurrentExam { get; set; }
        Ticket CurrentTicket { get; set; }
        ExecutionResult CurrentExecutionResult { get; set; }
        IList<IExamSaver> ExamSavers { get; set; }
        IPasswordEnterView PasswordEnterView { get; set; }

        event ViewActionHandler<IStartView> ViewShown;
        event ViewActionHandler<IStartView> ViewHiden;

        event ViewActionHandler<IStartView> ConnectionAsked;

        event ViewActionHandler<IStartView> ExamCreated;
        event ViewActionHandler<IStartView, OpenExamEventArgs> FileOpened;

        event ViewActionHandler<IStartView> WatchResult;
        event ViewActionHandler<IStartView> DeleteResult;

        event ViewActionHandler<IStartView> WatchTask;
        event ViewActionHandler<IStartView> WatchBlank;

        event ViewActionHandler<IStartView> SessionStarted;
        event ViewActionHandler<IStartView> ExamEdited;
        event ViewActionHandler<IStartView> ExamDeleted;

        event ViewActionHandler<IStartView> ExamSelectionChanged;
        void ShowError(string message);
        void RefreshTickets();
        void RefreshResults();
        void Invoke(Action action);
    }
}
