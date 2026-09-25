namespace SeanOne.Alchemy.Test.Cases.UnitConvert
{
    public class SingleLengthCMToM_FromInt : ITest
    {
        int x, y;
        string ins;

        public void Setup()
        {
            x = 100;
            y = 1;
            ins = "cnv /length:cm->m";
        }

        public string Run() => Alchemy.Transform(x, ins).GetString();

        public string GetAnswer() => y.ToString();
    }

    public class SingleWeightGToKg_FromInt_Fractional : ITest
    {
        int x, y;
        string ins;

        public void Setup()
        {
            x = 500;
            y = 0;
            ins = "cnv /weight:g->kg";
        }

        public string Run() => Alchemy.Transform(x, ins).GetString();

        public string GetAnswer() => y.ToString();
    }
}
