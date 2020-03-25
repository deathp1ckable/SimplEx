using System;

namespace SimplExServer.View
{
    public interface IEditMainView : IView
    {
        DateTime CreationDate { get; set; }
        DateTime LastChangeDate { get; set; }
        int QuestionCount { get; set; }
        IEditPropertiesView EditPropertiesView { get; }
        IEditMarkSystemPropertiesView MarkSystemPropertiesView { get; }
        IEditThemesView EditThemesView { get; }
        IEditThemeView EditThemeView { get; }
        IEditTicketsView EditTicketsView { get; }
        IEditTreeView EditTreeView { get; }
        void SetEditPropertiesView(IEditPropertiesView view);
        void SetEditMarkSystemPropertiesView(IEditMarkSystemPropertiesView view);
        void SetEditThemesView(IEditThemesView view);
        void SetEditTicketsView(IEditTicketsView view);
        void SetEditTreeView(IEditTreeView view);
        void SetEditThemeView(IEditThemeView view);
    }
}