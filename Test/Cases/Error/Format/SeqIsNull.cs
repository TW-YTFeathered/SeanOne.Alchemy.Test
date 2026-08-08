using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Error.Format
{
    public class SeqIsNull : ErrorTestBase<List<int>>
    {
        public SeqIsNull() : base(null, "fe /tostring:F2") { }
    }
}
