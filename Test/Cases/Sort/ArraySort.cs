using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Sort
{
    public class SortAS_Empty : SortTestBase
    {
        public SortAS_Empty() : base(
            input: new List<int>(),
            expected: new List<int>(),
            instruction: "arr /sort:as"
        ) { }
    }

    public class SortAS_Ascending : SortTestBase
    {
        public SortAS_Ascending() : base(
            input: new List<int>() { 5, 4, 3, 2, 1 },
            expected: new List<int>() { 1, 2, 3, 4, 5 },
            instruction: "arr /sort:as"
        ) { }
    }

    public class SortAS_AlreadySorted : SortTestBase
    {
        public SortAS_AlreadySorted() : base(
            input: new List<int>() { 1, 2, 3, 4, 5 },
            expected: new List<int>() { 1, 2, 3, 4, 5 },
            instruction: "arr /sort:as"
        ) { }
    }

    public class SortAS_Descending : SortTestBase
    {
        public SortAS_Descending() : base(
            input: new List<int>() { 1, 2, 3, 4, 5 },
            expected: new List<int>() { 5, 4, 3, 2, 1 },
            instruction: "arr /sort:asd"
        ) { }
    }

    public class SortAS_AlreadySortedDesc : SortTestBase
    {
        public SortAS_AlreadySortedDesc() : base(
            input: new List<int>() { 3, 1, 3, 2, 2 },
            expected: new List<int>() { 5, 4, 3, 2, 1 },
            instruction: "arr /sort:asd"
        ) { }
    }

    public class SortAS_Duplicate : SortTestBase
    {
        public SortAS_Duplicate() : base(
            input: new List<int>() { 3, 1, 3, 2, 2 },
            expected: new List<int>() { 1, 2, 2, 3, 3 },
            instruction: "arr /sort:as"
        ) { }
    }
}
