namespace SeanOne.Alchemy.Test.Cases.Error
{
    public abstract class ErrorTestBase<T> : ITest
    {
        private readonly T input;
        private readonly string ins;

        protected ErrorTestBase(T input, string ins)
        {
            this.input = input;
            this.ins = ins;
        }

        public void Setup() { /* Put extra initialization here; leave blank for now */ }

        public string Run() => Alchemy.Transform(input, ins).GetString();

        public string GetAnswer() => "";
    }
}
