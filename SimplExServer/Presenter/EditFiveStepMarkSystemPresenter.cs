using SimplExServer.Common;
using SimplExServer.Model;
using SimplExServer.Model.Inherited;
using SimplExServer.View;
using System;

namespace SimplExServer.Presenter
{
    class EditFiveStepMarkSystemPresenter : IntegrablePresenter<MarkSystem, IEditFiveStepMarkSystemView>, IEditMarkSystemPresenter
    {
        FiveStepMarkSystem fiveStepMarkSystem;
        public MarkSystem MarkSystem { get => fiveStepMarkSystem; set => fiveStepMarkSystem = (FiveStepMarkSystem)value; }
        public EditFiveStepMarkSystemPresenter(IEditFiveStepMarkSystemView view, IApplicationController applicationController) : base(view, applicationController)
        {
            View.SaveChanges += SaveChanges;
            View.Changed += Changed;
            View.CancelChanges += CancelChanges;
        }
        private void SaveChanges(IEditMarkSystemView sender)
        { 
            IEditFiveStepMarkSystemView editor =  (IEditFiveStepMarkSystemView)sender;
            fiveStepMarkSystem.fivePercent = editor.FivePercent;
            fiveStepMarkSystem.fourPercent = editor.FourPercent;
            fiveStepMarkSystem.threePercent = editor.ThreePercent;
            fiveStepMarkSystem.twoPercent = editor.TwoPercent;
            fiveStepMarkSystem.onePercent = editor.OnePercent;
            editor.Saved = true;
        }
        private void CancelChanges(IEditMarkSystemView sender)
        {
            IEditFiveStepMarkSystemView editor = (IEditFiveStepMarkSystemView)sender;
            editor.FivePercent = fiveStepMarkSystem.fivePercent;
            editor.FourPercent = fiveStepMarkSystem.fourPercent;
            editor.ThreePercent = fiveStepMarkSystem.threePercent;
            editor.TwoPercent = fiveStepMarkSystem.twoPercent;
            editor.OnePercent = fiveStepMarkSystem.onePercent;
            editor.Saved = true;
        }
        private void Changed(IEditMarkSystemView sender) => sender.Saved = false;
        public override void Run(MarkSystem argumnet)
        {
            MarkSystem = argumnet;
            View.FivePercent = fiveStepMarkSystem.fivePercent;
            View.FourPercent = fiveStepMarkSystem.fourPercent;
            View.ThreePercent = fiveStepMarkSystem.threePercent;
            View.TwoPercent = fiveStepMarkSystem.twoPercent;
            View.OnePercent = fiveStepMarkSystem.onePercent;
            View.Saved = true;
        }
        public void Integrate(Action<IEditMarkSystemView> integrator) => base.Integrate(integrator);
    }
}
