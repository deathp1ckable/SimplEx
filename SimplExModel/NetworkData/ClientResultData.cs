using SimplExModel.Model.Data;
using System;
using System.Collections.Generic;

namespace SimplExModel.NetworkData
{
    public class ClientResultData
    {
        public List<AnswerData> AnswerDatas { get; set; } = new List<AnswerData>();
        public ClientResultData() { }
        public ClientResultData(List<AnswerData> answerDatas)
        {
            AnswerDatas = answerDatas ?? throw new ArgumentNullException(nameof(answerDatas));
        }
    }
}
