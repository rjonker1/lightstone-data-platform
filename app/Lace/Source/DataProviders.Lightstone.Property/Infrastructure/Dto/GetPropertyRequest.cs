using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Lightstone.Property.Infrastructure.Dto
{
    public class GetPropertyRequest
    {
        private readonly IAmLightstonePropertyRequest _request;

        public bool IsValid { get; private set; }

        public GetPropertyRequest(IAmLightstonePropertyRequest request)
        {
            _request = request;
        }

        public GetPropertyRequest Map()
        {
            UserId = _request.UserId.Field;
            //Municipality = _request.Municipality.Field;
            //DeedTown = _request.DeedTown.Field;
            //ErfNumber = _request.ErfNumber.Field;
            //Province = _request.Province.Field;
            //Portion = _request.Portion.Field;
            //SectionalTitle = _request.SectionalTitle.Field;
            //Unit = _request.Unit.Field;
            //Suburb = _request.Municipality.Field;
            //Street = _request.Street.Field;
            //StreetNumber = _request.StreetNumber.Field;
            //OwnerName = _request.OwnerName.Field;
            IdCkOfOwner = _request.IdentityNumber.Field;
            //EstateName = _request.EstateName.Field;
            MaxRowsToReturn = _request.MaxRowsToReturn.Field == "0" ? 1 : int.Parse(_request.MaxRowsToReturn.Field);
            TrackingNumber = _request.TrackingNumber.Field;
            return this;
        }

        public GetPropertyRequest Validate()
        {
            IsValid = !string.IsNullOrEmpty(UserId) && !string.IsNullOrEmpty(IdCkOfOwner) &&
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
