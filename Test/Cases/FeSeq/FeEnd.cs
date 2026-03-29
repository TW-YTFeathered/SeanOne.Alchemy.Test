namespace SeanOne.Alchemy.Test.Cases.FeSeq
{
    public class FeEnd : ITest
    {
        List<int> x;
        string ins;

        public void Setup()
        {
            x = Enumerable.Range(1, 10).ToList();
            ins = "fe /end:,\\u0020";
        }

        public string Run()
        {
            return AlchemyFormatter.Format(x, ins);
        }
    }
}
