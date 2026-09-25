using System;
using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Result
{
    public abstract class ListResultTestBase<TInput, TResult> : ITest
    {
        private readonly List<TInput> input;
        private readonly List<TResult> expected;
        private readonly string ins;
        private readonly Func<AlchemyResult, List<TResult>> extract;

        protected ListResultTestBase(List<TInput> input, List<TResult> expected, string ins, Func<AlchemyResult, List<TResult>> extract)
        {
            this.input = input;
            this.expected = expected;
            this.ins = ins;
            this.extract = extract;
        }

        public void Setup() { /* Put extra initialization here; leave blank for now */ }

        public string Run() =>
            string.Join(TestConstants.SEPARATOR, extract(Alchemy.Transform(input, ins)));

        public string GetAnswer() => string.Join(TestConstants.SEPARATOR, expected);
    }
}
