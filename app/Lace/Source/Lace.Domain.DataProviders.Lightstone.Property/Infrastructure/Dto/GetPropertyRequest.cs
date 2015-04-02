using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Domain.DataProviders.Lightstone.Property.Infrastructure.Dto
{
    public class GetPropertyRequest
    {
        private readonly IHavePropertyInformation _request;

        public bool RequestIsValid { get; private set; }

        public GetPropertyRequest(IHavePropertyInformation request)
        {
            _request = request;
        }

        public GetPropertyRequest Map()
        {
            UserId = _request.UserId;
            Municipality = _request.Municipality;
            DeedTown = _request.DeedTown;
            ErfNumber = _request.ErfNumber;
            Province = _request.Province;
            Portion = _request.Portion;
            SectionalTitle = _request.SectionalTitle;
            Unit = _request.Unit;
            Suburb = _request.Municipality;
            Street = _request.Street;
            StreetNumber = _request.StreetNumber;
            OwnerName = _request.OwnerName;
            IdCkOfOwner = _request.IdCkOfOwner;
            EstateName = _request.EstateName;
            MaxRowsToReturn = _request.MaxRowsToReturn == 0 ? 1 : _request.MaxRowsToReturn;
            TrackingNumber = _request.TrackingNumber;
            return this;
        }

        public GetPropertyRequest Validate()
        {
            RequestIsValid = !string.IsNullOrEmpty(UserId) && !string.IsNullOrEmpty(IdCkOfOwner) &&
                             !string.IsNullOrEmpty(TrackingNumber);
            return this;
        }


        public string UserId { get; private set; }
        public string Municipality { get; private set; }
        public string DeedTown { get; private set; }
        public string ErfNumber { get; private set; }
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
