using System.Collections.Generic;
using System.Linq;

namespace SeanOne.Alchemy.Test.Cases.Error.Format
{
    public class NoDictFormatWithFeOpt : ErrorTestBase<Dictionary<int, int>>
    {
        public NoDictFormatWithFeOpt() : base(Enumerable.Range(1, 10).ToDictionary(x => x, x => x * x), "fe /value-format:F0 /fe-opt:true") { }
    }
}
