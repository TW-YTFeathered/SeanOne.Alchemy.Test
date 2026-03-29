namespace SeanOne.Alchemy.Test.Cases.Error
{
    public class NonIFormattable : ITest
    {
        List<string> x;
        string ins;

        public void Setup()
        {
            x = Enumerable.Range(0, 10).Select(x => x.ToString()).ToList();
            ins = "fe /tostring:F2";
        }

        public string Run()
        {
            return AlchemyFormatter.Format(x, ins);
        }
    }
}
