using System;
using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Cloning
{
    public class DeepCloneClonesPrivateFields : ITest
    {
        class Node : IComparable
        {
            private int _value;
            private string _tag;

            public Node(int value, string tag)
            {
                _value = value;
                _tag = tag;
            }

            public int GetValue() => _value;
            public string GetTag() => _tag;
            public int CompareTo(object obj) => _value.CompareTo(((Node)obj)._value);
        }

        List<Node> original;
        string ins;

        public void Setup()
        {
            original = [
                new(2, "b"),
                new(1, "a")
            ];
            ins = "arr /sort:is";
        }

        public string Run() 
        {
            var cloned = Alchemy.Transform(original, ins).ToObject<List<Node>>();

            // Verify that the private value field was copied
            bool valueCopied = cloned[0].GetValue() == 1
                            && cloned[1].GetValue() == 2;

            // Verify that the private reference field was copied
            bool tagCopied = cloned[0].GetTag() == "a"
                          && cloned[1].GetTag() == "b";

            return $"{valueCopied}{TestConstants.SEPARATOR}{tagCopied}";
        }

        public string GetAnswer() => $"{bool.TrueString}{TestConstants.SEPARATOR}{bool.TrueString}";
    }
}
