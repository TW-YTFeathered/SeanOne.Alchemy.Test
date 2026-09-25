using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Error.Transform
{
    public class CollectionWeightOverflowInt : ErrorTestBase<List<int>>
    {
        public CollectionWeightOverflowInt() : base([int.MaxValue], "cnv /weight:kg->g") { }
    }
}
