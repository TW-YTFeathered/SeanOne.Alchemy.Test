using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Error.Transform
{
    public class AutoCompletionMismatch : ErrorTestBase<List<int>>
    {
        public AutoCompletionMismatch() : base([1, 2, 3], ["arr /sort:is", "/temp:C->F"]) { }
    }
}
