using System.Runtime.Serialization;

namespace Workflow.Lace.Messages.Core
{
    public enum DataProviderAction
    {
        [EnumMember]
        Request = 1,
        [EnumMember]
        Response = 2,
    }

    public enum DataProviderState
    {
        [EnumMember]
        Successful = 1,
        [EnumMember]
        PartialFailure = 2,
        [EnumMember]
        Failed = 3
    }
}
