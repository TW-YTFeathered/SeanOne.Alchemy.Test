namespace SeanOne.Alchemy.Test.Cases.Error.Transform
{
    public class SingleWeightNegative : ErrorTestBase<double>
    {
        public SingleWeightNegative() : base(-1, "cnv /weight:kg->g") { }
    }
}
