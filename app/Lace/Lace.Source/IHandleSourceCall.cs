using System;
namespace Lace.Source
{
    public interface IHandleSourceCall
    {
       void Request(Action<IRequestDataFromSource> action);
    }
}
