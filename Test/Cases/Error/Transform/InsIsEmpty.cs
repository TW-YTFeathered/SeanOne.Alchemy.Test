namespace SeanOne.Alchemy.Test.Cases.Error.Transform
{
    public class InsIsEmpty : ErrorTestBase<int>
    {
        public InsIsEmpty() : base(5, "") { }
    }
}
