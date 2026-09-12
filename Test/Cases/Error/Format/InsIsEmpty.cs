namespace SeanOne.Alchemy.Test.Cases.Error.Format
{
    public class InsIsEmpty : ITest
    {
        int x;
        string ins;

        public void Setup()
        {
            x = 5;
            ins = "";
        }

        public string Run() => Alchemy.Format(x, ins);

        public string GetAnswer() => "";
    }
}
