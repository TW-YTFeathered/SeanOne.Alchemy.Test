using System.Collections.Generic;
using System.Linq;

namespace SeanOne.Alchemy.Test.Cases.FeSeq
{
    public class FeSuffix : ITest
    {
        List<int> x;
        string ins;

        public void Setup()
        {
            x = Enumerable.Range(1, 10).ToList();
            ins = "fe /suffix:]";
        }

        public string Run() => Alchemy.Format(x, ins);

        public string GetAnswer() => "12345678910]";
    }
}
