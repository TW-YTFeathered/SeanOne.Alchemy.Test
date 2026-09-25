namespace SeanOne.Alchemy.Test.Cases.Utility
{
    public class EmptyParamValue : ITest
    {
        int x;
        string ins;

        public void Setup()
        {
            x = 5;
            ins = "/prefix:\"\"";
        }

        public string Run() => Alchemy.Format(x, ins);

        public string GetAnswer() => "5";
    }
}
