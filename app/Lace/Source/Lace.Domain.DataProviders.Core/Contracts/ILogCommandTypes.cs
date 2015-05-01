using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Workflow.Lace.Identifiers;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface ILogCommandTypes
    {
        void LogBegin(object paylod);
        void LogEnd(object paylod);
        void LogSecurity(object payload, object metadata);
        void LogConfiguration(object payload, object metadata);
        void LogTransformation(object payload, object metadata);
        void LogFault(object payload, object metadata);
        void LogRequest(ConnectionTypeIdentifier connection, object payload);
        void LogResponse(DataProviderState state, ConnectionTypeIdentifier connection, object payload);
        void LogEntryPointRequest(ICollection<IPointToLaceRequest> request);
        void LogEntryPointResponse(object payload, DataProviderState state,ICollection<IPointToLaceRequest> request);
    }
}