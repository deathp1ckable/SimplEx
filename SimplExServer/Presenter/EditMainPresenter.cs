using SimplExServer.Common;
using SimplExServer.Model;
using SimplExServer.Model.Builders;
using SimplExServer.View;
using System;
using System.Collections.Generic;
namespace SimplExServer.Presenter
{
    class EditMainPresenter : Presenter<Exam, IEditMainView>
    {
        public EditMainPresenter(IEditMainView view, IApplicationController applicationController) : base(view, applicationController) { }
        public override void Run(Exam argumnet)
        {
            Argumnet = argumnet;
            ApplicationController.Run<EditPopertiesPresenter, Exam>(Argumnet).Integrate(View.SetEditPropertiesView);
            ApplicationController.Run<EditMarkSystemPropertiesPresenter, Exam>(Argumnet).Integrate(View.SetEditMarkSystemPropertiesView);
            ApplicationController.Run<EditTreePresenter, Exam>(Argumnet).Integrate(View.SetEditTreeView);
            Argumnet.LastChangeDate = DateTime.Now;
            if (Argumnet.CreationDate == null)
            {
                View.EditPropertiesView.Saved = false;
                Argumnet.CreationDate = DateTime.Now;
            }
            View.CreationDate = Argumnet.CreationDate.Value;
            View.LastChangeDate = Argumnet.LastChangeDate.Value;
            View.QuestionCount = 0;
            View.MaxPoints = 0;
            View.Show();
        }
    }
}
