using System.Data;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.Lightstone.Property.Infrastructure.Management
{
    public class TransformLightstonePropertyResponse : ITransformResponseFromDataProvider
    {
        public DataSet Response { get; private set; }
        public IProvideDataFromLightstoneProperty Result { get; private set; }
        public bool Continue { get; private set; }

        public TransformLightstonePropertyResponse(DataSet response)
        {
            Response = response;
            Continue = Response != null && Response.Tables.Count > 0;
            Result = Continue ? new LightstonePropertyResponse() : null;
        }

        public void Transform()
        {
            
            //var property = Response.Tables[0].AsEnumerable()
            //    .Select(s => new LightstonePropertyResponse(new li))

            //var card = Message.XmlToObject<Dto.DrivingLicenseCard>();

          
        }

        
    }
}
