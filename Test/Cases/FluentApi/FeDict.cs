using SeanOne.Alchemy.Builder;
using System.Collections.Generic;
using System.Linq;

namespace SeanOne.Alchemy.Test.Cases.FluentApi
{
    public class FeDict : ITest
    {
        Dictionary<int, int> x;
        IAlchemyFunction<FeDictParam> ins;

        public void Setup()
        {
            x = Enumerable.Range(1, 10).ToDictionary(x => x, x => x * x);
            ins = AlchemyFormatBuilder.SelectFeDict()
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

        public string Run() => ins.BuildRun(x);

        public string GetAnswer() => "[001=>1.00, 002=>4.00, 003=>9.00, 004=>16.00, 005=>25.00, 006=>36.00, 007=>49.00, 008=>64.00, 009=>81.00 and 010=>100.00]";
    }
}
