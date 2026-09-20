using System.Collections.Generic;
using System.Linq;

namespace SeanOne.Alchemy.Test.Cases.Cloning
{
    public class TransformReturnsNewListReference : ITest
    {
        List<int> original;
        string ins;

        public void Setup()
        {
            original = Enumerable.Range(1, 10).ToList();
            ins = "arr /sort:isd";
        }

        public string Run() =>
            ReferenceEquals(original, Alchemy.Transform(original, ins).ToObject<List<int>>()).ToString();

        public string GetAnswer() => bool.FalseString;
    }
}
