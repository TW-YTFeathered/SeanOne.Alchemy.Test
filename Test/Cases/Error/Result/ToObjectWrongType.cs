namespace SeanOne.Alchemy.Test.Cases.Error.Result
{
    public class ToObjectWrongType : ErrorResultTestBase<int>
    {
        public ToObjectWrongType() : base(12, "cnv /length:cm->m", x => x.ToObject<string>()) { }
    }
}
