using System;

namespace SeanOne.Alchemy.Test.Cases.Utility
{
    public class ConvertToEscapeChar : ITest
    {
        int x;
        string ins;

        public void Setup()
        {
            x = 5;
            ins = @"/end:\a\b\c\d\e\f\g\h\i\j\k\l\m\n\o\p\q\r\s\t\u\v\w\x\y\z";
        }

        public string Run() => Alchemy.Format(x, ins);

        public string GetAnswer() => "5\a\b\\c\\d\\e\f\\g\\h\\i\\j\\k\\l\\m"
                + Environment.NewLine
                + "\\o\\p\\q\r\\s\t\\u\v\\w\\x\\y\\z";
    }
}
