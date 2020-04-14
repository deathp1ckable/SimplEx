namespace SimplExModel.NetworkData
{
    public class ServerResponseData
    {
        public double Points { get; private set; }
        public double Mark { get; private set; }
        public ServerResponseData(double points, double mark)
        {
            Mark = mark;
            Points = points;
        }
    }
}
