using Xunit;

namespace Hive.TestKit
{
    public static class StringExtensions
    {
        public static string ShouldBeNullOrEmpty(this string @string)
        {
            Assert.True(string.IsNullOrEmpty(@string));
            return @string;
        }

        public static string ShouldNotBeNullOrEmpty(this string @string)
        {
            Assert.False(string.IsNullOrEmpty(@string));
            return @string;
        }

        public static string ShouldContain(this string @string, string expected)
        {
            Assert.True(@string.Contains(expected));
            return @string;
        }

        public static string ShouldEndWith(this string @string, string expected)
        {
            Assert.True(@string.EndsWith(expected));
            return @string;
        }

        public static string ShouldEqual(this string @string, string expected)
        {
            Assert.Equal(expected, @string);
            return @string;
        }
    }
}