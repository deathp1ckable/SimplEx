using System;
using System.Collections.Generic;

namespace SimplExServer.View
{
    public interface IEditMarkSystemPropertiesView : IHideableView
    {
        Type MarkSystemType { get; set; }
        IList<Type> MarkSystemTypes { set; }
        string Description { get; set; }
        bool IsSaved { get; set; }
        IEditMarkSystemView EditMarkSystemView { get; set; }

        event ViewActionHandler<IEditMarkSystemPropertiesView> Saved;
        event ViewActionHandler<IEditMarkSystemPropertiesView> Canceled;
        event ViewActionHandler<IEditMarkSystemPropertiesView> Changed;
        event ViewActionHandler<IEditMarkSystemPropertiesView> MarkSystemTypeChanged;
    }
}