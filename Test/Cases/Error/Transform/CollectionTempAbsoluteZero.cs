namespace SeanOne.Alchemy.Test.Cases.Error.Transform
{
    public class CollectionTempAbsoluteZero : ErrorTestBase<double[]>
    {
        public CollectionTempAbsoluteZero() : base([0, -300, 100], "cnv /temp:C->K") { }
    }
}
