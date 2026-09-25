namespace SeanOne.Alchemy.Test.Cases.UnitConvert
{
    public class CollectionWeightKgToG : CollectionConvertTestBase
    {
        public CollectionWeightKgToG() : base([1, 2, 3], [1000, 2000, 3000], "cnv /weight:kg->g") { }
    }

    public class CollectionWeightLbToKg : CollectionConvertTestBase
    {
        public CollectionWeightLbToKg() : base([1, 2, 3], [0.45359237, 0.90718474, 1.36077711], "cnv /weight:lb->kg") { }
    }

    public class CollectionWeightOzToG : CollectionConvertTestBase
    {
        public CollectionWeightOzToG() : base([1, 2, 3], [28.349523125, 56.69904625, 85.048569375], "cnv /weight:oz->g") { }
    }
}
