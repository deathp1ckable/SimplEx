using System;
using System.Timers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SimplexTestingFormDesigner
{
    public partial class VFlatScrollBar : UserControl
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
        public new Control Parent
        {
            get => base.Parent; set
            {
                if (base.Parent != null)
                    base.Parent.MouseWheel -= ScrollWithWheel;
                base.Parent = value;
                base.Parent.MouseWheel += ScrollWithWheel;
            }
        }
        public new event ScrollEventHandler Scroll;
        public event EventHandler ValueChanged;
        public VFlatScrollBar()
        {
            InitializeComponent();
            ResizeRunner();
            timer.Elapsed += ControlMover;
            SizeChanged += SizeChangedHandler;
            new Thread(() =>
            {
                Action action = () =>
                {
                    if (Parent != null)
                        Parent.MouseWheel += ScrollWithWheel;
                };
                while (!IsHandleCreated) ;
                Invoke(action);
            }).Start();
        }
        private void ScrollWithWheel(object sender, MouseEventArgs e)
        {
            if (Parent != null && Parent.ContainsFocus)
            {
                oldValue = value;
                value += -e.Delta * SmallChange / SystemInformation.MouseWheelScrollDelta;
                CheckBounds();
                runnerButton.Location = new Point(runnerButton.Location.X, PosFromvalue());
                Scroll?.Invoke(this, new ScrollEventArgs(ScrollEventType.ThumbPosition, oldValue, value, ScrollOrientation.VerticalScroll));
            }
        }

        private void SizeChangedHandler(object sender, EventArgs e) => ResizeRunner();
        private void ResizeRunner()
        {
            float k = (LargeChange + 0.0f) / (maximum - minimum + LargeChange);
            Size newSize = runnerButton.Size;
            newSize.Height = (int)((Height - 42) * k);
            if (newSize.Height > Height - 42)
                newSize.Height = Height - 42;
            else if (newSize.Height < 16)
                newSize.Height = 16;
            runnerButton.Size = newSize;
            CheckBounds();
            runnerButton.Location = new Point(runnerButton.Location.X, PosFromvalue());
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
                if (beginPositon.Y > currentLocation.Y)
                {
                    tmpLocation.Y -= beginPositon.Y - currentLocation.Y;
                    if (tmpLocation.Y < 20)
                        tmpLocation.Y = 20;
                    oldValue = value;
                    value = ValueFromPos();
                    Scroll?.Invoke(this, new ScrollEventArgs(ScrollEventType.ThumbTrack, oldValue, value, ScrollOrientation.VerticalScroll));
                }
                else if (beginPositon.Y < currentLocation.Y)
                {
                    tmpLocation.Y += currentLocation.Y - beginPositon.Y;
                    if (tmpLocation.Y > Height - runnerButton.Height - 22)
                        tmpLocation.Y = Height - runnerButton.Height - 22;
                    oldValue = value;
                    value = ValueFromPos();
                    Scroll?.Invoke(this, new ScrollEventArgs(ScrollEventType.ThumbTrack, oldValue, value, ScrollOrientation.VerticalScroll));
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
            if ((Height - runnerButton.Height - 42) != 0)
                return minimum + ((runnerButton.Location.Y - 20) * (maximum - minimum) / (Height - runnerButton.Height - 42));
            else return 0;
        }
        private int PosFromvalue()
        {
            if (maximum - minimum != 0)
                return 20 + (value - minimum) * (Height - runnerButton.Height - 42) / (maximum - minimum);
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
            if (tmp.Y < runnerButton.Location.Y)
            {

                oldValue = value;
                value -= LargeChange;
                CheckBounds();
                runnerButton.Location = new Point(runnerButton.Location.X, PosFromvalue());
                Scroll?.Invoke(this, new ScrollEventArgs(ScrollEventType.LargeDecrement, oldValue, value, ScrollOrientation.VerticalScroll));
            }
            else if (tmp.Y > runnerButton.Location.Y + runnerButton.Height)
            {
                oldValue = value;
                value += LargeChange;
                CheckBounds();
                runnerButton.Location = new Point(runnerButton.Location.X, PosFromvalue());
                Scroll?.Invoke(this, new ScrollEventArgs(ScrollEventType.LargeIncrement, oldValue, value, ScrollOrientation.VerticalScroll));
            }
        }
        private void lineUpButton_Click(object sender, EventArgs e)
        {
            oldValue = value;
            value -= SmallChange;
            CheckBounds();
            runnerButton.Location = new Point(runnerButton.Location.X, PosFromvalue());
            Scroll?.Invoke(this, new ScrollEventArgs(ScrollEventType.SmallDecrement, oldValue, value, ScrollOrientation.VerticalScroll));
        }
        private void lineDownButton_Click(object sender, EventArgs e)
        {
            oldValue = value;
            value += SmallChange;
            CheckBounds();
            runnerButton.Location = new Point(runnerButton.Location.X, PosFromvalue());
            Scroll?.Invoke(this, new ScrollEventArgs(ScrollEventType.SmallIncrement, oldValue, value, ScrollOrientation.VerticalScroll));
        }
    }
}
