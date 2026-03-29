namespace SeanOne.Alchemy.Test.Cases.FeDict
{
    public class FeFeOpt : ITest
    {
        Dictionary<int, int> x;
        string ins;

        public void Setup()
        {
            x = Enumerable.Range(1, 10).ToDictionary(x => x, x => x * x);
            ins = "fe /dict-format:{0}=>{1} /fe-opt:true";
        }

        public string Run()
        {
            return AlchemyFormatter.Format(x, ins);
        }
    }
}
