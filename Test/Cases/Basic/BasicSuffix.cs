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

        public string Run()
        {
            return AlchemyFormatter.Format(x, ins);
        }
    }
}
