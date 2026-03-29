namespace SeanOne.Alchemy.Test.Cases.Basic
{
    public class BasicPrefix : ITest
    {
        int x;
        string ins;

        public void Setup()
        {
            x = 5;
            ins = "/prefix:[";
        }

        public string Run()
        {
            return AlchemyFormatter.Format(x, ins);
        }
    }
}
