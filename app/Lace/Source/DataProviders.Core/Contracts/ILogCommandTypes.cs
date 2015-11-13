using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Workflow.Lace.Identifiers;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface ILogCommandTypes
    {
        void LogBegin(object payload);
        void LogEnd(object payload);
        void LogSecurity(object payload, object metadata);
        void LogConfiguration(object payload, object metadata);
        void LogTransformation(object payload, object metadata);
        void LogFault(object payload, object metadata);
        void LogRequest(ConnectionTypeIdentifier connection, object payload, DataProviderNoRecordState billNoRecords);
        void LogResponse(DataProviderResponseState state, ConnectionTypeIdentifier connection, object payload, DataProviderNoRecordState billNoRecords);
        void LogEntryPointRequest(ICollection<IPointToLaceRequest> request,DataProviderNoRecordState billNoRecords);
        void LogEntryPointResponse(object payload, DataProviderResponseState state, ICollection<IPointToLaceRequest> request,DataProviderNoRecordState billNoRecords);
    }
}