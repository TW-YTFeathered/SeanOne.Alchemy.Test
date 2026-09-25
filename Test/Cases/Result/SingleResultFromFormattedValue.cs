using System;

namespace SeanOne.Alchemy.Test.Cases.Result
{
    public class ToObjectFromFormattedValue : SingleResultTestBase<int>
    {
        public ToObjectFromFormattedValue() : base(5, "5.00", "/tostring:F2", x => x.ToObject<string>()) { }
    }

    public class ToStringFromFormattedValue : SingleResultTestBase<int>
    {
        public ToStringFromFormattedValue() : base(5, "5.00", "/tostring:F2", x => x.ToString()) { }
    }

    public class GetCharFromFormattedValue : SingleResultTestBase<int>
    {
        public GetCharFromFormattedValue() : base(15, "F", "/tostring:X0", x => x.GetChar().ToString()) { }
    }

    public class GetStringFromFormattedValue : SingleResultTestBase<int>
    {
        public GetStringFromFormattedValue() : base(5, "5.00", "/tostring:F2", x => x.GetString()) { }
    }

    public class GetSByteFromFormattedValue : SingleResultTestBase<sbyte>
    {
        public GetSByteFromFormattedValue() : base(5, "5", "/tostring:F0", x => x.GetSByte().ToString()) { }
    }

    public class GetInt16FromFormattedValue : SingleResultTestBase<short>
    {
        public GetInt16FromFormattedValue() : base(10, "10", "/tostring:F0", x => x.GetInt16().ToString()) { }
    }

    public class GetInt32FromFormattedValue : SingleResultTestBase<int>
    {
        public GetInt32FromFormattedValue() : base(20, "20", "/tostring:F0", x => x.GetInt32().ToString()) { }
    }

    public class GetInt64FromFormattedValue : SingleResultTestBase<long>
    {
        public GetInt64FromFormattedValue() : base(40, "40", "/tostring:F0", x => x.GetInt64().ToString()) { }
    }

    public class GetByteFromFormattedValue : SingleResultTestBase<byte>
    {
        public GetByteFromFormattedValue() : base(5, "5", "/tostring:F0", x => x.GetByte().ToString()) { }
    }

    public class GetUInt16FromFormattedValue : SingleResultTestBase<ushort>
    {
        public GetUInt16FromFormattedValue() : base(10, "10", "/tostring:F0", x => x.GetUInt16().ToString()) { }
    }

    public class GetUInt32FromFormattedValue : SingleResultTestBase<uint>
    {
        public GetUInt32FromFormattedValue() : base(20, "20", "/tostring:F0", x => x.GetUInt32().ToString()) { }
    }

    public class GetUInt64FromFormattedValue : SingleResultTestBase<ulong>
    {
        public GetUInt64FromFormattedValue() : base(40, "40", "/tostring:F0", x => x.GetUInt64().ToString()) { }
    }

    public class GetSingleFromFormattedValue : SingleResultTestBase<float>
    {
        public GetSingleFromFormattedValue() : base(3.14f, "3.14", "/tostring:F2", x => x.GetSingle().ToString()) { }
    }

    public class GetDoubleFromFormattedValue : SingleResultTestBase<double>
    {
        public GetDoubleFromFormattedValue() : base(6.28, "6.28", "/tostring:F2", x => x.GetDouble().ToString()) { }
    }

    public class GetDecimalFromFormattedValue : SingleResultTestBase<decimal>
    {
        public GetDecimalFromFormattedValue() : base(10.01m, "10.01", "/tostring:F2", x => x.GetDecimal().ToString()) { }
    }

    public class GetDateTimeFromFormattedValue : SingleResultTestBase<DateTime>
    {
        public GetDateTimeFromFormattedValue() : base(new(2027, 1, 1), "2027-01-01", "/tostring:yyyy-MM-dd", x => x.GetDateTime().ToString("yyyy-MM-dd")) { }
    }

    public class GetTimeSpanFromFormattedValue : SingleResultTestBase<TimeSpan>
    {
        public GetTimeSpanFromFormattedValue() : base(new(10, 10, 10), "10:10:10", "/tostring:hh\\:mm\\:ss", x => x.GetTimeSpan().ToString("hh\\:mm\\:ss")) { }
    }

    public class GetGuidFromFormattedValue : SingleResultTestBase<Guid>
    {
        public GetGuidFromFormattedValue() : base(new("00000000-0000-0000-0000-000000000000"), "(00000000-0000-0000-0000-000000000000)", "/tostring:p", x => x.GetGuid().ToString("p")) { }
    }

    public class GetBooleanFromFormattedValue : SingleResultTestBase<bool>
    {
        public GetBooleanFromFormattedValue() : base(true, "True", "basic", x => x.GetBoolean().ToString()) { }
    }
}
