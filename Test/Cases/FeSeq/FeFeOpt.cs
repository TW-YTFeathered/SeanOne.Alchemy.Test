using System.Linq;
using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.FeSeq
{
    public class FeFeOpt : ITest
    {
        List<int> x;
        string ins;

        public void Setup()
        {
            x = Enumerable.Range(1, 10).ToList();
            ins = "fe /fe-opt:true";
        }

        public string Run() => Alchemy.Format(x, ins);

        public string GetAnswer() => "12345678910";
    }
}
