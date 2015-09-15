using Lim.Core;

namespace Lim.Domain.Base
{
    public abstract class AbstractFileReadingFactory<T1, T2> : IReadPasswordProtectedZipFile<T1, T2>
    {
        public abstract T2 ReadFile(T1 command);

        public object ReadFile(object command)
        {
            return (T2)ReadFile((T1) command);
        }
    }
}