namespace SeanOne.Alchemy.Test.Cases.UnitConvert
{
    public class CollectionTempCToF : CollectionConvertTestBase
    {
        public CollectionTempCToF() : base([0, 100, -40], [32, 212, -40], "cnv /temp:c->f") { }
    }

    public class CollectionTempFToC : CollectionConvertTestBase
    {
        public CollectionTempFToC() : base([32, 212, -40], [0, 100, -40], "cnv /temp:f->c") { }
    }

    public class CollectionTempCToK : CollectionConvertTestBase
    {
        public CollectionTempCToK() : base([0, 100, -273.15], [273.15, 373.15, 0], "cnv /temp:c->k") { }
    }

    public class CollectionTempKToF : CollectionConvertTestBase
    {
        public CollectionTempKToF() : base([273.15, 373.15], [32, 212], "cnv /temp:k->f") { }
    }
}
