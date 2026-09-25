using System.Collections.Generic;
using System.Linq;

namespace SeanOne.Alchemy.Test.Cases.Result
{
    public class RepeatedExtractionFromTransformValue : ITest
    {
        AlchemyResult result;

        public void Setup() =>
            result = Alchemy.Transform(new List<int> { 1, 2, 3 }, "arr /sort:is");

        public string Run()
        {
            var first = result.GetInt32List();
            var second = result.GetInt32List();

            bool valueStable = first.SequenceEqual(second);
            bool independent = !ReferenceEquals(first, second);

            return $"{valueStable}{TestConstants.SEPARATOR}{independent}";
        }

        public string GetAnswer() =>
            $"{bool.TrueString}{TestConstants.SEPARATOR}{bool.TrueString}";
    }
}
