using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Error
{
    public class SeqIsNull : ITest
    {
        List<int> x;
        string ins;

        public void Setup()
        {
            x = null;
            ins = "fe /tostring:F2";
        }

        public string Run() => Alchemy.Format(x, ins);

        public string GetAnswer() => "";
    }
}
