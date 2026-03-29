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

        public string Run()
        {
            return ins.BuildRun(x);
        }
    }
}
