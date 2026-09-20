using System;
using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Cloning
{
    public class CircularReferenceDoesNotStackOverflow : ITest
    {
        class Node : IComparable
        {
            public int Key;
            public Node Partner;
            public int CompareTo(object obj) => Key.CompareTo(((Node)obj).Key);
        }

        List<Node> original;
        string ins;

        public void Setup()
        {
            var a = new Node { Key = 2 };
            var b = new Node { Key = 1 };
            a.Partner = b;
            b.Partner = a;

            original = [a, b];
            ins = "arr /sort:is";
        }

        public string Run()
        {
            var cloned = Alchemy.Transform(original, ins).ToObject<List<Node>>();

            // Confirm that the cloned element is a new object
            bool elementsAreNew = !ReferenceEquals(cloned[0], original[0])
                               && !ReferenceEquals(cloned[0], original[1])
                               && !ReferenceEquals(cloned[1], original[0])
                               && !ReferenceEquals(cloned[1], original[1]);

            // Confirm that the cycle relationship is preserved
            bool cyclePreserved = ReferenceEquals(cloned[0].Partner, cloned[1])
                               && ReferenceEquals(cloned[1].Partner, cloned[0]);

            // Confirm that Partner points to the cloned new object
            bool partnerIsCloned = !ReferenceEquals(cloned[0].Partner, original[0])
                                && !ReferenceEquals(cloned[0].Partner, original[1])
                                && !ReferenceEquals(cloned[1].Partner, original[0])
                                && !ReferenceEquals(cloned[1].Partner, original[1]);

            return $"{elementsAreNew}{TestConstants.SEPARATOR}{cyclePreserved}{TestConstants.SEPARATOR}{partnerIsCloned}";
        }

        public string GetAnswer() => $"{bool.TrueString}{TestConstants.SEPARATOR}{bool.TrueString}{TestConstants.SEPARATOR}{bool.TrueString}";
    }
}
