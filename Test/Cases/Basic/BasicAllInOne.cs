namespace SeanOne.Alchemy.Test.Cases.Basic
{
    public class BasicAllInOne : ITest
    {
        int x;
        string ins;

        public void Setup()
        {
            x = 5;
            ins = "/prefix:[ /end:! /suffix:] /tostring:F2";
        }

        public string Run()
        {
            return AlchemyFormatter.Format(x, ins);
        }
    }
}
