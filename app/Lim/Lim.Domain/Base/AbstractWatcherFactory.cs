using System.IO;
using Lim.Core;

namespace Lim.Domain.Base
{
    public abstract class AbstractWatcherFactory<T> : IWatch<T>
    {
        public abstract void Intialize(T command);
        public void Intialize(object command)
        {
            Intialize((T) command);
        }
    }
}
