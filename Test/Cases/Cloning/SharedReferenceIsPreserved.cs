using System;
using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Cloning
{
    public class SharedReferenceIsPreserved : ITest
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
            var shared = new Inner { Value = 42 };

            original = [
                new() { Key = 1, Child = shared },
                new() { Key = 2, Child = shared }
            ];
            ins = "arr /sort:is";
        }

        public string Run()
        {
            var cloned = Alchemy.Transform(original, ins).ToObject<List<Outer>>();

            // Confirm that the two cloned elements still share one Inner instance
            bool sharedPreserved = ReferenceEquals(cloned[0].Child, cloned[1].Child);

            // Confirm that the shared Inner is a new instance, not the original
            bool sharedIsCloned = !ReferenceEquals(cloned[0].Child, original[0].Child)
                               && !ReferenceEquals(cloned[1].Child, original[0].Child);

            return $"{sharedIsCloned}{TestConstants.SEPARATOR}{sharedPreserved}";
        }

        public string GetAnswer() => $"{bool.TrueString}{TestConstants.SEPARATOR}{bool.TrueString}";
    }
}
