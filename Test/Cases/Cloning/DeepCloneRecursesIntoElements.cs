using System;
using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Cloning
{
    public class DeepCloneRecursesIntoElements : ITest
    {
        class Inner
        {
            public int Value;
        }

        class Outer : IComparable
        {
            public int Key;
            public Inner Child;

            public int CompareTo(object obj) => Key.CompareTo(((Outer)obj).Key);
        }

        List<Outer> original;
        string ins;

        public void Setup()
        {
            original = [
                new() { Key = 2, Child = new() { Value = 20 } },
                new() { Key = 1, Child = new() { Value = 10 } }
            ];
            ins = "arr /sort:is";
        }

        public string Run()
        {
            var cloned = Alchemy.Transform(original, ins).ToObject<List<Outer>>();

            // Confirm that each Child is a new Inner instance, not shared with the original
            bool childIsNew = !ReferenceEquals(cloned[0].Child, original[0].Child)
                           && !ReferenceEquals(cloned[0].Child, original[1].Child)
                           && !ReferenceEquals(cloned[1].Child, original[0].Child)
                           && !ReferenceEquals(cloned[1].Child, original[1].Child);

            // Confirm that Child's value survived the recursion into the nested object
            bool childValuePreserved = cloned[0].Child.Value == 10
                                    && cloned[1].Child.Value == 20;

            return $"{childIsNew}{TestConstants.SEPARATOR}{childValuePreserved}";
        }

        public string GetAnswer() => $"{bool.TrueString}{TestConstants.SEPARATOR}{bool.TrueString}";
    }
}
