using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Sort
{
    public class SortIS_Empty : SortTestBase
    {
        public SortIS_Empty() : base(
            input: new List<int>(),
            expected: new List<int>(),
            instruction: "arr /sort:is"
        ) { }
    }

    public class SortISD_Empty : SortTestBase
    {
        public SortISD_Empty() : base(
            input: new List<int>(),
            expected: new List<int>(),
            instruction: "arr /sort:isd"
        ) { }
    }

    public class SortIS : SortTestBase
    {
        public SortIS() : base(
            input: new List<int>() { 5, 4, 3, 2, 1 },
            expected: new List<int>() { 1, 2, 3, 4, 5 },
            instruction: "arr /sort:is"
        ) { }
    }

    public class SortISD : SortTestBase
    {
        public SortISD() : base(
            input: new List<int>() { 1, 2, 3, 4, 5 },
            expected: new List<int>() { 5, 4, 3, 2, 1 },
            instruction: "arr /sort:isd"
        )
        { }
    }

    public class SortIS_AlreadySorted : SortTestBase
    {
        public SortIS_AlreadySorted() : base(
            input: new List<int>() { 1, 2, 3, 4, 5 },
            expected: new List<int>() { 1, 2, 3, 4, 5 },
            instruction: "arr /sort:is"
        ) { }
    }

    public class SortISD_AlreadySorted : SortTestBase
    {
        public SortISD_AlreadySorted() : base(
            input: new List<int>() { 5, 4, 3, 2, 1 },
            expected: new List<int>() { 5, 4, 3, 2, 1 },
            instruction: "arr /sort:isd"
        ) { }
    }

    public class SortIS_Duplicate : SortTestBase
    {
        public SortIS_Duplicate() : base(
            input: new List<int>() { 3, 1, 3, 2, 2 },
            expected: new List<int>() { 1, 2, 2, 3, 3 },
            instruction: "arr /sort:is"
        ) { }
    }

    public class SortISD_Duplicate : SortTestBase
    {
        public SortISD_Duplicate() : base(
            input: new List<int>() { 3, 1, 3, 2, 2 },
            expected: new List<int>() { 3, 3, 2, 2, 1 },
            instruction: "arr /sort:isd"
        ) { }
    }
}
