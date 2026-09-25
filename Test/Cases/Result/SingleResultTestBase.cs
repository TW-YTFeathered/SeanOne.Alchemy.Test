using System;

namespace SeanOne.Alchemy.Test.Cases.Result
{
    public abstract class SingleResultTestBase<TInput> : ITest
    {
        private readonly TInput input;
        private readonly string ins;
        private readonly Func<AlchemyResult, string> extract;
        private readonly string expected;

        protected SingleResultTestBase(TInput input, string expected, string ins, Func<AlchemyResult, string> extract)
        {
            this.input = input;
            this.expected = expected;
            this.ins = ins;
            this.extract = extract;
        }

        public void Setup() { /* Put extra initialization here; leave blank for now */ }

        public string Run() => extract(Alchemy.Transform(input, ins));

        public string GetAnswer() => expected;
    }
}
