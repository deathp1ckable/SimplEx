using System.Collections.Generic;

namespace SimplExClient.View
{
    public interface IChatView : IHideableView
    {
        IList<string> Messages { get; set; }
        string Message { get; set; }
        bool EnableChat { get; set; }

        void Invoke(Action action);

        event ViewActionHandler<IChatView> Shown;
        event ViewActionHandler<IChatView> Hiden;
        event ViewActionHandler<IChatView> MessageSended;
    }
}

