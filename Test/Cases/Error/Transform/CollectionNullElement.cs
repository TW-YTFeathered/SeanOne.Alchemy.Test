namespace SeanOne.Alchemy.Test.Cases.Error.Transform
{
    public class CollectionNullElement : ErrorTestBase<double?[]>
    {
        public CollectionNullElement() : base([1, null, 5], "cnv /temp:C->K") { }
    }
}
