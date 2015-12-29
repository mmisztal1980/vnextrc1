using Xunit;

namespace Hive.TestKit
{
    public static class IntExtensions
    {
        public static int ShouldEqual(this int @int, int expected)
        {
            Assert.Equal(expected, @int);
            return @int;
        }

        public static int ShouldNotEqual(this int @int, int notExpected)
        {
            Assert.NotEqual(@int, notExpected);
            return @int;
        }

        public static int ShouldBeGreaterThen(this int @int, int other)
        {
            Assert.True(@int > other);
            return @int;
        }

        public static int ShouldBeGreaterOrEqualTo(this int @int, int other)
        {
            Assert.True(@int >= other);
            return @int;
        }

        public static int ShouldBeLesserThen(this int @int, int other)
        {
            Assert.True(@int < other);
            return @int;
        }

        public static int ShouldBeLesserOrEqualTo(this int @int, int other)
        {
            Assert.True(@int <= other);
            return @int;
        }
    }
}