namespace SeanOne.Alchemy.Test.Cases.FeSeq
{
    public class FeEnd : ITest
    {
        List<int> x;
        string ins;

        public void Setup()
        {
            x = Enumerable.Range(1, 10).ToList();
            ins = "fe /end:,\\u0020";
        }

        public string Run() => Alchemy.Format(x, ins);

        public string GetAnswer() => "1, 2, 3, 4, 5, 6, 7, 8, 9, 10, ";
    }
}
