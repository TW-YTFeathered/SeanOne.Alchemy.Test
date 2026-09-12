namespace SeanOne.Alchemy.Test.Cases.Error.Format
{
    public class UnknownDirective : ITest
    {
        int x;
        string ins;

        public void Setup()
        {
            x = 5;
            ins = "loop /tostring:F2";
        }

        public string Run() => Alchemy.Format(x, ins);

        public string GetAnswer() => "";
    }
}
