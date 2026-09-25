using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.FeDict
{
    public class FeDictNullValue : ITest
    {
        Dictionary<int, object> x;
        string ins;

        public void Setup()
        {
            x = new() { { 1, "one" }, { 2, null }, { 3, "three" } };
            ins = "fe /dict-format:{0}=>{1} /end:\", \" /exclude-last-end:true";
        }

        public string Run() => Alchemy.Format(x, ins);

        public string GetAnswer() => "1=>one, 2=>, 3=>three";
    }
}
