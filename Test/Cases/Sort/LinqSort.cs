using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Sort
{
    public class SortLS_Empty : SortTestBase
    {
        public SortLS_Empty() : base(
            input: new List<int>(),
            expected: new List<int>(),
            instruction: "arr /sort:ls"
        ) { }
    }

    public class SortLSD_Empty : SortTestBase
    {
        public SortLSD_Empty() : base(
            input: new List<int>(),
            expected: new List<int>(),
            instruction: "arr /sort:lsd"
        ) { }
    }

    public class SortLS : SortTestBase
    {
        public SortLS() : base(
            input: new List<int>() { 5, 4, 3, 2, 1 },
            expected: new List<int>() { 1, 2, 3, 4, 5 },
            instruction: "arr /sort:ls"
        ) { }
    }

    public class SortLSD : SortTestBase
    {
        public SortLSD() : base(
            input: new List<int>() { 1, 2, 3, 4, 5 },
            expected: new List<int>() { 5, 4, 3, 2, 1 },
            instruction: "arr /sort:lsd"
        )
        { }
    }

    public class SortLS_AlreadySorted : SortTestBase
    {
        public SortLS_AlreadySorted() : base(
            input: new List<int>() { 1, 2, 3, 4, 5 },
            expected: new List<int>() { 1, 2, 3, 4, 5 },
            instruction: "arr /sort:ls"
        ) { }
    }

    public class SortLSD_AlreadySorted : SortTestBase
    {
        public SortLSD_AlreadySorted() : base(
            input: new List<int>() { 5, 4, 3, 2, 1 },
            expected: new List<int>() { 5, 4, 3, 2, 1 },
            instruction: "arr /sort:lsd"
        ) { }
    }

    public class SortLS_Duplicate : SortTestBase
    {
        public SortLS_Duplicate() : base(
            input: new List<int>() { 3, 1, 3, 2, 2 },
            expected: new List<int>() { 1, 2, 2, 3, 3 },
            instruction: "arr /sort:ls"
        ) { }
    }

    public class SortLSD_Duplicate : SortTestBase
    {
        public SortLSD_Duplicate() : base(
            input: new List<int>() { 3, 1, 3, 2, 2 },
            expected: new List<int>() { 3, 3, 2, 2, 1 },
            instruction: "arr /sort:lsd"
        ) { }
    }
}
