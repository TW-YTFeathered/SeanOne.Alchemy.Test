using System;
using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Error.Result
{
    public class GetDoubleListOnNullElement : ITest
    {
        List<object> x;
        Action<AlchemyResult> action;

        public void Setup()
        {
            x = [1, null, 5];
            action = y => y.GetDoubleList();
        }

        public string Run()
        {
            // Parse is used ONLY to construct a pre-shaped AlchemyResult for
            // extraction tests. Do not use it as a substitute for Transform.
            action(AlchemyResult.Parse(x));
            return "";
        }

        public string GetAnswer() => "";
    }
}
