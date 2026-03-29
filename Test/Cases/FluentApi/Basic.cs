using SeanOne.Alchemy.Builder;

namespace SeanOne.Alchemy.Test.Cases.FluentApi
{
    public class Basic : ITest
    {
        int x;
        IAlchemyFunction<BasicParam> ins;
        
        public void Setup()
        {
            x = 5;
            var ins = AlchemyFormatBuilder.SelectBasic()
                .With(BasicParam.Prefix, "[")
                .With(BasicParam.Suffix, "]")
                .With(BasicParam.ToString, "F2")
                .With(BasicParam.End, "!");
        }

        public string Run()
        {
            return ins.BuildRun(x);
        }
    }
}
