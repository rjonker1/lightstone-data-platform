using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Domain.DataProviders.Lightstone.Property.Infrastructure.Dto
{
    public class GetPropertiesRequest
    {
        private readonly ILaceRequest _request;

        public bool RequestIsValid { get; private set; }

        public GetPropertiesRequest(ILaceRequest request)
        {
            _request = request;
        }

        public void MapRequest()
        {
            UserId = _request.User.UserId.ToString();
            Municipality = _request.Property.Municipality;
            DeedTown = _request.Property.DeedTown;
            //Erf = _request.Property.Erf;
            Province = _request.Property.Province;
            Portion = _request.Property.Portion;
            SectionalTitle = _request.Property.SectionalTitle;
            Unit = _request.Property.Unit;
            Suburb = _request.Property.Municipality;
            Street = _request.Property.Street;
            StreetNumber = _request.Property.StreetNumber;
            OwnerName = _request.Property.OwnerName;
            IdCkOfOwner = _request.Property.IdCkOfOwner;
            EstateName = _request.Property.EstateName;
            MaxRowsToReturn = _request.Property.MaxRowsToReturn == 0 ? 1 : _request.Property.MaxRowsToReturn;
            TrackingNumber = _request.Property.TrackingNumber;
        }

        public void Validate()
        {
            RequestIsValid = !string.IsNullOrEmpty(UserId) && !string.IsNullOrEmpty(IdCkOfOwner) &&
                             !string.IsNullOrEmpty(TrackingNumber);
        }


        public string UserId { get; private set; }
        public string Municipality { get; private set; }
        public string DeedTown { get; private set; }
        public string Erf { get; private set; }
        public string Province { get; private set; }
        public string Portion { get; private set; }
        public string SectionalTitle { get; private set; }
        public string Unit { get; private set; }
        public string Suburb { get; private set; }
        public string Street { get; private set; }
        public string StreetNumber { get; private set; }
        public string OwnerName { get; private set; }
        public string IdCkOfOwner { get; private set; }
        public string EstateName { get; private set; }
        public string FarmName { get; private set; }
        public int MaxRowsToReturn { get; private set; }
        public string TrackingNumber { get; private set; }
    }
}
