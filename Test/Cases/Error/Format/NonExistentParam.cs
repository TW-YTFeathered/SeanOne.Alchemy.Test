using System.Collections.Generic;
using System.Linq;

namespace SeanOne.Alchemy.Test.Cases.Error.Format
{
    public class NonExistentParam : ErrorTestBase<List<int>>
    {
        public NonExistentParam() : base(Enumerable.Range(0, 10).ToList(), "fe /ts:F2") { }
    }
}
