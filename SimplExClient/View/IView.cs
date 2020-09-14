using System;
using System.Collections.Generic;

namespace SimplExClient.View
{
    public interface IView
    {
        void Show();
        void Close();
    }
    public delegate void ViewActionHandler<TViewSender>(TViewSender sender) where TViewSender : IView;
    public delegate void ViewActionHandler<TViewSender, TEventArgs>(TViewSender sender, TEventArgs e) where TViewSender : IView where TEventArgs : EventArgs;
}

