namespace SeanOne.Alchemy.Test.Cases.UnitConvert
{
    public class SingleLengthAToCM : SingleConvertTestBase
    {
        public SingleLengthAToCM() : base(1e8, 1, "cnv /length:a->cm") { }
    }

    public class SingleLengthNmToCM : SingleConvertTestBase
    {
        public SingleLengthNmToCM() : base(1e7, 1, "cnv /length:nm->cm") { }
    }

    public class SingleLengthUmToCM : SingleConvertTestBase
    {
        public SingleLengthUmToCM() : base(1e4, 1, "cnv /length:um->cm") { }
    }

    public class SingleLengthMmToCM : SingleConvertTestBase
    {
        public SingleLengthMmToCM() : base(10, 1, "cnv /length:mm->cm") { }
    }

    public class SingleLengthMToCM : SingleConvertTestBase
    {
        public SingleLengthMToCM() : base(1, 100, "cnv /length:m->cm") { }
    }

    public class SingleLengthKmToCM : SingleConvertTestBase
    {
        public SingleLengthKmToCM() : base(1, 100_000, "cnv /length:km->cm") { }
    }

    public class SingleLengthInToCM : SingleConvertTestBase
    {
        public SingleLengthInToCM() : base(1, 2.54, "cnv /length:in->cm") { }
    }

    public class SingleLengthFtToCM : SingleConvertTestBase
    {
        public SingleLengthFtToCM() : base(1, 30.48, "cnv /length:ft->cm") { }
    }

    public class SingleLengthYdToCM : SingleConvertTestBase
    {
        public SingleLengthYdToCM() : base(1, 91.44, "cnv /length:yd->cm") { }
    }

    public class SingleLengthMiToCM : SingleConvertTestBase
    {
        public SingleLengthMiToCM() : base(1, 160_934.4, "cnv /length:mi->cm") { }
    }

    public class SingleLengthNmiToCM : SingleConvertTestBase
    {
        public SingleLengthNmiToCM() : base(1, 185_200, "cnv /length:nmi->cm") { }
    }

    public class SingleLengthCMToM : SingleConvertTestBase
    {
        public SingleLengthCMToM() : base(100, 1, "cnv /length:cm->m") { }
    }

    public class SingleLengthCMToFT : SingleConvertTestBase
    {
        public SingleLengthCMToFT() : base(30.48, 1, "cnv /length:cm->ft") { }
    }

    public class SingleLengthCMToMM : SingleConvertTestBase
    {
        public SingleLengthCMToMM() : base(1, 10, "cnv /length:cm->mm") { }
    }
}
