using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Sort
{
    public abstract class SortTestBase : ITest
    {
        private readonly List<int> input;
        private readonly List<int> expected;
        private readonly string ins;

        protected SortTestBase(List<int> input, List<int> expected, string instruction)
        {
            this.input = input;
            this.expected = expected;
            this.ins = instruction;
        }

        public void Setup() { /* Put extra initialization here; leave blank for now */ }

        public string Run() =>
            string.Join(string.Empty, Alchemy.Transform(input, ins).GetInt32List());

        public string GetAnswer() => string.Join(string.Empty, expected);
    }
}
