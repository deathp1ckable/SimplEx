using System;

namespace SimplExServer.View
{
    public interface IEditMainView : IView
    {
        DateTime CreationDate { get; set; }
        DateTime LastChangeDate { get; set; }
        int QuestionCount { get; set; }
        IEditPropertiesView EditPropertiesView { get; set; }
        IEditMarkSystemPropertiesView EditMarkSystemView { get; set; }
        IEditThemesView EditThemesView { get; set; }
        IEditThemeView EditThemeView { get; set; }
        IEditTicketsView EditTicketsView { get; set; }
        IEditTicketView EditTicketView { get; set; }
        IEditQuestionGroupView EditQuestionGroupView { get; set; }
        IEditQuestionView EditQuestionView { get; set; }
        IEditSavingView EditSavingView { get; set; }
        IEditTreeView EditTreeView { get; set; }
    }
}