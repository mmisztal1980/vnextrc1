using Xunit;

namespace Hive.TestKit
{
    public static class ObjectExtensions
    {
        public static void ShouldBeNull(this object @object)
        {
            Assert.Null(@object);
        }

        public static void ShouldNotBeNull(this object @object)
        {
            Assert.NotNull(@object);
        }
    }
}