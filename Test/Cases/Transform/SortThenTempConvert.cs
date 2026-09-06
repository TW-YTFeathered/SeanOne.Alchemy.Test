using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Transform
{
    public class SortThenTempConvert : ITest
    {
        List<double> x;
        string[] mulIns;

        public void Setup()
        {
            x = [32.0, 212.0, 0.0];
            mulIns = ["arr /sort:is", "cnv /temp:F->C", $"fe /tostring:{TestConstants.NUMBER_FORMAT} /end:\\u0020"];
        }

        public string Run() => Alchemy.Transform(x, mulIns).ToString();

        public string GetAnswer() => "-17.777777777778 0.00 100.00 ";
    }
}
