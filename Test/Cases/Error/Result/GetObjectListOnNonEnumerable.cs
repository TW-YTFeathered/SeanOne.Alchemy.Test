namespace SeanOne.Alchemy.Test.Cases.Error.Result
{
    public class GetObjectListOnNonEnumerable : ErrorResultTestBase<int>
    {
        public GetObjectListOnNonEnumerable() : base(5, "cnv /length:cm->m", x => x.GetObjectList()) { }
    }
}
