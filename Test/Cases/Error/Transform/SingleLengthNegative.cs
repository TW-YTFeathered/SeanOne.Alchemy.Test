namespace SeanOne.Alchemy.Test.Cases.Error.Transform
{
    public class SingleLengthNegative : ErrorTestBase<double>
    {
        public SingleLengthNegative() : base(-5, "cnv /length:m->cm") { }
    }
}
