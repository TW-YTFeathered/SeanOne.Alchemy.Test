using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Sort
{
    public class SortIS_Empty : SortTestBase
    {
        public SortIS_Empty() : base([], [], "arr /sort:is") { }
    }

    public class SortISD_Empty : SortTestBase
    {
        public SortISD_Empty() : base([], [], "arr /sort:isd") { }
    }

    public class SortIS : SortTestBase
    {
        public SortIS() : base([5, 4, 3, 2, 1], [1, 2, 3, 4, 5], "arr /sort:is") { }
    }

    public class SortISD : SortTestBase
    {
        public SortISD() : base([1, 2, 3, 4, 5], [5, 4, 3, 2, 1], "arr /sort:isd") { }
    }

    public class SortIS_AlreadySorted : SortTestBase
    {
        public SortIS_AlreadySorted() : base([1, 2, 3, 4, 5], [1, 2, 3, 4, 5], "arr /sort:is") { }
    }

    public class SortISD_AlreadySorted : SortTestBase
    {
        public SortISD_AlreadySorted() : base([5, 4, 3, 2, 1], [5, 4, 3, 2, 1], "arr /sort:isd") { }
    }

    public class SortIS_Duplicate : SortTestBase
    {
        public SortIS_Duplicate() : base([3, 1, 3, 2, 2], [1, 2, 2, 3, 3], "arr /sort:is") { }
    }

    public class SortISD_Duplicate : SortTestBase
    {
        public SortISD_Duplicate() : base([3, 1, 3, 2, 2], [3, 3, 2, 2, 1], "arr /sort:isd") { }
    }
}
