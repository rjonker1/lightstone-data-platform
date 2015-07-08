namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public class IvidResponse
    {
        public Lace.Domain.Core.Entities.IvidResponse DefaultIvidResponse()
        {
            var ivid = new Lace.Domain.Core.Entities.IvidResponse();
            ivid.BuildSpecificInformation();
            return ivid;
        }
    }
}