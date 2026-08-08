using System.Collections.Generic;
using System.Linq;

namespace SeanOne.Alchemy.Test.Cases.Error.Format
{
    public class ParamRepet : ErrorTestBase<List<int>>
    {
        public ParamRepet() : base(Enumerable.Range(0, 10).ToList(), "fe /tostring:F2 /tostring:F3") { }
    }
}
