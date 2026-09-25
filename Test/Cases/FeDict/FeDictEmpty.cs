using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.FeDict
{
    public class FeDictEmptyWithPrefixSuffix : ITest
    {
        Dictionary<int, int> x;
        string ins;

        public void Setup()
        {
            x = [];
            ins = "fe /dict-format:{0}=>{1} /prefix:[ /suffix:]";
        }

        public string Run() => Alchemy.Format(x, ins);

        public string GetAnswer() => "[]";
    }
}
