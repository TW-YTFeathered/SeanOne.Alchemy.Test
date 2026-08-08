using System.Collections.Generic;
using System.Linq;

namespace SeanOne.Alchemy.Test.Cases.Error.Format
{
    public class NonIFormattable : ErrorTestBase<List<string>>
    {
        public NonIFormattable() : base(Enumerable.Range(0, 10).Select(x => x.ToString()).ToList(), "fe /tostring:F2") { }
    }
}
