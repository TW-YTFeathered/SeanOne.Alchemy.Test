namespace SeanOne.Alchemy.Test.Cases.UnitConvert
{
    public class SingleTempCToF : SingleConvertTestBase
    {
        public SingleTempCToF() : base(-40, -40, "cnv /temp:c->f") { }
    }

    public class SingleTempFToC : SingleConvertTestBase
    {
        public SingleTempFToC() : base(32, 0, "cnv /temp:f->c") { }
    }

    public class SingleTempCToK : SingleConvertTestBase
    {
        public SingleTempCToK() : base(10, 283.15, "cnv /temp:c->k") { }
    }

    public class SingleTempKToC : SingleConvertTestBase
    {
        public SingleTempKToC() : base(273.15, 0, "cnv /temp:k->c") { }
    }

    public class SingleTempFToK : SingleConvertTestBase
    {
        public SingleTempFToK() : base(32, 273.15, "cnv /temp:f->k") { }
    }

    public class SingleTempKToF : SingleConvertTestBase
    {
        public SingleTempKToF() : base(0, -459.67, "cnv /temp:k->f") { }
    }
}
