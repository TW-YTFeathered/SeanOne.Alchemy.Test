using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Error
{
    public class DictIsNull : ITest
    {
        Dictionary<int, int> x;
        string ins;

        public void Setup()
        {
            x = null;
            ins = "fe /dict-format:{0}={1}";
        }

        public string Run() => Alchemy.Format(x, ins);

        public string GetAnswer() => "";
    }
}
