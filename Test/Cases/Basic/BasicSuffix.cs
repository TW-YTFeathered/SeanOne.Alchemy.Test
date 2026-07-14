namespace SeanOne.Alchemy.Test.Cases.Basic
{
    public class BasicSuffix : ITest
    {
        int x;
        string ins;

        public void Setup()
        {
            x = 5;
            ins = "/suffix:]";
        }

        public string Run() => Alchemy.Format(x, ins);

        public string GetAnswer() => "5]";
    }
}
