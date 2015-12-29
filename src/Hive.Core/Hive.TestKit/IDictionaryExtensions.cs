using System.Collections.Generic;
using Xunit;

namespace Hive.TestKit
{
    public static class IDictionaryExtensions
    {
        public static void ShouldContainKey<T, U>(this IDictionary<T, U> dictionary, T expectedKey)
        {
            Assert.True(dictionary.ContainsKey(expectedKey));
        }
    }
}