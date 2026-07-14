using SeanOne.Alchemy.Builder;

namespace SeanOne.Alchemy.Test.Cases.FluentApi
{
    public class FeSeq : ITest
    {
        List<int> x;
        IAlchemyFunction<FeSeqParam> ins;
        
        public void Setup()
        {
            x = Enumerable.Range(1, 10).ToList();
            ins = AlchemyFormatBuilder.SelectFeSeq()
                .With(FeSeqParam.Prefix, "[")
                .With(FeSeqParam.Suffix, "]")
                .With(FeSeqParam.ToString, "F2")
                .With(FeSeqParam.ExcludeLastEnd, true.ToString())
                .With(FeSeqParam.End, ", ")
                .With(FeSeqParam.FinalPairSeparator, " and ")
                .With(FeSeqParam.FeOpt, true.ToString());
        }

        public string Run() => ins.BuildRun(x);

        public string GetAnswer() => "[1.00, 2.00, 3.00, 4.00, 5.00, 6.00, 7.00, 8.00, 9.00 and 10.00]";
    }
}
