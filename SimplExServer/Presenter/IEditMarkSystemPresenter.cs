using SimplExServer.Builders;
using SimplExServer.View;
using System;
namespace SimplExServer.Presenter
{
    interface IEditMarkSystemPresenter 
    {
        MarkSystemBuilder MarkSystemBuilder { get; set; }
        IEditMarkSystemView View { get; }
    }
}