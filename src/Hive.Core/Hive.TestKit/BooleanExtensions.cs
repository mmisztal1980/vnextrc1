using Xunit;

namespace Hive.TestKit
{
    public static class BooleanExtensions
    {
        public static void ShouldEqual(this bool @bool, bool expected)
        {
            Assert.Equal(expected, @bool);
        }

        public static void ShouldEqual(this bool? @bool, bool? expected)
        {
            Assert.Equal(expected, @bool);
        }
    }
}