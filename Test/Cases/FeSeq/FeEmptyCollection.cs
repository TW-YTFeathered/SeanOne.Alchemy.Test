using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.FeSeq
{
    public class FeEmptyWithPrefixSuffix : ITest
    {
        List<int> x;
        string ins;

        public void Setup()
        {
            x = [];
            ins = "fe /prefix:[ /suffix:]";
        }

        public string Run() => Alchemy.Format(x, ins);

        public string GetAnswer() => "[]";
    }
}
