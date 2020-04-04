using System;

namespace SimplExServer.View
{
    public class DetachedEventArgs : EventArgs
    {
        public IHideableView View { get; private set; }
        public DetachedEventArgs(IHideableView view)
        {
            View = view;
        }
    }
}