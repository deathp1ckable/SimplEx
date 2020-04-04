using System;

namespace SimplExServer.View
{
    public interface IEditMarkSystemView : IHideableView
    {
        void CallSaveChanges();
        void CallCancelChanges();
        void MessageWrongData(string reason);
        bool Saved { get; set; }
        event ViewActionHandler<IEditMarkSystemView> SaveChanges;
        event ViewActionHandler<IEditMarkSystemView> CancelChanges;
        event ViewActionHandler<IEditMarkSystemView> Changed;
    }
}