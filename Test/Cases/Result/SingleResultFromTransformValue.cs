namespace SeanOne.Alchemy.Test.Cases.Result
{
    public class ToObjectFromTransformValue : SingleResultTestBase<double>
    {
        public ToObjectFromTransformValue() : base(-273.15, "0", "cnv /temp:C->K", x => x.ToObject<double>().ToString()) { }
    }

    public class ToStringFromTransformValue : SingleResultTestBase<double>
    {
        public ToStringFromTransformValue() : base(-273.15, typeof(AlchemyResult).FullName, "cnv /temp:C->K", x => x.ToString()) { }
    }

    public class GetStringFromTransformValue : SingleResultTestBase<double>
    {
        public GetStringFromTransformValue() : base(-273.15, "0", "cnv /temp:C->K", x => x.GetString()) { }
    }

    public class GetSByteFromTransformValue : SingleResultTestBase<double>
    {
        public GetSByteFromTransformValue() : base(-273.15, "0", "cnv /temp:C->K", x => x.GetSByte().ToString()) { }
    }

    public class GetInt16FromTransformValue : SingleResultTestBase<double>
    {
        public GetInt16FromTransformValue() : base(-273.15, "0", "cnv /temp:C->K", x => x.GetInt16().ToString()) { }
    }

    public class GetInt32FromTransformValue : SingleResultTestBase<double>
    {
        public GetInt32FromTransformValue() : base(-273.15, "0", "cnv /temp:C->K", x => x.GetInt32().ToString()) { }
    }

    public class GetInt64FromTransformValue : SingleResultTestBase<double>
    {
        public GetInt64FromTransformValue() : base(-273.15, "0", "cnv /temp:C->K", x => x.GetInt64().ToString()) { }
    }

    public class GetByteFromTransformValue : SingleResultTestBase<double>
    {
        public GetByteFromTransformValue() : base(-273.15, "0", "cnv /temp:C->K", x => x.GetByte().ToString()) { }
    }

    public class GetUInt16FromTransformValue : SingleResultTestBase<double>
    {
        public GetUInt16FromTransformValue() : base(-273.15, "0", "cnv /temp:C->K", x => x.GetUInt16().ToString()) { }
    }

    public class GetUInt32FromTransformValue : SingleResultTestBase<double>
    {
        public GetUInt32FromTransformValue() : base(-273.15, "0", "cnv /temp:C->K", x => x.GetUInt32().ToString()) { }
    }

    public class GetUInt64FromTransformValue : SingleResultTestBase<double>
    {
        public GetUInt64FromTransformValue() : base(-273.15, "0", "cnv /temp:C->K", x => x.GetUInt64().ToString()) { }
    }

    public class GetSingleFromTransformValue : SingleResultTestBase<double>
    {
        public GetSingleFromTransformValue() : base(-273.15, "0", "cnv /temp:C->K", x => x.GetSingle().ToString()) { }
    }

    public class GetDoubleFromTransformValue : SingleResultTestBase<double>
    {
        public GetDoubleFromTransformValue() : base(-273.15, "0", "cnv /temp:C->K", x => x.GetDouble().ToString()) { }
    }

    public class GetDecimalFromTransformValue : SingleResultTestBase<double>
    {
        public GetDecimalFromTransformValue() : base(-273.15, "0", "cnv /temp:C->K", x => x.GetDecimal().ToString()) { }
    }

    /*
     * TODO: Will support these transform types
    public class GetCharFromTransformValue : SingleResultTestBase<char>
    {
        public GetCharFromTransformValue() : base(25, "M", "basic", x => x.GetChar().ToString()) { }
    }

    public class GetBooleanFromTransformValue : SingleResultTestBase<bool>
    {
        public GetBooleanFromTransformValue() : base(25, "True", "basic", x => x.GetBoolean().ToString()) { }
    }

    public class GetDateTimeFromTransformValue : SingleResultTestBase<DateTime>
    {
        public GetDateTimeFromTransformValue() : base(new(2027, 1, 1), "2027-01-01", "basic", x => x.GetDateTime().ToString("yyyy-MM-dd")) { }
    }

    public class GetTimeSpanFromTransformValue : SingleResultTestBase<TimeSpan>
    {
        public GetTimeSpanFromTransformValue() : base(new(10, 10, 10), "10:10:10", "/tostring:hh\\:mm\\:ss", x => x.GetTimeSpan().ToString("hh\\:mm\\:ss")) { }
    }

    public class GetGuidFromTransformValue : SingleResultTestBase<Guid>
    {
        public GetGuidFromTransformValue() : base(new("00000000-0000-0000-0000-000000000000"), "(00000000-0000-0000-0000-000000000000)", "/tostring:p", x => x.GetGuid().ToString("p")) { }
    }
    */
}