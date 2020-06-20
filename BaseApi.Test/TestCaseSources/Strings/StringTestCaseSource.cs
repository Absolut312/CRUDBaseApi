namespace BaseApi.Test.TestCaseSources.Strings
{
    public class StringTestCaseSource
    {
        public static object[] StringCases =
        {
            new object[] { null },
            new object[] { "" },
            new object[] { "ABCDEFGHIJKLMNOPQRSTUVWXYZ" },
            new object[] { "abcdefghijklmnopqrstuvwxyz" },
            new object[] { "ÄäÖöÜüß" },
            new object[] { "!\"\\/()[]{}&%$§^°'#+*~@€²µ´`<>|-_.:,;" },
            new object[] { " \n\r\t" },
            new object[] { "1234567890" },
            new object[] { "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" },
            new object[] { "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzÄäÖöÜüß" },
            new object[] { "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzÄäÖöÜüß!\"\\/()[]{}&%$§^°'#+*~@€²µ´`<>|-_.:,;" },
            new object[] { "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzÄäÖöÜüß!\"\\/()[]{}&%$§^°'#+*~@€²µ´`<>|-_.:,; \n\r\t" },
            new object[] { "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzÄäÖöÜüß!\"\\/()[]{}&%$§^°'#+*~@€²µ´`<>|-_.:,; \n\r\t1234567890" }
        };
    }
}