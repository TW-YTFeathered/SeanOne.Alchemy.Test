using System.Collections.Generic;
using System.Linq;

namespace SeanOne.Alchemy.Test.Cases.UnitConvert
{
    public abstract class CollectionConvertTestBase : ITest
    {
        private readonly List<double> input;
        private readonly List<double> expected;
        private readonly string ins;

        protected CollectionConvertTestBase(List<double> input, List<double> expected, string ins)
        {
            this.input = input;
            this.expected = expected;
            this.ins = ins;
        }

        public void Setup() { /* Put extra initialization here; leave blank for now */ }

        public string Run() => 
            string.Join(TestConstants.SEPARATOR, Alchemy.Transform(input, ins).GetDoubleList().Select(x => x.ToString(TestConstants.NUMBER_FORMAT)));

        public string GetAnswer() =>
            string.Join(TestConstants.SEPARATOR, expected.Select(x => x.ToString(TestConstants.NUMBER_FORMAT)));
    }
}
