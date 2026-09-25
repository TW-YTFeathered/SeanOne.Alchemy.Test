using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Error.Transform
{
    public class UnknownSortAlgorithmKey : ErrorTestBase<List<int>>
    {
        public UnknownSortAlgorithmKey() : base([1, 2, 3], "arr /sort:xxxx") { }
    }
}
