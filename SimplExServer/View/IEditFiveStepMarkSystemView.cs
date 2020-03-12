namespace SimplExServer.View
{
    public interface IEditFiveStepMarkSystemView : IEditMarkSystemView
    {
        double OnePercent { get; set; }
        double TwoPercent { get; set; }
        double ThreePercent { get; set; }
        double FourPercent { get; set; }
        double FivePercent { get; set; }
    }
}