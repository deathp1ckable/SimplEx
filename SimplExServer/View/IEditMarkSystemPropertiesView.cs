using System;
namespace SimplExServer.View
{
    public interface IEditMarkSystemPropertiesView : IView
    {
        Type MarkSystemType { get; set; }
        Type[] MarkSystemTypes { get; set; }
        string Description { get; set; }
        bool Saved { get; set; }
        IEditMarkSystemView EditMarkSystemView { get; }
        void SetEditMarkSystemView(IEditMarkSystemView view);
        void Hide();
        event Action SaveChanges;
        event Action CancelChanges;
        event Action Changed;
        event Action MarkSystemTypeChanged;
    }
}