namespace SeanOne.Alchemy.Test.Cases.FeDict
{
    public class FePrefix : ITest
    {
        Dictionary<int, int> x;
        string ins;

        public void Setup()
        {
            x = Enumerable.Range(1, 10).ToDictionary(x => x, x => x * x);
            ins = "fe /dict-format:{0}=>{1} /prefix:[";
        }

        public string Run()
        {
            return AlchemyFormatter.Format(x, ins);
        }
    }
}
