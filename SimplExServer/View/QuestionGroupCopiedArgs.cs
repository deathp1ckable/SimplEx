using SimplExServer.Builders;
using System;
namespace SimplExServer.View
{
    public class QuestionGroupCopiedArgs : EventArgs
    {
        public bool IsCut { get; private set; }
        public QuestionGroupBuilder QuestionBuilder { get; private set; }
        public QuestionGroupCopiedArgs(bool isCut, QuestionGroupBuilder questionBuilder)
        {
            IsCut = isCut;
            QuestionBuilder = questionBuilder;
        }
    }
}
