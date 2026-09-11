namespace SeanOne.Alchemy.Test.Cases.Error.Transform
{
    public class CollectionWeightNegative : ErrorTestBase<double[]>
    {
        public CollectionWeightNegative() : base([0, -12, 5], "cnv /weight:g->cg") { }
    }
}
