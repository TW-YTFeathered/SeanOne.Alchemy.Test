namespace SeanOne.Alchemy.Test.Cases.Error
{
    public class ParamRepet : ITest
    {
        List<int> x;
        string ins;

        public void Setup()
        {
            x = Enumerable.Range(0, 10).ToList();
            ins = "fe /tostring:F2 /tostring:F3";
        }

        public string Run()
        {
            return AlchemyFormatter.Format(x, ins);
        }
    }
}
