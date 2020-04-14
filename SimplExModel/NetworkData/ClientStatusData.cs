namespace SimplExModel.NetworkData
{
    public class ClientStatusData
    {
        public int CurrentQuestionNumber { get; private set; }
        public int ExecutedQuestions { get; private set; }
        public double TimeOffset { get; private set; }

        public ClientStatusData(int currentQuestionNumber, int executedQuestion, double timeOffset)
        {
            CurrentQuestionNumber = currentQuestionNumber;
            ExecutedQuestions = executedQuestion;
            TimeOffset = timeOffset;
        }
    }
}
