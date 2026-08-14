namespace SeanOne.Alchemy.Test.Cases.UnitConvert
{
    public abstract class SingleConvertTestBase : ITest
    {
        private readonly double input;
        private readonly double expected;
        private readonly string ins;

        protected SingleConvertTestBase(double input, double expected, string ins)
        {
            this.input = input;
            this.expected = expected;
            this.ins = ins;
        }

        public void Setup() { /* Put extra initialization here; leave blank for now */ }

        public string Run() => Alchemy.Transform(input, ins).GetDouble().ToString(TestConstants.NUMBER_FORMAT);

        public string GetAnswer() => expected.ToString(TestConstants.NUMBER_FORMAT);
    }
}
