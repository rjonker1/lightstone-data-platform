namespace Toolbox.LightstoneAuto.Database.Domain.Models
{
    public class AutoCarSpecifcations
    {
        public int CarId { get; set; }
        public int Year { get; set; }
        public string Vin { get; set; }
        public string ImageUrl { get; set; }
        public string Quarter { get; set; }
        public string CarFullname { get; set; }
        public string Model { get; set; }
    }
}
