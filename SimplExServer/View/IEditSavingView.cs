using SimplExServer.Builders;
using System.Collections.Generic;

namespace SimplExServer.View
{
    public interface IEditSavingView : IHideableView
    {
        TicketBuilder CurrentTicket { get; set; }
        IList<TicketBuilder> TicketBuiders { get; set; }
        IList<string> Warnings { get; set; }
        bool AllowSave { get; set; }
        bool SetRightAnswers { get; }

        event ViewActionHandler<IEditSavingView> Shown;
        event ViewActionHandler<IEditSavingView> Hiden;
        event ViewActionHandler<IEditSavingView> Saved;
        event ViewActionHandler<IEditSavingView> SavedDb;
        event ViewActionHandler<IEditSavingView> WatchKey;
        event ViewActionHandler<IEditSavingView> WatchTask;
        event ViewActionHandler<IEditSavingView> WatchBlank;
        event ViewActionHandler<IEditSavingView, SaveExamEventArgs> SavedAs;

        void ShowError(string message);
    }
}
