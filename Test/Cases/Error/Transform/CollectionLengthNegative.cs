namespace SeanOne.Alchemy.Test.Cases.Error.Transform
{
    public class CollectionLengthNegative : ErrorTestBase<double[]>
    {
        public CollectionLengthNegative() : base([1, -5, 10], "cnv /length:m->cm") { }
    }
}
