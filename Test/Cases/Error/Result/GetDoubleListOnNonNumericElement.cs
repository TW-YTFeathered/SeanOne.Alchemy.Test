using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Error.Result
{
    public class GetDoubleListOnNonNumericElement : ErrorResultTestBase<List<string>>
    {

        public GetDoubleListOnNonNumericElement() : base(["1", "abc", "3"], "arr /sort:is", x => x.GetDoubleList()) { }
    }
}
