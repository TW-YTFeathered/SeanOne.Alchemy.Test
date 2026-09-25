namespace SeanOne.Alchemy.Test.Cases.Utility
{
    public class ValueWithSlash : ITest
    {
        int x;
        string ins;

        public void Setup()
        {
            x = 10;
            ins = "/prefix:\"path/to/file/\"";
        }

        public string Run() => Alchemy.Format(x, ins);

        public string GetAnswer() => "path/to/file/10";
    }
}
