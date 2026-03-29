namespace SeanOne.Alchemy.Test.Cases.FeDict
{
    public class FeAllInOne : ITest
    {
        Dictionary<int, int> x;
        string ins;

        public void Setup()
        {
            x = Enumerable.Range(1, 10).ToDictionary(x => x, x => x * x);
            ins = "fe /dict-format:{0}=>{1} /prefix:[ /end:,\\u0020 /exclude-last-end:true /final-pair-separator:\" and \" /suffix:] /key-format:N0 /value-format:F2 /fe-opt:true";
        }

        public string Run()
        {
            return AlchemyFormatter.Format(x, ins);
        }
    }
}
