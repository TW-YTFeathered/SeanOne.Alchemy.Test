using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Sort
{
    public class SortLS_Empty : SortTestBase
    {
        public SortLS_Empty() : base([], [], "arr /sort:ls") { }
    }

    public class SortLSD_Empty : SortTestBase
    {
        public SortLSD_Empty() : base([], [], "arr /sort:lsd") { }
    }

    public class SortLS : SortTestBase
    {
        public SortLS() : base([5, 4, 3, 2, 1], [1, 2, 3, 4, 5], "arr /sort:ls") { }
    }

    public class SortLSD : SortTestBase
    {
        public SortLSD() : base([1, 2, 3, 4, 5], [5, 4, 3, 2, 1], "arr /sort:lsd") { }
    }

    public class SortLS_AlreadySorted : SortTestBase
    {
        public SortLS_AlreadySorted() : base([1, 2, 3, 4, 5], [1, 2, 3, 4, 5], "arr /sort:ls") { }
    }

    public class SortLSD_AlreadySorted : SortTestBase
    {
        public SortLSD_AlreadySorted() : base([5, 4, 3, 2, 1], [5, 4, 3, 2, 1], "arr /sort:lsd") { }
    }

    public class SortLS_Duplicate : SortTestBase
    {
        public SortLS_Duplicate() : base([3, 1, 3, 2, 2], [1, 2, 2, 3, 3], "arr /sort:ls") { }
    }

    public class SortLSD_Duplicate : SortTestBase
    {
        public SortLSD_Duplicate() : base([3, 1, 3, 2, 2], [3, 3, 2, 2, 1], "arr /sort:lsd") { }
    }
}
