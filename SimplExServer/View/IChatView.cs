using System;
using System.Collections.Generic;

namespace SimplExServer.View
{
    public interface IChatView : IHideableView
    {
        IList<string> Messages { get; set; }
        string Message { get; set; }
        bool Broadcast { get; set; }
        bool EnableChat { get; set; }

        void Invoke(Action action);

        event ViewActionHandler<IChatView> Shown;
        event ViewActionHandler<IChatView> Hiden;
        event ViewActionHandler<IChatView> MessageSended;
    }
}
