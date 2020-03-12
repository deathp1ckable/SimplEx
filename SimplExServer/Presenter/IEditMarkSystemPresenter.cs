using SimplExServer.Model;
using SimplExServer.View;
using System;

namespace SimplExServer.Presenter
{
    interface IEditMarkSystemPresenter
    {
        MarkSystem MarkSystem { get; set; }
        void Integrate(Action<IEditMarkSystemView> integrator);
    }
}