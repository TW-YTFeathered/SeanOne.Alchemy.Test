namespace SeanOne.Alchemy.Test.Cases.Basic
{
    public class BasicToString : ITest
    {
        int x;
        string ins;

        public void Setup()
        {
            x = 5;
            ins = "/tostring:F2";
        }

        public string Run()
        {
            return AlchemyFormatter.Format(x, ins);
        }
    }
}
