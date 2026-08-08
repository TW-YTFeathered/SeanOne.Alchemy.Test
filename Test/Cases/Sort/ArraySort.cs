using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Sort
{
    public class SortAS_Empty : SortTestBase
    {
        public SortAS_Empty() : base(new List<int>(), new List<int>(), "arr /sort:as") { }
    }

    public class SortASD_Empty : SortTestBase
    {
        public SortASD_Empty() : base(new List<int>(), new List<int>(), "arr /sort:asd") { }
    }

    public class SortAS : SortTestBase
    {
        public SortAS() : base(new List<int>() { 5, 4, 3, 2, 1 }, new List<int>() { 1, 2, 3, 4, 5 }, "arr /sort:as") { }
    }

    public class SortASD : SortTestBase
    {
        public SortASD() : base(new List<int>() { 1, 2, 3, 4, 5 }, new List<int>() { 5, 4, 3, 2, 1 }, "arr /sort:asd") { }
    }

    public class SortAS_AlreadySorted : SortTestBase
    {
        public SortAS_AlreadySorted() : base(new List<int>() { 1, 2, 3, 4, 5 }, new List<int>() { 1, 2, 3, 4, 5 }, "arr /sort:as") { }
    }

    public class SortASD_AlreadySorted : SortTestBase
    {
        public SortASD_AlreadySorted() : base(new List<int>() { 5, 4, 3, 2, 1 }, new List<int>() { 5, 4, 3, 2, 1 }, "arr /sort:asd") { }
    }

    public class SortAS_Duplicate : SortTestBase
    {
        public SortAS_Duplicate() : base(new List<int>() { 3, 1, 3, 2, 2 }, new List<int>() { 1, 2, 2, 3, 3 }, "arr /sort:as") { }
    }

    public class SortASD_Duplicate : SortTestBase
    {
        public SortASD_Duplicate() : base(new List<int>() { 3, 1, 3, 2, 2 }, new List<int>() { 3, 3, 2, 2, 1 }, "arr /sort:asd") { }
    }
}
