namespace SeanOne.Alchemy.Test.Cases.Error.Utility
{
    public class ParamNameCaseSensitive : ErrorTestBase<int>
    {
        public ParamNameCaseSensitive() : base(5, "/ToString:F2") { }
    }
}
