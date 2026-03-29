using SeanOne.Alchemy.Builder;

namespace SeanOne.Alchemy.Test.Cases.FluentApi
{
    public class FeDict : ITest
    {
        Dictionary<int, int> x;
        IAlchemyFunction<FeDictParam> ins;
        
        public void Setup()
        {
            x = Enumerable.Range(1, 10).ToDictionary(x => x, x => x * x);
            var ins = AlchemyFormatBuilder.SelectFeDict()
                .With(FeDictParam.DictFormat, "{0}=>{1}")
                .With(FeDictParam.KeyFormat, "D3")
                .With(FeDictParam.ValueFormat, "F2")
                .With(FeDictParam.Prefix, "[")
                .With(FeDictParam.Suffix, "]")
                .With(FeDictParam.ExcludeLastEnd, true.ToString())
                .With(FeDictParam.End, ", ")
                .With(FeDictParam.FinalPairSeparator, " and ")
                .With(FeDictParam.FeOpt, true.ToString());
        }

        public string Run()
        {
            return ins.BuildRun(x);
        }
    }
}
