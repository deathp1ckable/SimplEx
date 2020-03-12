using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;

namespace SimplexTestingFormDesigner
{
    public partial class TestCreationForm : Form
    {
        public TestCreationForm()
        {
            InitializeComponent();
            label11.Text = $"Дата создания: {DateTime.Now.Date.ToString("yyyy:MM:dd")}";
        }

    }
}
