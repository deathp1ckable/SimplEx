using SimplExServer.Builders;
using System;
namespace SimplExServer.View
{
    public class QuestionCopiedArgs : EventArgs
    {
        public bool IsCut { get; private set; }
        public QuestionBuilder QuestionBuilder { get; private set; }
        public QuestionCopiedArgs(bool isCut, QuestionBuilder questionBuilder)
        {
            IsCut = isCut;
            QuestionBuilder = questionBuilder;
        }
    }
}
