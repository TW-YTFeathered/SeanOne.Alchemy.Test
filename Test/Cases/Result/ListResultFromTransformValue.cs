using System;
using System.Collections.Generic;

namespace SeanOne.Alchemy.Test.Cases.Result
{
    public class ToObjectListFromTransformValue : ListResultTestBase<int, int>
    {
        public ToObjectListFromTransformValue() : base([1, 2, 3], [1, 2, 3], "arr /sort:is", x => x.ToObject<List<int>>()) { }
    }

    public class ToListFromTransformValue : ListResultTestBase<int, int>
    {
        public ToListFromTransformValue() : base([1, 2, 3], [1, 2, 3], "arr /sort:is", x => x.ToList<int>()) { }
    }

    public class GetStringListFromTransformValue : ListResultTestBase<int, string>
    {
        public GetStringListFromTransformValue() : base([1, 2, 3], ["1", "2", "3"], "arr /sort:is", x => x.GetStringList()) { }
    }

    public class GetSByteListFromTransformValue : ListResultTestBase<int, sbyte>
    {
        public GetSByteListFromTransformValue() : base([1, 2, 3], [1, 2, 3], "arr /sort:is", x => x.GetSByteList()) { }
    }

    public class GetInt16ListFromTransformValue : ListResultTestBase<int, short>
    {
        public GetInt16ListFromTransformValue() : base([1, 2, 3], [1, 2, 3], "arr /sort:is", x => x.GetInt16List()) { }
    }

    public class GetInt32ListFromTransformValue : ListResultTestBase<int, int>
    {
        public GetInt32ListFromTransformValue() : base([1, 2, 3], [1, 2, 3], "arr /sort:is", x => x.GetInt32List()) { }
    }

    public class GetInt64ListFromTransformValue : ListResultTestBase<int, long>
    {
        public GetInt64ListFromTransformValue() : base([1, 2, 3], [1, 2, 3], "arr /sort:is", x => x.GetInt64List()) { }
    }

    public class GetByteListFromTransformValue : ListResultTestBase<int, byte>
    {
        public GetByteListFromTransformValue() : base([1, 2, 3], [1, 2, 3], "arr /sort:is", x => x.GetByteList()) { }
    }

    public class GetUInt16ListFromTransformValue : ListResultTestBase<int, ushort>
    {
        public GetUInt16ListFromTransformValue() : base([1, 2, 3], [1, 2, 3], "arr /sort:is", x => x.GetUInt16List()) { }
    }

    public class GetUInt32ListFromTransformValue : ListResultTestBase<int, uint>
    {
        public GetUInt32ListFromTransformValue() : base([1, 2, 3], [1, 2, 3], "arr /sort:is", x => x.GetUInt32List()) { }
    }

    public class GetUInt64ListFromTransformValue : ListResultTestBase<int, ulong>
    {
        public GetUInt64ListFromTransformValue() : base([1, 2, 3], [1, 2, 3], "arr /sort:is", x => x.GetUInt64List()) { }
    }

    public class GetSingleListFromTransformValue : ListResultTestBase<int, float>
    {
        public GetSingleListFromTransformValue() : base([1, 2, 3], [1, 2, 3], "arr /sort:is", x => x.GetSingleList()) { }
    }

    public class GetDoubleListFromTransformValue : ListResultTestBase<int, double>
    {
        public GetDoubleListFromTransformValue() : base([1, 2, 3], [1, 2, 3], "arr /sort:is", x => x.GetDoubleList()) { }
    }

    public class GetDecimalListFromTransformValue : ListResultTestBase<int, decimal>
    {
        public GetDecimalListFromTransformValue() : base([1, 2, 3], [1, 2, 3], "arr /sort:is", x => x.GetDecimalList()) { }
    }

    public class GetObjectListFromTransformValue : ListResultTestBase<int, object>
    {
        public GetObjectListFromTransformValue() : base([1, 2, 3], [1, 2, 3], "arr /sort:is", x => x.GetObjectList()) { }
    }

    public class GetBooleanListFromTransformValue : ListResultTestBase<bool, bool>
    {
        public GetBooleanListFromTransformValue() : base([false, true], [false, true], "arr /sort:is", x => x.GetBooleanList()) { }
    }

    public class GetCharListFromTransformValue : ListResultTestBase<char, char>
    {
        public GetCharListFromTransformValue() : base(['A', 'B', 'C'], ['A', 'B', 'C'], "arr /sort:is", x => x.GetCharList()) { }
    }

    public class GetDateTimeListFromTransformValue : ListResultTestBase<DateTime, DateTime>
    {
        public GetDateTimeListFromTransformValue() : base(
            [new(2027, 1, 1), new(2027, 2, 2), new(2027, 3, 3)],
            [new(2027, 1, 1), new(2027, 2, 2), new(2027, 3, 3)],
            "arr /sort:is",
            x => x.GetDateTimeList()
        ) { }
    }

    public class GetTimeSpanListFromTransformValue : ListResultTestBase<TimeSpan, TimeSpan>
    {
        public GetTimeSpanListFromTransformValue() : base(
            [new(0, 0, 1), new(0, 0, 2), new(0, 0, 3)],
            [new(0, 0, 1), new(0, 0, 2), new(0, 0, 3)],
            "arr /sort:is",
            x => x.GetTimeSpanList()
        ) { }
    }

    public class GetGuidListFromTransformValue : ListResultTestBase<Guid, Guid>
    {
        public GetGuidListFromTransformValue() : base(
            [new("00000000-0000-0000-0000-000000000001"), new("00000000-0000-0000-0000-000000000002")],
            [new("00000000-0000-0000-0000-000000000001"), new("00000000-0000-0000-0000-000000000002")],
            "arr /sort:is",
            x => x.GetGuidList()
        ) { }
    }
}
