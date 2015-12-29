using System;
using System.Collections.Generic;

namespace Hive
{
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            Condition.ArgumentNotNull(enumerable, nameof(enumerable));
            Condition.ArgumentNotNull(action, nameof(action));

            foreach (var @enum in enumerable)
            {
                action(@enum);
            }
        }
    }
}