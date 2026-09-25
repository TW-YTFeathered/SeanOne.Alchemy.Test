using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.FeSeq
{
    public class FeNullElement : ITest
    {
        List<object> x;
        string ins;

        public void Setup()
        {
            x = [1, null, 3];
            ins = "fe /end:\", \" /exclude-last-end:true";
        }

        public string Run() => Alchemy.Format(x, ins);

        public string GetAnswer() => "1, , 3";
    }
}
