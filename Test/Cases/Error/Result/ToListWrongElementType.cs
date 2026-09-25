using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Error.Result
{
    public class ToListWrongElementType : ErrorResultTestBase<List<int>>
    {
        public ToListWrongElementType() : base([1, 2, 3], "arr /sort:is", x => x.ToList<double>()) { }
    }
}
