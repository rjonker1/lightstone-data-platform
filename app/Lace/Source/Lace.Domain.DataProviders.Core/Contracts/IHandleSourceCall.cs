using System;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface IHandleSourceCall
    {
       void Request(Action<IRequestDataFromSource> action);
    }
}
