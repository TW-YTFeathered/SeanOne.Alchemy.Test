
namespace SeanOne.Alchemy.Test.Cases.FeDict
{
    public class FeValueFormat : ITest
    {
        Dictionary<int, int> x;
        string ins;

        public void Setup()
        {
            x = Enumerable.Range(1, 10).ToDictionary(x => x, x => x * x);
            ins = "fe /dict-format:{1} /value-format:F2";
        }

        public string Run() => Alchemy.Format(x, ins);

        public string GetAnswer() => "1.004.009.0016.0025.0036.0049.0064.0081.00100.00";
    }
}
