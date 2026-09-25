namespace SeanOne.Alchemy.Test.Cases.Error.Result
{
    public class ToListOnNonEnumerable : ErrorResultTestBase<int>
    {
        public ToListOnNonEnumerable() : base(5, "cnv /length:cm->m", x => x.ToList<int>()) { }
    }
}
