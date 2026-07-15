using System.Collections.Generic;
using System.Linq;

namespace SeanOne.Alchemy.Test.Cases.Error
{
    public class NonIFormattable : ITest
    {
        List<string> x;
        string ins;

        public void Setup()
        {
            x = Enumerable.Range(0, 10).Select(x => x.ToString()).ToList();
            ins = "fe /tostring:F2";
        }

        public string Run() => Alchemy.Format(x, ins);

        public string GetAnswer() => "";
    }
}
