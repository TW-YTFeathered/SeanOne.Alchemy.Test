namespace SeanOne.Alchemy.Test.Cases.FeSeq
{
    public class FeFeOpt : ITest
    {
        List<int> x;
        string ins;

        public void Setup()
        {
            x = Enumerable.Range(1, 10).ToList();
            ins = "fe /fe-opt:true";
        }

        public string Run()
        {
            return AlchemyFormatter.Format(x, ins);
        }
    }
}
