using System;

namespace SimplExServer.View
{
    public interface IEditMainView : IView
    {
        DateTime CreationDate { get; set; }
        DateTime LastChangeDate { get; set; }
        int QuestionCount { get; set; }
        double MaxPoints { get; set; }
        IEditPropertiesView EditPropertiesView { get; }
        IEditMarkSystemPropertiesView MarkSystemPropertiesView { get; }
        void SetEditPropertiesView(IEditPropertiesView view);
        void SetEditMarkSystemPropertiesView(IEditMarkSystemPropertiesView view);
    }
}