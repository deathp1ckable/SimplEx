using SimplExServer.Model;
using SimplExServer.Model.Inherited;
using System;

namespace SimplExServer.Builders
{
    public class FiveStepMarkSystemBuilder : MarkSystemBuilder
    {
        private new FiveStepMarkSystem Instance => (FiveStepMarkSystem)base.Instance;

        private double onePercent;
        private double twoPercent;
        private double threePercent;
        private double fourPercent;
        private double fivePercent;

        public double OnePercent
        {
            get => onePercent;
            set
            {
                if (value <= onePercent)
                    onePercent = value;
                else
                    onePercent = twoPercent;
            }
        }
        public double TwoPercent
        {
            get => twoPercent;
            set
            {
                if (value > threePercent)
                    twoPercent = threePercent;
                else if (value < onePercent)
                    twoPercent = onePercent;
                else
                    twoPercent = value;
            }
        }
        public double ThreePercent
        {
            get => threePercent;
            set
            {
                if (value > fourPercent)
                    threePercent = fourPercent;
                else if (value < twoPercent)
                    threePercent = twoPercent;
                else
                    threePercent = value;
            }
        }
        public double FourPercent
        {
            get => fourPercent;
            set
            {
                if (value > fivePercent)
                    fourPercent = fivePercent;
                else if (value < threePercent)
                    fourPercent = threePercent;
                else
                    fourPercent = value;
            }
        }
        public double FivePercent
        {
            get => fivePercent;
            set
            {
                if (value < fourPercent)
                    fivePercent = fourPercent;
                else
                    fivePercent = value;
            }
        }

        public FiveStepMarkSystemBuilder(FiveStepMarkSystem instance, ExamBuilder examBuilder) : base(examBuilder) => Load(instance);

        public override void Reset() => base.Instance = new FiveStepMarkSystem();
        public override void Load(MarkSystem instance)
        {
            base.Load(instance);
            onePercent = Instance.OnePercent;
            twoPercent = Instance.TwoPercent;
            threePercent = Instance.ThreePercent;
            fourPercent = Instance.FourPercent;
            fivePercent = Instance.FivePercent;
        }
        public override MarkSystem GetBuildedInstance()
        {
            if (ParentExamBuilder.MarkSystemBuilder != this)
                throw new Exception("This builder is not assigned to the parent builder.");
            Instance.OnePercent = onePercent;
            Instance.TwoPercent = twoPercent;
            Instance.ThreePercent = threePercent;
            Instance.FourPercent = fourPercent;
            Instance.FivePercent = fivePercent;
            return base.GetBuildedInstance();
        }
    }
}
