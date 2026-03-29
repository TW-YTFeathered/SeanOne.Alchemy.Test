namespace SeanOne.Alchemy.Test.Cases.Error
{
    public class NoDictFormat : ITest
    {
        Dictionary<int, int> x;
        string ins;

        public void Setup()
        {
            x = Enumerable.Range(1, 10).ToDictionary(x => x, x => x * x);
            ins = "fe /value-format:F0";
        }

        public string Run()
        {
            return AlchemyFormatter.Format(x, ins);
        }
    }
}
