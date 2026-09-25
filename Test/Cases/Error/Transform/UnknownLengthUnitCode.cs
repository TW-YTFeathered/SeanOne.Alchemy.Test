namespace SeanOne.Alchemy.Test.Cases.Error.Transform
{
    public class UnknownLengthUnitCode : ErrorTestBase<int>
    {
        public UnknownLengthUnitCode() : base(5, "cnv /length:XX->YY") { }
    }
}
