namespace SeanOne.Alchemy.Test.Cases.Error.Format
{
    public class FeOnNonEnumerable : ErrorTestBase<string>
    {
        public FeOnNonEnumerable() : base("Hello World!", "fe /tostring:F2") { }
    }
}
