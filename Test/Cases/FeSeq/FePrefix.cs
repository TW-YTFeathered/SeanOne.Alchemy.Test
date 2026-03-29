namespace SeanOne.Alchemy.Test.Cases.FeSeq
{
    public class FePrefix : ITest
    {
        List<int> x;
        string ins;

        public void Setup()
        {
            x = Enumerable.Range(1, 10).ToList();
            ins = "fe /prefix:[";
        }

        public string Run()
        {
            return AlchemyFormatter.Format(x, ins);
        }
    }
}
