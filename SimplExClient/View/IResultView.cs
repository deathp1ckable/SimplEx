namespace SimplExClient.View
{
    public interface IResultView : IView
    {
        string Result { set; }
        string Points { set; }
        string Mark { set; }

        event ViewActionHandler<IResultView> Continued;
    }
}
