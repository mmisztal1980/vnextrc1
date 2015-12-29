/**
 * File : Condition.cs
 * Company : Cloud Technologies
 * Website : http://www.cloud-technologies.net
 * Copyright (c) 2015, All rights reserved.
 * Author : Maciej Misztal
*/

using System;

namespace Hive
{
    /// <summary>
    /// Very light version of Code Contracts in order to introduce lightweight defensive programming
    /// </summary>
    public static class Condition
    {
        /// <summary>
        /// Will check the condition and throw if the check fails
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="predicate"></param>
//#if !dnxcore50
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter",
//           Justification = "Generic parameter is used to control the type of the thrown exception, when the passed parameter is false")]
//#endif
        public static void Require<TException>(bool predicate)
        where TException : Exception
        {
            Require<TException>(predicate, string.Empty);
        }

        /// <summary>
        /// Will check the condition and throw if the check fails
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="message"></param>
//#if !DNXCORE50
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter",
//            Justification = "Generic parameter is used to control the type of the thrown exception, when the passed parameter is false")]
//#endif
        public static void Require<TException>(bool predicate, string message)
        where TException : Exception
        {
            if (predicate) return;

            if (string.IsNullOrEmpty(message))
            {
                throw (TException)Activator.CreateInstance(typeof(TException));
            }

            throw (TException)Activator.CreateInstance(typeof(TException), message);
        }

        public static void ArgumentNotNull<T>([ValidatedNotNull]T argument, string name)
        {
            Require<ArgumentNullException>(argument != null, name);
        }

        public static void ArgumentNotDefault<T>([ValidatedNotNull] T argument, string name)
        {
            Require<ArgumentException>(!argument.Equals(default(T)));
        }

        public static void ArgumentNotNullOrEmpty(string argument, string name)
        {
            Require<ArgumentException>(!string.IsNullOrEmpty(argument), name);
        }
    }
}