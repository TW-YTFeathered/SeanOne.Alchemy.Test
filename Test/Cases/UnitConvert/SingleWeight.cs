namespace SeanOne.Alchemy.Test.Cases.UnitConvert
{
    public class SingleWeightMgToG : SingleConvertTestBase
    {
        public SingleWeightMgToG() : base(1000, 1, "cnv /weight:mg->g") { }
    }

    public class SingleWeightCgToG : SingleConvertTestBase
    {
        public SingleWeightCgToG() : base(100, 1, "cnv /weight:cg->g") { }
    }

    public class SingleWeightDgToG : SingleConvertTestBase
    {
        public SingleWeightDgToG() : base(10, 1, "cnv /weight:dg->g") { }
    }

    public class SingleWeightDagToG : SingleConvertTestBase
    {
        public SingleWeightDagToG() : base(1, 10, "cnv /weight:dag->g") { }
    }

    public class SingleWeightHgToG : SingleConvertTestBase
    {
        public SingleWeightHgToG() : base(1, 100, "cnv /weight:hg->g") { }
    }

    public class SingleWeightKgToG : SingleConvertTestBase
    {
        public SingleWeightKgToG() : base(1, 1000, "cnv /weight:kg->g") { }
    }

    public class SingleWeightTToG : SingleConvertTestBase
    {
        public SingleWeightTToG() : base(1, 1_000_000, "cnv /weight:t->g") { }
    }

    public class SingleWeightOzToG : SingleConvertTestBase
    {
        public SingleWeightOzToG() : base(1, 28.349523125, "cnv /weight:oz->g") { }
    }

    public class SingleWeightLbToG : SingleConvertTestBase
    {
        public SingleWeightLbToG() : base(1, 453.59237, "cnv /weight:lb->g") { }
    }

    public class SingleWeightStToG : SingleConvertTestBase
    {
        public SingleWeightStToG() : base(1, 6350.29318, "cnv /weight:st->g") { }
    }

    public class SingleWeightShortTonToG : SingleConvertTestBase
    {
        public SingleWeightShortTonToG() : base(1, 907184.74, "cnv /weight:ShortTon->g") { }
    }

    public class SingleWeightLongTonToG : SingleConvertTestBase
    {
        public SingleWeightLongTonToG() : base(1, 1016046.9088, "cnv /weight:LongTon->g") { }
    }

    public class SingleWeightGtoKg : SingleConvertTestBase
    {
        public SingleWeightGtoKg() : base(1000, 1, "cnv /weight:g->kg") { }
    }

    public class SingleWeightGtoMg : SingleConvertTestBase
    {
        public SingleWeightGtoMg() : base(1, 1000, "cnv /weight:g->mg") { }
    }

    public class SingleWeightGtoOz : SingleConvertTestBase
    {
        public SingleWeightGtoOz() : base(28.349523125, 1, "cnv /weight:g->oz") { }
    }
}
