namespace SeanOne.Alchemy.Test.Cases.FeSeq
{
    public class FeAllInOne : ITest
    {
        List<int> x;
        string ins;

        public void Setup()
        {
            x = Enumerable.Range(1, 10).ToList();
            ins = "fe /prefix:[ /end:,\\u0020 /exclude-last-end:true /final-pair-separator:\" and \" /suffix:] /tostring:F2 /fe-opt:true";
        }

        public string Run()
        {
            return AlchemyFormatter.Format(x, ins);
        }
    }
}
