using SimplExModel.Model;
using SimplExServer.Service;
using System;
using System.Collections.Generic;
namespace SimplExServer.View
{
    public interface IImportView : IHideableView
    {
        bool IsExamLoading { get; set; }
        bool IsListLoading { get; set; }
        string DbInfoText { get; set; }
        string SearchText { get; set; }
        IExamSaver CurrentExamSaver { get; set; }
        Question CurrentQuestion { get; set; }
        IList<IExamSaver> ExamSavers { get; set; }
        IList<Question> Questions { get; set; }

        IPasswordEnterView PasswordEnterView { get; set; }

        event ViewActionHandler<IImportView> ViewShown;
        event ViewActionHandler<IImportView> Imported;
        event ViewActionHandler<IImportView> Searched;
        event ViewActionHandler<IImportView> ViewClosed;
        event ViewActionHandler<IImportView> SelectedExamChanged;
        event ViewActionHandler<IImportView> ConnectionAsked;
        event ViewActionHandler<IImportView, OpenExamEventArgs> FileOpened;

        void ShowError(string message);
        void Invoke(Action action);
    }
}
