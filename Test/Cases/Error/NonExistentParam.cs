namespace SeanOne.Alchemy.Test.Cases.Error
{
    public class NonExistentParam : ITest
    {
        List<int> x;
        string ins;

        public void Setup()
        {
            x = Enumerable.Range(0, 10).ToList();
            ins = "fe /ts:F2";
        }

        public string Run()
        {
            return AlchemyFormatter.Format(x, ins);
        }
    }
}
