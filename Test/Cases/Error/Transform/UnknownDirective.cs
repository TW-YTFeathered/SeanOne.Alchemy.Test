namespace SeanOne.Alchemy.Test.Cases.Error.Transform
{
    public class UnknownDirective : ErrorTestBase<int>
    {
        public UnknownDirective() : base(5, "loop /tostring:F2") { }
    }
}
