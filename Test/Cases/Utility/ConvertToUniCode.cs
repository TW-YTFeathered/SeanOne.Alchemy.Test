using System.Text;

namespace SeanOne.Alchemy.Test.Cases.Utility
{
    public class ConvertToUnicode : ITest
    {
        int x;
        string ins;

        public void Setup()
        {
            x = 5;

            ins = "/end:";
            StringBuilder sb = new();
            foreach (var v in Enumerable.Range(32, 95))
            {
                sb.Append($"\\u{v:X4}");
            }
            ins += sb.ToString();
        }

        public string Run() => Alchemy.Format(x, ins);

        public string GetAnswer() => "5 !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";
    }
}
