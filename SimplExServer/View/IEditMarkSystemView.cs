using System;

namespace SimplExServer.View
{
    public interface IEditMarkSystemView : IView
    {
        void Hide();
        void CallSaveChanges();
        void CallCancelChanges();
        void MessageWrongData(string reason);
        bool Saved { get; set; }
        event Action SaveChanges;
        event Action CancelChanges;
        event Action Changed;
    }
}