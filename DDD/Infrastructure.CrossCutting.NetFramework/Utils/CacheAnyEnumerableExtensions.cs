using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.Utils
{
    /// <summary>
    ///     Prevents double enumeration (and potential roundtrip to the data source) when checking
    ///     for the presence of items in an enumeration.
    /// </summary>   
    internal static class CacheAnyEnumerableExtensions
    {
        /// <summary>
        ///     Makes sure that calls to <see cref="IAnyEnumerable{T}.Any()" /> are
        ///     cached, and reuses the resulting enumerator.
        /// </summary>
        public static IAnyEnumerable<T> AsCachedAnyEnumerable<T>(this IEnumerable<T> source)
        {
            return new AnyEnumerable<T>(source);
        }

        /// <summary>
        ///     Exposes a cached <see cref="Any" /> operator.
        /// </summary>
        public interface IAnyEnumerable<out T> : IEnumerable<T>
        {
            bool Any();
        }

        /// <summary>
        ///     Lazily computes whether the inner enumerable has
        ///     any values, and caches the result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
        private class AnyEnumerable<T> : IAnyEnumerable<T>
        {
            private readonly IEnumerable<T> enumerable;
            private IEnumerator<T> enumerator;
            private bool hasAny;

            public AnyEnumerable(IEnumerable<T> enumerable)
            {
                this.enumerable = enumerable;
            }

            public bool Any()
            {
                InitializeEnumerator();

                return hasAny;
            }

            public IEnumerator<T> GetEnumerator()
            {
                InitializeEnumerator();

                return enumerator;
            }

            private void InitializeEnumerator()
            {
                if (enumerator == null)
                {
                    IEnumerator<T> inner = enumerable.GetEnumerator();
                    hasAny = inner.MoveNext();
                    enumerator = new SkipFirstEnumerator(inner, hasAny);
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            private class SkipFirstEnumerator : IEnumerator<T>
            {
                private readonly IEnumerator<T> inner;
                private readonly bool hasNext;
                private bool isFirst = true;

                public SkipFirstEnumerator(IEnumerator<T> inner, bool hasNext)
                {
                    this.inner = inner;
                    this.hasNext = hasNext;
                }

                public T Current
                {
                    get { return inner.Current; }
                }

                public void Dispose()
                {
                    inner.Dispose();
                }

                object IEnumerator.Current
                {
                    get { return Current; }
                }

                public bool MoveNext()
                {
                    if (isFirst)
                    {
                        isFirst = false;
                        return hasNext;
                    }

                    return inner.MoveNext();
                }

                public void Reset()
                {
                    inner.Reset();
                }
            }
        }
    }
}
