using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace SimplexTestingFormDesigner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Parent = flatPanel1;
            treeView1.ImageList = new ImageList();
            treeView1.ImageList.Images.Add(Image.FromFile(@"FolderTreeView.png"));
            button2.FlatAppearance.BorderSize = 0;
        }
        private void FlatScrollBar1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
   

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
