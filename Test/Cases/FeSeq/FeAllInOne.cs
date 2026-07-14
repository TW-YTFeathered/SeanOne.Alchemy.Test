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

        public string Run() => Alchemy.Format(x, ins);

        public string GetAnswer() => "[1.00, 2.00, 3.00, 4.00, 5.00, 6.00, 7.00, 8.00, 9.00 and 10.00]";
    }
}
