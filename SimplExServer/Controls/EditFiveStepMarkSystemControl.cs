using SimplExServer.Model;
using SimplExServer.View;
using SimplExServer.Model.Inherited;
using System;
using System.Windows.Forms;
namespace SimplExServer.Controls
{
    public partial class EditFiveStepMarkSystemControl : UserControl, IEditFiveStepMarkSystemView
    {
        public event Action SaveChanges;
        public event Action CancelChanges;
        public event Action Changed;
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
        private void FiveUDValueChanged(object sender, EventArgs e)
        {
            fourUd.Maximum = fiveUD.Value;
            Changed?.Invoke();
        }
        private void FourUdValueChanged(object sender, EventArgs e)
        {
            fiveUD.Minimum = fourUd.Value;
            threeUD.Maximum = fourUd.Value;
            Changed?.Invoke();
        }
        private void ThreeUDValueChanged(object sender, EventArgs e)
        {
            fourUd.Minimum = threeUD.Value;
            twoUd.Maximum = threeUD.Value;
            Changed?.Invoke();
        }
        private void TwoUdValueChanged(object sender, EventArgs e)
        {
            threeUD.Minimum = twoUd.Value;
            oneUD.Maximum = twoUd.Value;
            Changed?.Invoke();
        }
        private void OneUDValueChanged(object sender, EventArgs e)
        {
            twoUd.Minimum = oneUD.Value;
            Changed?.Invoke();
        }

        public void MessageWrongData(string reason) { }
        public void CallSaveChanges() => SaveChanges?.Invoke();
        public void CallCancelChanges() => CancelChanges?.Invoke();
        public void Close() => Dispose();
    }
}
