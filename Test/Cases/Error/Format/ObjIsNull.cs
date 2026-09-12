namespace SeanOne.Alchemy.Test.Cases.Error.Format
{
    public class ObjIsNull : ITest
    {
        object x;
        string ins;

        public void Setup() 
        {
            x = null;
            ins = "/tostring:F2";
        }

        public string Run() => Alchemy.Format(x, ins);

        public string GetAnswer() => "";
    }
}
