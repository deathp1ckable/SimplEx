using SimplExServer.Builders;
using SimplExServer.View;
using System;
namespace SimplExServer.Presenter
{
    interface IEditMarkSystemPresenter 
    {
        MarkSystemBuilder MarkSystem { get; set; }
        void Integrate(Action<IEditMarkSystemView> integrator);
    }
}