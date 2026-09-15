namespace SeanOne.Alchemy.Test.Cases.UnitConvert
{
    public class SingleWeightKgToG_ToForm : SingleConvertTestBase
    {
        public SingleWeightKgToG_ToForm() : base(1, 1000, "cnv /weight:KgToG") { }
    }

    public class SingleTempCToF_ToForm : SingleConvertTestBase
    {
        public SingleTempCToF_ToForm() : base(25, 77, "cnv /temp:CtoF") { }
    }

    public class SingleLengthMToKm_ToFormLower : SingleConvertTestBase
    {
        public SingleLengthMToKm_ToFormLower() : base(1000, 1, "cnv /length:mtokm") { }
    }
}
