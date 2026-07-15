using System.Collections.Generic;
using System.Linq;

namespace SeanOne.Alchemy.Test.Cases.Error
{
    public class ErrorDirective : ITest
    {
        List<int> x;
        string ins;

        public void Setup()
        {
            x = Enumerable.Range(0, 10).ToList();
            ins = "loop /tostring:F2";
        }

        public string Run() => Alchemy.Format(x, ins);

        public string GetAnswer() => "";
    }
}
