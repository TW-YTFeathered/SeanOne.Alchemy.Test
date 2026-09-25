namespace SeanOne.Alchemy.Test.Cases.Sort
{
    public class SortInsertionFirstWord : SortTestBase
    {
        public SortInsertionFirstWord() : base([5, 4, 3, 2, 1], [1, 2, 3, 4, 5], "arr /sort:insertion") { }
    }

    public class SortInsertionFullName : SortTestBase
    {
        public SortInsertionFullName() : base([5, 4, 3, 2, 1], [1, 2, 3, 4, 5], "arr /sort:insertionsort") { }
    }

    public class SortInsertionDescFirstWord : SortTestBase
    {
        public SortInsertionDescFirstWord() : base([1, 2, 3, 4, 5], [5, 4, 3, 2, 1], "arr /sort:insertiondesc") { }
    }

    public class SortInsertionFullNameDescending : SortTestBase
    {
        public SortInsertionFullNameDescending() : base([1, 2, 3, 4, 5], [5, 4, 3, 2, 1], "arr /sort:insertionsortdescending") { }
    }
}
