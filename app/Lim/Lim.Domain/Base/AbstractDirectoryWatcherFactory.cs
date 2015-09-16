using System.IO;
using Lim.Core;

namespace Lim.Domain.Base
{
    public abstract class AbstractDirectoryWatcherFactory<T> : IWatchDirectory<T>
    {
        public abstract void Intialize(T command);
        //public abstract void Created(object source, FileSystemEventArgs args);
        //public abstract void Changed(object source, FileSystemEventArgs args);
        //public abstract void Deleted(object source, FileSystemEventArgs args);
        //public abstract void Renamed(object source, FileSystemEventArgs args);

        public void Intialize(object command)
        {
            Intialize((T) command);
        }
        //public virtual void Created(object source, FileSystemEventArgs args)
        //{
            
        //}

        //public virtual void Changed(object source, FileSystemEventArgs args)
        //{
            
        //}

        //public virtual void Deleted(object source, FileSystemEventArgs args)
        //{
            
        //}

        //public virtual void Renamed(object source, FileSystemEventArgs args)
        //{
            
        //}
    }
}
