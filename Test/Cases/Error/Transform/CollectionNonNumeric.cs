using System.Collections;

namespace SeanOne.Alchemy.Test.Cases.Error.Transform
{
    public class CollectionNonNumeric : ErrorTestBase<ArrayList>
    {
        public CollectionNonNumeric() : base([1, "abc", 2], "cnv /temp:C->K") { }
    }
}
