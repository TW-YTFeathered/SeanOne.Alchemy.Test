namespace SeanOne.Alchemy.Test.Cases.Error
{
    public abstract class ErrorTestBase<T> : ITest
    {
        private readonly T input;
        private readonly string[] mulIns;

        protected ErrorTestBase(T input, string ins)
        {
            this.input = input;
            this.mulIns = [ins];
        }

        protected ErrorTestBase(T input, string[] args)
        {
            this.input = input;
            this.mulIns = args;
        }

        public void Setup() { /* Put extra initialization here; leave blank for now */ }

        public string Run() => Alchemy.Transform(input, mulIns).GetString();

        public string GetAnswer() => "";
    }
}
