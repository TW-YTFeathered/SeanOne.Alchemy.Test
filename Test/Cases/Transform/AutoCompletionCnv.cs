namespace SeanOne.Alchemy.Test.Cases.Transform
{
    public class AutoCompletionCnv : ITest
    {
        double input;
        string[] ins;

        public void Setup()
        {
            input = 100;
            ins = ["cnv /weight:Kg->G", "/length:CM->M"];
        }

        public string Run() => Alchemy.Transform(input, ins).GetDouble().ToString(TestConstants.NUMBER_FORMAT);

        public string GetAnswer() => "1000";
    }
}
