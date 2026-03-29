namespace SeanOne.Alchemy.Test.Cases.Basic
{
    public class BasicEnd : ITest
    {
        int x;
        string ins;

        public void Setup()
        {
            x = 5;
            ins = "/end:!";
        }

        public string Run()
        {
            return AlchemyFormatter.Format(x, ins);
        }
    }
}
