using SimplExServer.Builders;
using System;
namespace SimplExServer.View
{
    public class QuestionPastedArgs : EventArgs
    {
        public QuestionGroupBuilder QuestionGroupBuilder { get; private set; }
        public QuestionPastedArgs(QuestionGroupBuilder questionGroupBuilder)
        {
            QuestionGroupBuilder = questionGroupBuilder;
        }
    }
}
