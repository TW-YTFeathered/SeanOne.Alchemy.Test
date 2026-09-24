namespace SeanOne.Alchemy.Test.Cases.Error
{
    public abstract class ErrorTestBase<T> : ITest
    {
        private readonly T input;
        private readonly string[] insList;

        protected ErrorTestBase(T input, string ins) : this(input, [ins]) { }

        protected ErrorTestBase(T input, string[] insList)
        {
            this.input = input;
            this.insList = insList;
        }

        public void Setup() { /* Put extra initialization here; leave blank for now */ }

        public string Run() => Alchemy.Transform(input, insList).GetString();

        public string GetAnswer() => "";
    }
}
