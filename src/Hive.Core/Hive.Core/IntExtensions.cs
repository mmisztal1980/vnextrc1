using System;

namespace Hive
{
    public static class IntExtensions
    {
        public static TimeSpan Hours(this int value)
        {
            return new TimeSpan(0, value, 0, 0);
        }

        public static TimeSpan Minutes(this int value)
        {
            return new TimeSpan(0, 0, value, 0);
        }

        public static TimeSpan Seconds(this int value)
        {
            return new TimeSpan(0, 0, 0, value);
        }

        public static TimeSpan MilliSeconds(this int value)
        {
            return new TimeSpan(0, 0, 0, 0, value);
        }
    }
}