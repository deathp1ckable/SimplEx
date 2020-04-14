using SimplExModel.Model.Data;
using System;

namespace SimplExModel.NetworkData
{
    public class ClientResultData
    {
        public AnswerData[] AnswerDatas { get; private set; } = new AnswerData[0];
        public ClientResultData() { }
        public ClientResultData(AnswerData[] answerDatas)
        {
            AnswerDatas = answerDatas ?? throw new ArgumentNullException(nameof(answerDatas));
        }
    }
}
