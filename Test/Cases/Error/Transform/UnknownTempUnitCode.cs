namespace SeanOne.Alchemy.Test.Cases.Error.Transform
{
    public class UnknownTempUnitCode : ErrorTestBase<int>
    {
        public UnknownTempUnitCode() : base(5, "cnv /temp:X->Y") { }
    }
}
