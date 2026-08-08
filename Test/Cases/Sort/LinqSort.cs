using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Sort
{
    public class SortLS_Empty : SortTestBase
    {
        public SortLS_Empty() : base(new List<int>(), new List<int>(), "arr /sort:ls") { }
    }

    public class SortLSD_Empty : SortTestBase
    {
        public SortLSD_Empty() : base(new List<int>(), new List<int>(), "arr /sort:lsd") { }
    }

    public class SortLS : SortTestBase
    {
        public SortLS() : base(new List<int>() { 5, 4, 3, 2, 1 }, new List<int>() { 1, 2, 3, 4, 5 }, "arr /sort:ls") { }
    }

    public class SortLSD : SortTestBase
    {
        public SortLSD() : base(new List<int>() { 1, 2, 3, 4, 5 }, new List<int>() { 5, 4, 3, 2, 1 }, "arr /sort:lsd") { }
    }

    public class SortLS_AlreadySorted : SortTestBase
    {
        public SortLS_AlreadySorted() : base(new List<int>() { 1, 2, 3, 4, 5 }, new List<int>() { 1, 2, 3, 4, 5 }, "arr /sort:ls") { }
    }

    public class SortLSD_AlreadySorted : SortTestBase
    {
        public SortLSD_AlreadySorted() : base(new List<int>() { 5, 4, 3, 2, 1 }, new List<int>() { 5, 4, 3, 2, 1 }, "arr /sort:lsd") { }
    }

    public class SortLS_Duplicate : SortTestBase
    {
        public SortLS_Duplicate() : base(new List<int>() { 3, 1, 3, 2, 2 }, new List<int>() { 1, 2, 2, 3, 3 }, "arr /sort:ls") { }
    }

    public class SortLSD_Duplicate : SortTestBase
    {
        public SortLSD_Duplicate() : base(new List<int>() { 3, 1, 3, 2, 2 }, new List<int>() { 3, 3, 2, 2, 1 }, "arr /sort:lsd") { }
    }
}
