namespace SimplExClient.View
{
    public interface IResultView : IView
    {
        string Result { set; }
        string Points { set; }
        string Mark { set; }

        void Exit();

        event ViewActionHandler<IResultView> Continued;
        event ViewActionHandler<IResultView> Exited;
    }
}
