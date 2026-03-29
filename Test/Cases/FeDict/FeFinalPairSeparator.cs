namespace SeanOne.Alchemy.Test.Cases.FeDict
{
    public class FeFinalPairSeparator : ITest
    {
        Dictionary<int, int> x;
        string ins;

        public void Setup()
        {
            x = Enumerable.Range(1, 10).ToDictionary(x => x, x => x * x);
            ins = "fe /dict-format:{0}=>{1} /end:,\\u0020 /final-pair-separator:\" and \"";
        }

        public string Run()
        {
            return AlchemyFormatter.Format(x, ins);
        }
    }
}

