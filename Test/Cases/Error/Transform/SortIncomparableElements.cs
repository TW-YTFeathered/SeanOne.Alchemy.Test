using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Error.Transform
{
    public class SortIncomparableElements : ErrorTestBase<List<SortIncomparableElements.Item>>
    {
        public struct Item
        {
            public int Value { get; set; }

            public Item(int value)
            {
                Value = value;
            }
        }

        public SortIncomparableElements() : base([new(1), new(2)], "arr /sort:is") { }
    }
}
