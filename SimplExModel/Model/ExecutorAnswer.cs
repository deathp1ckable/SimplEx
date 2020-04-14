namespace SimplExModel.Model
{
    public class ExecutorAnswer 
    {   
        public Question Question { get; set; }
        public string Content { get; set; } = string.Empty;
        public ExecutorAnswer(Answer answer)
        {
            Question = answer.Question;
            Content = answer.Content;
        }
        public ExecutorAnswer() { }
    }
}
