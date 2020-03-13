using SimplExServer.Model;
using SimplExServer.View;
using SimplExServer.Model.Inherited;
using System;
using System.Windows.Forms;
namespace SimplExServer.Controls
{
    public partial class EditFiveStepMarkSystemControl : UserControl, IEditFiveStepMarkSystemView
    {
        public double OnePercent { get => (int)oneUD.Value; set => oneUD.Value = (decimal)value; }
        public double TwoPercent { get => (int)twoUd.Value; set => twoUd.Value = (decimal)value; }
        public double ThreePercent { get => (int)threeUD.Value; set => threeUD.Value = (decimal)value; }
        public double FourPercent { get => (int)fourUd.Value; set => fourUd.Value = (decimal)value; }
        public double FivePercent { get => (int)fiveUD.Value; set => fiveUD.Value = (decimal)value; }
        public bool Saved { get; set; }

        public EditFiveStepMarkSystemControl()
        {
            InitializeComponent();
        }
        public event ViewActionHandler<IEditMarkSystemView> SaveChanges;
        public event ViewActionHandler<IEditMarkSystemView> CancelChanges;
        public event ViewActionHandler<IEditMarkSystemView> Changed;

        private void FiveUDValueChanged(object sender, EventArgs e)
        {
            fourUd.Maximum = fiveUD.Value;
            Changed?.Invoke(this);
        }
        private void FourUdValueChanged(object sender, EventArgs e)
        {
            fiveUD.Minimum = fourUd.Value;
            threeUD.Maximum = fourUd.Value;
            Changed?.Invoke(this);
        }
        private void ThreeUDValueChanged(object sender, EventArgs e)
        {
            fourUd.Minimum = threeUD.Value;
            twoUd.Maximum = threeUD.Value;
            Changed?.Invoke(this);
        }
        private void TwoUdValueChanged(object sender, EventArgs e)
        {
            threeUD.Minimum = twoUd.Value;
            oneUD.Maximum = twoUd.Value;
            Changed?.Invoke(this);
        }
        private void OneUDValueChanged(object sender, EventArgs e)
        {
            twoUd.Minimum = oneUD.Value;
            Changed?.Invoke(this);
        }

        public void MessageWrongData(string reason) { }
        public void CallSaveChanges() => SaveChanges?.Invoke(this);
        public void CallCancelChanges() => CancelChanges?.Invoke(this);
        public void Close() => Dispose();
    }
}
