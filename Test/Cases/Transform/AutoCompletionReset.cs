using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Transform
{
    public class AutoCompletionReset : ITest
    {
        List<int> input;
        string[] ins;

        public void Setup()
        {
            input = [0, 100, 25];
            ins = ["cnv /temp:C->F", "arr /sort:as", "/sort:asd"];
        }

        public string Run() =>
            string.Join(TestConstants.SEPARATOR,
                Alchemy.Transform(input, ins).GetDoubleList());

        public string GetAnswer() => "212,77,32";
    }
}
