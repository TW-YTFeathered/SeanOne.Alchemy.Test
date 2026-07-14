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

        public string Run() => Alchemy.Format(x, ins);

        public string GetAnswer() => "[1=>1.00, 2=>4.00, 3=>9.00, 4=>16.00, 5=>25.00, 6=>36.00, 7=>49.00, 8=>64.00, 9=>81.00 and 10=>100.00]";
    }
}
