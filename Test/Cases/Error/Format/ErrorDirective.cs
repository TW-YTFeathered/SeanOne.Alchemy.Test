using System.Collections.Generic;
using System.Linq;

namespace SeanOne.Alchemy.Test.Cases.Error.Format
{
    public class ErrorDirective : ErrorTestBase<List<int>>
    {
        public ErrorDirective() : base(Enumerable.Range(0, 10).ToList(), "loop /tostring:F2") { }
    }
}
