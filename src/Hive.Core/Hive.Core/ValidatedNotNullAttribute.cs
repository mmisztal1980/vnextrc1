/**
 * File : ValidatedNotNullAttribute.cs
 * Company : Cloud Technologies
 * Website : http://www.cloud-technologies.net
 * Copyright (c) 2015, All rights reserved.
 * Author : Maciej Misztal
*/

using System;

namespace Hive
{
    /// <summary>
    /// Attribute required, in order for CA, to recognize customized null-checks.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    public sealed class ValidatedNotNullAttribute : Attribute
    {}
}