namespace SeanOne.Alchemy.Test.Cases.Error.Transform
{
    public class ObjIsNull : ErrorTestBase<object>
    {
        public ObjIsNull() : base(null, "/tostring:F2") { }
    }
}
