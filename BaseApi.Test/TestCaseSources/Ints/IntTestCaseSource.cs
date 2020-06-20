using System;

namespace BaseApi.Test.TestCaseSources.Ints
{
    public class IntTestCaseSource
    {
        public static object[] IntTestCases =
        {
            new object[]{0},
            new object[]{1},
            new object[]{10},
            new object[]{99},
            new object[]{100},
            new object[]{Int32.MaxValue},
            new object[]{Int32.MinValue},
            new object[]{-1},
            new object[]{-10},
            new object[]{-100},
            new object[]{-99},
        };
    }
}