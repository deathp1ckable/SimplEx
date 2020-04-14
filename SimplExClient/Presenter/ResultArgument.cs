namespace SimplExClient.Presenter
{
    class ResultArgument
    {
        public string Result { get; private set; }
        public string Points { get; private set; }
        public string Mark { get; private set; }

        public ResultArgument(string result, string points, string mark)
        {
            Result = result;
            Points = points;
            Mark = mark;
        }
    }
}
