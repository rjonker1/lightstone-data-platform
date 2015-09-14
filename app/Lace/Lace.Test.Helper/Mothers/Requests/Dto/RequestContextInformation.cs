using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Test.Helper.Mothers.Requests.Dto
{
    public class RequestContextInformation : IHaveRequestContext
    {
        private readonly Guid _aggregateId;

        public RequestContextInformation()
        {
            _aggregateId = Guid.NewGuid();
        }

        public Guid RequestId
        {
            get { return _aggregateId; }
        }


        public SystemType System
        {
            get { return SystemType.Api; }
        }

        public string FromIpAddress
        {
            get { return "196.165.10.2"; }
        }

        public DeviceTypes FromDeviceType
        {
            get { return DeviceTypes.ApiClient; }
        }


        public string OsVersion
        {
            get { return "not available"; }
        }
    }
}
