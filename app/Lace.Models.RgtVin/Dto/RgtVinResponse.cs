using Lace.Models.Enums;

namespace Lace.Models.RgtVin.Dto
{
    public class RgtVinResponse : IResponseFromRgtVin
    {
        public string Vin { get; set; }

        public string VehicleMake { get; set; }

        public string VehicleType { get; set; }

        public string VehicleModel { get; set; }

        public int? Year { get; set; }

        public int? Month { get; set; }

        public int? Quarter { get; set; }

        public int? RgtCode { get; set; }

        public decimal? Price { get; set; }

        public string Colour { get; set; }

        public string CarFullname
        {
            get
            {
                return string.Format("{0} {1}", VehicleMake, VehicleModel);
            }
        }

        public ServiceCallState ServiceProviderCallState { get; set; }
    }
}
