using Lace.Models.Enums;
namespace Lace.Models.Lightstone.Dto
{
    public class LightstoneResponse : IResponseFromLightstone
    {
        public int? CarId { get; set; }

        public int? Year { get; set; }

        public string Vin { get; set; }

        public string ImageUrl { get; set; }

        public string Quarter { get; set; }

        public string CarFullname { get; set; }

        public string Model { get; set; }

        public ServiceCallState ServiceProviderCallState { get; set; }
    }
}
