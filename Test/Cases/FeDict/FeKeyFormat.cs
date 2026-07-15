using System.Collections.Generic;
using System.Linq;

namespace SeanOne.Alchemy.Test.Cases.FeDict
{
    public class FeKeyFormat : ITest
    {
        Dictionary<int, int> x;
        string ins;

        public void Setup()
        {
            x = Enumerable.Range(1, 10).ToDictionary(x => x, x => x * x);
            ins = "fe /dict-format:{0} /key-format:F2";
        }

        public string Run() => Alchemy.Format(x, ins);

        public string GetAnswer() => "1.002.003.004.005.006.007.008.009.0010.00";
    }
}
