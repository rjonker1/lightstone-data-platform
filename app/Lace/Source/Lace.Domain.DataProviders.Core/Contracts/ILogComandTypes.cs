using DataPlatform.Shared.Enums;
using Workflow.Lace.Identifiers;
using Workflow.Lace.Messages.Infrastructure;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface ILogComandTypes
    {
        void LogBegin(object paylod);
        void LogEnd(object paylod);
        void LogSecurity(object payload, object metadata);
        void LogConfiguration(object payload, object metadata);
        void LogTransformation(object payload, object metadata);
        void LogFault(object payload, object metadata);
        void LogRequest(ConnectionTypeIdentifier connection, object payload);
        void LogResponse(DataProviderState state, ConnectionTypeIdentifier connection, object payload);
    }
}