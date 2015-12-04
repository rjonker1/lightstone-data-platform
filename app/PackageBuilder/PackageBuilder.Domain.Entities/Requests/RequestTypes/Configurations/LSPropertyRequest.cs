using System;
using System.Collections.Generic;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using PackageBuilder.Domain.Requests.Fields;

namespace PackageBuilder.Domain.Entities.Requests.RequestTypes.Configurations
{
    public class LightstonePropertyRequest : IAmLightstonePropertyRequest
    {
        public LightstonePropertyRequest(ICollection<IAmRequestField> requestFields)
        {
            UserId = new UserIdRequestField(System.Configuration.ConfigurationManager.AppSettings["LightstonePropertyUserId"]);
            IdentityNumber = requestFields.GetRequestField<IAmIdentityNumberRequestField>();
            TrackingNumber = new TrackingNumberRequestField(Guid.NewGuid().ToString());
            MaxRowsToReturn =
                new MaxRowsToReturnRequestField(System.Configuration.ConfigurationManager.AppSettings["LightstonePropertyMaxRowsToReturn"] ?? "1");
        }

        public IAmUserIdRequestField UserId { get; private set; }
        public IAmIdentityNumberRequestField IdentityNumber { get; private set; }
        public IAmTrackingNumberRequestField TrackingNumber { get; private set; }
        public IAmMaxRowsToReturnRequestField MaxRowsToReturn { get; private set; }
    }
}
