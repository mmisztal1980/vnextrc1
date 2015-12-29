using System;

namespace Hive
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Permits launching Action delegates on nullable types after a C# 6.0 null check 
        /// using the '?' operator. X?.Execute(x => {});
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="executable"></param>
        /// <param name="action"></param>
        public static void Execute<T>(this T executable, Action action)
           where T : class
        {
            Condition.ArgumentNotNull(executable, nameof(executable));
            Condition.ArgumentNotNull(action, nameof(action));

            action();
        }

        /// <summary>
        /// Permits launching Action delegates on nullable types after a C# 6.0 null check 
        /// using the '?' operator. X?.Execute(x => {}); 
        /// X will be passed as the delegate's argument.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="executable"></param>
        /// <param name="action"></param>
        public static void Execute<T>(this T executable, Action<T> action)
            where T : class
        {
            Condition.ArgumentNotNull(executable, nameof(executable));
            Condition.ArgumentNotNull(action, nameof(action));

            action(executable);
        }
    }
}
