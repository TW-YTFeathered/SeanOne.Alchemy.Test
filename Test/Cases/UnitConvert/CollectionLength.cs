namespace SeanOne.Alchemy.Test.Cases.UnitConvert
{
    public class CollectionLengthCMToM : CollectionConvertTestBase
    {
        public CollectionLengthCMToM() : base([100, 200, 300], [1, 2, 3], "cnv /length:cm->m") { }
    }

    public class CollectionLengthMToCM : CollectionConvertTestBase
    {
        public CollectionLengthMToCM() : base([1, 2, 3], [100, 200, 300], "cnv /length:m->cm") { }
    }

    public class CollectionLengthMiToKm : CollectionConvertTestBase
    {
        public CollectionLengthMiToKm() : base([1, 2, 3], [1.609344, 3.218688, 4.828032], "cnv /length:mi->km") { }
    }
}
