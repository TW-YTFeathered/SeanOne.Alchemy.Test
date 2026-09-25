namespace SeanOne.Alchemy.Test.Cases.Utility
{
    public class ValueWithEscapedQuote : ITest
    {
        int x;
        string ins;

        public void Setup()
        {
            x = 10;
            ins = "/prefix:\"He said \\u0022Hi\\u0022\"";
        }

        public string Run() => Alchemy.Format(x, ins);

        public string GetAnswer() => "He said \"Hi\"10";
    }
}
