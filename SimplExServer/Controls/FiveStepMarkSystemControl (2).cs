using SimplExServer.Model;
using SimplExServer.Model.Inherited;
using System;
using System.Windows.Forms;
namespace SimplExServer.Controls
{
    public partial class FiveStepMarkSystemControl : UserControl
    {
        private FiveStepMarkSystem markSystem;
        private FiveStepMarkSystem oldMarkSystem;
        public MarkSystem MarkSystem
        {
            get
            {
                if (markSystem != null)
                {
                    markSystem.onePercent = (double)fiveUD.Value;
                    markSystem.twoPercent = (double)fourUd.Value;
                    markSystem.threePercent = (double)threeUD.Value;
                    markSystem.fourPercent = (double)twoUd.Value;
                    markSystem.fivePercent = (double)oneUD.Value;
                }
                return markSystem;
            }
            set
            {
                if (value != null) markSystem = (FiveStepMarkSystem)value;
                else markSystem = new FiveStepMarkSystem();
                fiveUD.Value = (decimal)markSystem.onePercent;
                fourUd.Value = (decimal)markSystem.twoPercent;
                threeUD.Value = (decimal)markSystem.threePercent;
                twoUd.Value = (decimal)markSystem.fourPercent;
                oneUD.Value = (decimal)markSystem.fivePercent;
            }
        }
        public FiveStepMarkSystemControl()
        {
            InitializeComponent();
            oldMarkSystem = (FiveStepMarkSystem)MarkSystem;
        }
        private void FiveUDValueChanged(object sender, EventArgs e)
        {
            fourUd.Maximum = fiveUD.Value;
        }
        private void FourUdValueChanged(object sender, EventArgs e)
        {
            fiveUD.Minimum = fourUd.Value;
            threeUD.Maximum = fourUd.Value;
        }
        private void ThreeUDValueChanged(object sender, EventArgs e)
        {
            fourUd.Minimum = threeUD.Value;
            twoUd.Maximum = threeUD.Value;
        }
        private void TwoUdValueChanged(object sender, EventArgs e)
        {
            threeUD.Minimum = twoUd.Value;
            oneUD.Maximum = twoUd.Value;
        }
        private void OneUDValueChanged(object sender, EventArgs e)
        {
            twoUd.Minimum = oneUD.Value;
        }
    }
}
