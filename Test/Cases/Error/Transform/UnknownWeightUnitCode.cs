namespace SeanOne.Alchemy.Test.Cases.Error.Transform
{
    public class UnknownWeightUnitCode : ErrorTestBase<int>
    {
        public UnknownWeightUnitCode() : base(5, "cnv /weight:XX->YY") { }
    }
}
