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
        event ViewActionHandler<IEditMarkSystemPropertiesView> SaveChanges;
        event ViewActionHandler<IEditMarkSystemPropertiesView> CancelChanges;
        event ViewActionHandler<IEditMarkSystemPropertiesView> Changed;
        event ViewActionHandler<IEditMarkSystemPropertiesView> MarkSystemTypeChanged;
    }
}