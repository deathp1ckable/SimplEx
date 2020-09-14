using System.Collections.Generic;

namespace SimplExClient.View
{
    public interface IOneAnswerQuestionView : IQuestionControlView
    {
        string QuestionText { set; }
        string Devider { set; }
        string Letters { set; }
        IList<string> Answers { set; }
    }

}

