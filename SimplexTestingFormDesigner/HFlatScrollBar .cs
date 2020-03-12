using System;
using System.Timers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplexTestingFormDesigner
{
    public partial class HFlatScrollBar : UserControl
    {
        private Color moversColor = Color.White;
        [Category("Внешний вид"), Description("Цвет кнопок элемента прокрутки.")]
        public Color MoversColor { get => moversColor; set => moversColor = lineUpButton.BackColor = lineDownButton.BackColor = runnerButton.BackColor = value; }

        private System.Timers.Timer timer = new System.Timers.Timer(8);

        bool isMouseHold;
        Point beginPositon;
        Point tmpLocation;
        Point currentLocation;
        int oldValue;
        private int value;
        private int maximum = 100;
        private int minimum = 0;
        public int Value { get => value; set { this.value = value; ValueChanged?.Invoke(this, new EventArgs()); } }
        private int largeChange = 10;
        public int LargeChange { get => largeChange; set { largeChange = value; ResizeRunner(); } }
        public int SmallChange { get; set; } = 1;
        public int Maximum
        {
            get => maximum;
            set
            {
                if (value >= minimum)
                {
                    maximum = value;
                    ResizeRunner();
                }
                else throw new ArgumentException();
            }
        }
        public int Minimum
        {
            get => minimum;
            set
            {
                if (value <= maximum)
                {
                    minimum = value;
                    ResizeRunner();
                }
                else throw new ArgumentException();
            }
        }
        public new event ScrollEventHandler Scroll;
        public event EventHandler ValueChanged;
        public HFlatScrollBar()
        {
            InitializeComponent();
            ResizeRunner();
            timer.Elapsed += ControlMover;
            SizeChanged += SizeChangedHandler;

        }

        private void SizeChangedHandler(object sender, EventArgs e) => ResizeRunner();
        private void ResizeRunner()
        {
            float k = (LargeChange + 0.0f) / (maximum - minimum + LargeChange);
            Size newSize = runnerButton.Size;
            newSize.Width = (int)((Width - 42) * k);
            if (newSize.Width > Width - 42)
                newSize.Width = Width - 42;
            else if (newSize.Width < 16)
                newSize.Width = 16;
            runnerButton.Size = newSize;
            CheckBounds();
            runnerButton.Location = new Point(PosFromvalue(), runnerButton.Location.Y); ;
        }

        private void CheckBounds()
        {
            if (value > maximum)
                value = maximum;
            else if (value < minimum)
                value = minimum;
        }
        private void ControlMover(object sender, ElapsedEventArgs e)
        {
            runnerButton.Invoke(new Action(() =>
            {
                tmpLocation = runnerButton.Location;
                currentLocation = runnerButton.PointToClient(MousePosition);
                if (beginPositon.X > currentLocation.X)
                {
                    tmpLocation.X -= beginPositon.X - currentLocation.X;
                    if (tmpLocation.X < 20)
                        tmpLocation.X = 20;
                    oldValue = value;
                    value = ValueFromPos();
                    Scroll?.Invoke(this, new ScrollEventArgs(ScrollEventType.ThumbTrack, oldValue, value, ScrollOrientation.HorizontalScroll));
                }
                else if (beginPositon.X < currentLocation.X)
                {
                    tmpLocation.X += currentLocation.X - beginPositon.X;
                    if (tmpLocation.X > Width - runnerButton.Width - 22)
                        tmpLocation.X = Width - runnerButton.Width - 22;
                    oldValue = value;
                    value = ValueFromPos();
                    Scroll?.Invoke(this, new ScrollEventArgs(ScrollEventType.ThumbTrack, oldValue, value, ScrollOrientation.HorizontalScroll));
                }
                runnerButton.Location = tmpLocation;
            }));
            if (isMouseHold)
                timer.Start();
        }
        private void runnerButton_MouseDown(object sender, MouseEventArgs e)
        {
            beginPositon = runnerButton.PointToClient(MousePosition);
            isMouseHold = true;
            timer.Start();
        }
        private void runnerButton_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseHold = false;
            timer.Stop();
            if (Parent != null)
                Parent.Invalidate();
        }
        private int ValueFromPos()
        {
            if ((Width - runnerButton.Width - 42) != 0)
                return minimum + ((runnerButton.Location.X - 20) * (maximum - minimum) / (Width - runnerButton.Width - 42));
            else return 0;
        }
        private int PosFromvalue()
        {
            if (maximum - minimum != 0)
                return 20 + (value - minimum) * (Width - runnerButton.Width - 42) / (maximum - minimum);
            else return 20;
        }
        public override string ToString()
        {
            string text = base.ToString();
            return text + ", Minimum: " + minimum.ToString(CultureInfo.CurrentCulture) + ", Maximum: " + maximum.ToString(CultureInfo.CurrentCulture) + ", Value: " + value.ToString(CultureInfo.CurrentCulture);
        }
        private void flatScrollBar_Click(object sender, EventArgs e)
        {
            Point tmp = PointToClient(MousePosition);
            if (tmp.X < runnerButton.Location.X)
            {

                oldValue = value;
                value -= LargeChange;
                CheckBounds();
                runnerButton.Location = new Point(PosFromvalue(), runnerButton.Location.Y); ;
                Scroll?.Invoke(this, new ScrollEventArgs(ScrollEventType.LargeDecrement, oldValue, value, ScrollOrientation.HorizontalScroll));
            }
            else if (tmp.X > runnerButton.Location.X + runnerButton.Width)
            {
                oldValue = value;
                value += LargeChange;
                CheckBounds();
                runnerButton.Location = new Point(PosFromvalue(), runnerButton.Location.Y); ;
                Scroll?.Invoke(this, new ScrollEventArgs(ScrollEventType.LargeIncrement, oldValue, value, ScrollOrientation.HorizontalScroll));
            }
        }
        private void lineUpButton_Click(object sender, EventArgs e)
        {
            oldValue = value;
            value -= SmallChange;
            CheckBounds();
            runnerButton.Location = new Point(PosFromvalue(), runnerButton.Location.Y); ;
            Scroll?.Invoke(this, new ScrollEventArgs(ScrollEventType.SmallDecrement, oldValue, value, ScrollOrientation.HorizontalScroll));
        }
        private void lineDownButton_Click(object sender, EventArgs e)
        {
            oldValue = value;
            value += SmallChange;
            CheckBounds();
            runnerButton.Location = new Point(PosFromvalue(), runnerButton.Location.Y); ;
            Scroll?.Invoke(this, new ScrollEventArgs(ScrollEventType.SmallIncrement, oldValue, value, ScrollOrientation.HorizontalScroll));
        }
    }
}
