using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplExServer.View
{
    public interface IEditDetachedView : IView
    {
        IIntegrableView View { get; }
        void SetView(IIntegrableView view);
        event ViewActionHandler<IEditDetachedView> WindowActivated;
    }
}
