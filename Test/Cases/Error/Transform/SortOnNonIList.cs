using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Error.Transform
{
    public class SortOnNonIList : ErrorTestBase<HashSet<int>>
    {
        public SortOnNonIList() : base([1, 2, 3], "arr /sort:is") { }
    }
}
