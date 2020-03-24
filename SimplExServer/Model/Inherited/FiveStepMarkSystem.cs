namespace SimplExServer.Model.Inherited
{
    public class FiveStepMarkSystem : MarkSystem
    {
        public double OnePercent { get; set; }
        public double TwoPercent { get; set; }
        public double ThreePercent { get; set; }
        public double FourPercent { get; set; }
        public double FivePercent { get; set; }
        public override string Content
        {
            get => FivePercent + "•" + FourPercent + "•" + ThreePercent + "•" + TwoPercent + "•" + OnePercent;
            set
            {
                string[] vals = value.Split('•');
                FivePercent = double.Parse(vals[0]);
                FourPercent = double.Parse(vals[1]);
                ThreePercent = double.Parse(vals[2]);
                TwoPercent = double.Parse(vals[3]);
                OnePercent = double.Parse(vals[4]);
            }
        }

        public FiveStepMarkSystem(double fivePercent, double fourPercent,
            double threePercent, double twoPercent, double onePercent)
        {
            this.FivePercent = fivePercent;
            this.FourPercent = fourPercent;
            this.ThreePercent = threePercent;
            this.TwoPercent = twoPercent;
            this.OnePercent = onePercent;
        }
        public FiveStepMarkSystem()
        {
            FivePercent = 80;
            FourPercent = 60;
            ThreePercent = 40;
            TwoPercent = 20;
            OnePercent = 0;
        }
        public override double GetMark(double percent)
        {
            if (percent > FivePercent)
                return 5;
            if (percent > FourPercent)
                return 4;
            if (percent > ThreePercent)
                return 3;
            if (percent > TwoPercent)
                return 2;
            if (percent > OnePercent)
                return 1;
            return 0;
        }
        public override double MaxMark() => 5;
        public override double MinMark() => 0;

        public override object Clone() => MemberwiseClone();
    }
}
