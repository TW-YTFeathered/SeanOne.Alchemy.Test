namespace SeanOne.Alchemy.Test.Cases.Error
{
    public class FeOnNonEnumerable : ITest
    {
        string x;
        string ins;

        public void Setup()
        {
            x = "Hello World!";
            ins = "fe /tostring:F2";
        }

        public string Run()
        {
            return AlchemyFormatter.Format(x, ins);
        }
    }
}
