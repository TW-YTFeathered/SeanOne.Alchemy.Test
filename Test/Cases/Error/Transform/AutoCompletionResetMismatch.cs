using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Error.Transform
{
    public class AutoCompletionResetMismatch : ErrorTestBase<List<int>>
    {
        public AutoCompletionResetMismatch() : base([0, 100, 25], ["cnv /temp:C->F", "arr /sort:as", "/temp:F->C"]) { }
    }
}
