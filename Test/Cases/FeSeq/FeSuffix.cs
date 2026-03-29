namespace SeanOne.Alchemy.Test.Cases.FeSeq
{
    public class FeSuffix : ITest
    {
        List<int> x;
        string ins;

        public void Setup()
        {
            x = Enumerable.Range(1, 10).ToList();
            ins = "fe /suffix:]";
        }

        public string Run()
        {
            return AlchemyFormatter.Format(x, ins);
        }
    }
}
