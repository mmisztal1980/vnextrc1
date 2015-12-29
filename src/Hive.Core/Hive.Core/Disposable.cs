/**
 * File : Disposable.cs
 * Company : Cloud Technologies
 * Website : http://www.cloud-technologies.net
 * Copyright (c) 2015, All rights reserved.
 * Author : Maciej Misztal
*/

using System;

namespace Hive
{
    public abstract class Disposable : IDisposable
    {
        protected bool Disposed = false;

        public void Dispose()
        {
            if (Disposed) return;

            Dispose(true);

            GC.SuppressFinalize(this);

            Disposed = true;
        }

        ~Disposable()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        { }
    }
}