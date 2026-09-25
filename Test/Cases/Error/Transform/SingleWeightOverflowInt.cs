namespace SeanOne.Alchemy.Test.Cases.Error.Transform
{
    public class SingleWeightOverflowInt : ErrorTestBase<int>
    {
        public SingleWeightOverflowInt() : base(int.MaxValue, "cnv /weight:kg->g") { }
    }
}
