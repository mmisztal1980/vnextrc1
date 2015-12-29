using System;
using Xunit;

namespace Hive.TestKit
{
    public static class EnumExtensions
    {
        public static void ShouldEqual(this Enum @enum, Enum otherEnum)
        {
            Assert.True(@enum.Equals(otherEnum));
        }

        public static void ShouldNotEqual(this Enum @enum, Enum otherEnum)
        {
            Assert.False(@enum.Equals(otherEnum));
        }
    }
}