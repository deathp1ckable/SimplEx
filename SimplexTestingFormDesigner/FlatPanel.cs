using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SimplexTestingFormDesigner
{
    public partial class FlatPanel : Panel
    {
        private BorderStyle borderStyle = BorderStyle.None;
        public new bool AutoScroll { get; set; }
        public new BorderStyle BorderStyle
        {
            get => borderStyle; set
            {
                borderStyle = value;
                if (borderStyle != BorderStyle.None)
                    bottomBorder.Visible = topBorder.Visible = rightBorder.Visible = leftBorder.Visible = true;
                else
                    bottomBorder.Visible = topBorder.Visible = rightBorder.Visible = leftBorder.Visible = false;
            }
        }
        public int FullWidth
        {
            get
            {
                int res = Width;
                foreach (Control control in Controls)
                    if (res < control.Location.X + control.Width)
                        res = control.Location.X + control.Width;
                return res + AutoScrollMargin.Width + 18;
            }
        }
        public int FullHeight
        {
            get
            {
                int res = Height;
                foreach (Control control in Controls)
                {
                    if (res < control.Location.Y + control.Height)
                        res = control.Location.Y + control.Height;
                }
                return res + AutoScrollMargin.Height + 18;
            }
        }
        public FlatPanel()
        {
            InitializeComponent();
            DoubleBuffered = true;
            bottomBorder.Visible = topBorder.Visible = rightBorder.Visible = leftBorder.Visible = false;
            ControlAdded += ControlAddedHandle;
            ControlRemoved += ControlRemovedHandle;
            SizeChanged += SizeChangedHandle;
            foreach (Control control in Controls)
            {
                control.SizeChanged += SizeChangedHandle;
            }
            new Thread(() =>
            {
                Action action = RefreshScrollbars;
                while (!IsHandleCreated) ;
                Invoke(action);
            }).Start();
            vFlatScrollBar.Scroll += VScrollHandle;
            hFlatScrollBar.Scroll += HScrollHandle;
        }


        private void HScrollHandle(object sender, ScrollEventArgs e)
        {
            if (AutoScroll)
            {
                foreach (Control control in Controls)
                {
                    if (!ReferenceEquals(bottomBorder, control) && !ReferenceEquals(topBorder, control) && !ReferenceEquals(rightBorder, control) && !ReferenceEquals(leftBorder, control) && !ReferenceEquals(vFlatScrollBar, control) && !ReferenceEquals(hFlatScrollBar, control) && !ReferenceEquals(cornerPanel, control))
                    {
                        tmp = control.Location;
                        tmp.X += e.OldValue;
                        tmp.X -= e.NewValue;
                        control.Location = tmp;
                    }
                }
                Invalidate();
            }
        }

        Point tmp;
        private void VScrollHandle(object sender, ScrollEventArgs e)
        {
            if (AutoScroll)
            {
                foreach (Control control in Controls)
                {
                    if (!ReferenceEquals(bottomBorder, control) && !ReferenceEquals(topBorder, control) && !ReferenceEquals(rightBorder, control) && !ReferenceEquals(leftBorder, control) && !ReferenceEquals(vFlatScrollBar, control) && !ReferenceEquals(hFlatScrollBar, control) && !ReferenceEquals(cornerPanel, control))
                    {
                        tmp = control.Location;
                        tmp.Y += e.OldValue;
                        tmp.Y -= e.NewValue;
                        control.Location = tmp;
                    }
                }
                Invalidate();
            }
        }

        private void SizeChangedHandle(object sender, EventArgs e)
        {
            topBorder.Location = Point.Empty;
            topBorder.Size = new Size(Width, 1);
            leftBorder.Location = Point.Empty;
            leftBorder.Size = new Size(1, Height);
            bottomBorder.Location = new Point(0, Height - 1);
            bottomBorder.Size = new Size(Width, 1);
            rightBorder.Location = new Point(Width - 1, 0);
            rightBorder.Size = new Size(1, Height);
            vFlatScrollBar.Location = new Point(Width - 18, 0);
            hFlatScrollBar.Location = new Point(0, Height - 18);
            cornerPanel.Location = new Point(Width - 18, Height - 18);
            RefreshScrollbars();
        }

        private void ControlRemovedHandle(object sender, ControlEventArgs e) => RefreshScrollbars();
        private void ControlAddedHandle(object sender, ControlEventArgs e) => RefreshScrollbars();
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
        int fullWidth;
        int fullHeight;
        public void RefreshScrollbars()
        {
            if (AutoScroll)
            {
                fullWidth = FullWidth;
                fullHeight = FullHeight;
                if (fullHeight > Height + AutoScrollMargin.Height + 18)
                {
                    vFlatScrollBar.SmallChange = Height / 10;
                    vFlatScrollBar.LargeChange = Height;
                    vFlatScrollBar.Maximum = fullHeight - Height;
                    vFlatScrollBar.Visible = true;
                    vFlatScrollBar.Enabled = true;
                }
                else
                {
                    vFlatScrollBar.Visible = false;
                    vFlatScrollBar.Enabled = false;
                }
                if (fullWidth > Width + AutoScrollMargin.Width + 18)
                {
                    hFlatScrollBar.SmallChange = Width / 10;
                    hFlatScrollBar.LargeChange = Width;
                    hFlatScrollBar.Maximum = fullWidth - Width;
                    hFlatScrollBar.Visible = true;
                    hFlatScrollBar.Enabled = true;
                }
                else
                {
                    hFlatScrollBar.Visible = false;
                    hFlatScrollBar.Enabled = false;
                }
                if (vFlatScrollBar.Visible && !hFlatScrollBar.Visible)
                {
                    vFlatScrollBar.Height = Height;
                    cornerPanel.Visible = false;
                }
                else if (!vFlatScrollBar.Visible && hFlatScrollBar.Visible)
                {
                    hFlatScrollBar.Width = Width;
                    cornerPanel.Visible = false;
                }
                else
                {
                    vFlatScrollBar.Height = Height - 18;
                    hFlatScrollBar.Width = Width - 18;
                    cornerPanel.Visible = true;
                }
            }
            else
            {
                vFlatScrollBar.Visible = false;
                hFlatScrollBar.Visible = false;
                cornerPanel.Visible = false;
            }
        }
    }
}
