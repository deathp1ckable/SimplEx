using System;
using System.Windows.Forms;

namespace SimplexTestingFormDesigner
{
    public partial class TestingForm : Form
    {
        public TestingForm()
        {
            InitializeComponent();
            Deactivate += DeactivateHandler;
            MouseLeave += MouseLeaveHandler;
        }

        private void DeactivateHandler(object sender, EventArgs e)
        {
            _ = 1;
        }
        private void MouseLeaveHandler(object sender, EventArgs e)
        {
            if (!ClientRectangle.Contains(PointToClient(MousePosition)))
                _ = 1;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
