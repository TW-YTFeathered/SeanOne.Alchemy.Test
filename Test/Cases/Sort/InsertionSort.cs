using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Sort
{
    public class SortIS_Empty : SortTestBase
    {
        public SortIS_Empty() : base(new List<int>(), new List<int>(), "arr /sort:is") { }
    }

    public class SortISD_Empty : SortTestBase
    {
        public SortISD_Empty() : base(new List<int>(), new List<int>(), "arr /sort:isd") { }
    }

    public class SortIS : SortTestBase
    {
        public SortIS() : base(new List<int>() { 5, 4, 3, 2, 1 }, new List<int>() { 1, 2, 3, 4, 5 }, "arr /sort:is") { }
    }

    public class SortISD : SortTestBase
    {
        public SortISD() : base(new List<int>() { 1, 2, 3, 4, 5 }, new List<int>() { 5, 4, 3, 2, 1 }, "arr /sort:isd") { }
    }

    public class SortIS_AlreadySorted : SortTestBase
    {
        public SortIS_AlreadySorted() : base(new List<int>() { 1, 2, 3, 4, 5 }, new List<int>() { 1, 2, 3, 4, 5 }, "arr /sort:is") { }
    }

    public class SortISD_AlreadySorted : SortTestBase
    {
        public SortISD_AlreadySorted() : base(new List<int>() { 5, 4, 3, 2, 1 }, new List<int>() { 5, 4, 3, 2, 1 }, "arr /sort:isd") { }
    }

    public class SortIS_Duplicate : SortTestBase
    {
        public SortIS_Duplicate() : base(new List<int>() { 3, 1, 3, 2, 2 }, new List<int>() { 1, 2, 2, 3, 3 }, "arr /sort:is") { }
    }

    public class SortISD_Duplicate : SortTestBase
    {
        public SortISD_Duplicate() : base(new List<int>() { 3, 1, 3, 2, 2 }, new List<int>() { 3, 3, 2, 2, 1 }, "arr /sort:isd") { }
    }
}
