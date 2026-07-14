namespace SeanOne.Alchemy.Test.Cases.FeDict
{
    public class FeSuffix : ITest
    {
        Dictionary<int, int> x;
        string ins;

        public void Setup()
        {
            x = Enumerable.Range(1, 10).ToDictionary(x => x, x => x * x);
            ins = "fe /dict-format:{0}=>{1} /suffix:]";
        }

        public string Run() => Alchemy.Format(x, ins);

        public string GetAnswer() => "1=>12=>43=>94=>165=>256=>367=>498=>649=>8110=>100]";
    }
}
