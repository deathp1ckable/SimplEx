namespace SimplExServer.Model.Inherited
{
    public class FiveStepMarkSystem : MarkSystem
    {
        public double fivePercent;
        public double fourPercent;
        public double threePercent;
        public double twoPercent;
        public double onePercent;
        public override string Content
        {
            get => fivePercent + "•" + fourPercent + "•" + threePercent + "•" + twoPercent + "•" + onePercent;
            set
            {
                string[] vals = value.Split('•');
                fivePercent = double.Parse(vals[0]);
                fourPercent = double.Parse(vals[1]);
                threePercent = double.Parse(vals[2]);
                twoPercent = double.Parse(vals[3]);
                onePercent = double.Parse(vals[4]);
            }
        }

        public FiveStepMarkSystem(double fivePercent, double fourPercent,
            double threePercent, double twoPercent, double onePercent)
        {
            this.fivePercent = fivePercent;
            this.fourPercent = fourPercent;
            this.threePercent = threePercent;
            this.twoPercent = twoPercent;
            this.onePercent = onePercent;
        }
        public FiveStepMarkSystem()
        {
            fivePercent = 80;
            fourPercent = 60;
            threePercent = 40;
            twoPercent = 20;
            onePercent = 0;
        }
        public override double GetMark(double percent)
        {
            if (percent > fivePercent)
                return 5;
            if (percent > fourPercent)
                return 4;
            if (percent > threePercent)
                return 3;
            if (percent > twoPercent)
                return 2;
            if (percent > onePercent)
                return 1;
            return 0;
        }
        public override double MaxMark() => 5;
        public override double MinMark() => 0;
    }
}
