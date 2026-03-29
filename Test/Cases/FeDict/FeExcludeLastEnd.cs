namespace SeanOne.Alchemy.Test.Cases.FeDict
{
    public class FeExcludeLastEnd : ITest
    {
        Dictionary<int, int> x;
        string ins;

        public void Setup()
        {
            x = Enumerable.Range(1, 10).ToDictionary(x => x, x => x * x);
            ins = "fe /dict-format:{0}=>{1} /end:,\\u0020 /exclude-last-end:true";
        }

        public string Run()
        {
            return AlchemyFormatter.Format(x, ins);
        }
    }
}
