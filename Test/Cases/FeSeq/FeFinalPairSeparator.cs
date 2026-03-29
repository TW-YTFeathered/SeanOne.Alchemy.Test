namespace SeanOne.Alchemy.Test.Cases.FeSeq
{
    public class FeFinalPairSeparator : ITest
    {
        List<int> x;
        string ins;

        public void Setup()
        {
            x = Enumerable.Range(1, 10).ToList();
            ins = "fe /end:,\\u0020 /final-pair-separator:\" and \"";
        }

        public string Run()
        {
            return AlchemyFormatter.Format(x, ins);
        }
    }
}

