using System;

namespace LightstoneApp.Infrastructure.CrossCutting.Tests
{
    public class ShortLivedObject
        : IDisposable
    {
        private bool _IsDisposed;

        public bool IsDisposed
        {
            get { return _IsDisposed; }
        }

        public void Dispose()
        {
            _IsDisposed = true;
        }
    }
}