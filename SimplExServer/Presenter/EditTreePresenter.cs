using SimplExServer.Common;
using SimplExServer.Model;
using SimplExServer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplExServer.Presenter
{
    class EditTreePresenter : IntegrablePresenter<Exam, IEditTreeView>
    {
        public EditTreePresenter(IEditTreeView view, IApplicationController applicationController) : base(view, applicationController)
        {
        }
        public override void Run(Exam argument)
        {
            Argumnet = argument;
            View.Themes = Argumnet.Themes;
            View.Tickets = Argumnet.Tickets;
        }
    }
}
