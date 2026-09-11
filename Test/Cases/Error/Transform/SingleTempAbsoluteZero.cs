namespace SeanOne.Alchemy.Test.Cases.Error.Transform
{
    public class SingleTempAbsoluteZero : ErrorTestBase<double>
    {
        public SingleTempAbsoluteZero() : base(-300, "cnv /temp:C->K") { }
    }
}
