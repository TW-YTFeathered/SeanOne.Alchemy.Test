using System.Collections.Generic;
using System.Linq;

namespace SeanOne.Alchemy.Test.Cases.FeDict
{
    public class FeExcludeLastEnd : ITest
    {
        Dictionary<int, int> x;
        string ins;

        public void Setup()
        {
            x = Enumerable.Range(1, 10).ToDictionary(x => x, x => x * x);
            ins = "fe /dict-format:{0}=>{1} /end:,\\u0020 /exclude-last-end:true";
        }

        public string Run() => Alchemy.Format(x, ins);

        public string GetAnswer() => "1=>1, 2=>4, 3=>9, 4=>16, 5=>25, 6=>36, 7=>49, 8=>64, 9=>81, 10=>100";
    }
}
