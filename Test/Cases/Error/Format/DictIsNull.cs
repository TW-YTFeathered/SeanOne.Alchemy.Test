using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Error.Format
{
    public class DictIsNull : ErrorTestBase<Dictionary<int, int>>
    {
        public DictIsNull() : base(null, "") { }
    }
}
