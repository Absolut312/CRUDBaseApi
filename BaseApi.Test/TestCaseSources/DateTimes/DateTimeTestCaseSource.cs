using System;

namespace BaseApi.Test.TestCaseSources.DateTimes
{
    public class DateTimeTestCaseSource
    {
        public static object[] DateTimeCases =
        {
            new object[] { null },
            new object[] { DateTime.MinValue },
            new object[] { DateTime.MaxValue },
            new object[] { DateTime.Today },
            new object[] { DateTime.UnixEpoch }
        };
    }
}