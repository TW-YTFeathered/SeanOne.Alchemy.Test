using System;

namespace SeanOne.Alchemy.Test.Cases.Error
{
    public abstract class ErrorResultTestBase<TInput> : ITest
    {
        private readonly TInput input;
        private readonly string ins;
        private readonly Action<AlchemyResult> action;

        protected ErrorResultTestBase(TInput input, string ins, Action<AlchemyResult> action)
        {
            this.input = input;
            this.ins = ins;
            this.action = action;
        }

        public void Setup() { /* Put extra initialization here; leave blank for now */ }

        public string Run()
        {
            action(Alchemy.Transform(input, ins));
            return "";
        }

        public string GetAnswer() => "";
    }
}
