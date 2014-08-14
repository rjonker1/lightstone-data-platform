namespace Lace.Source.Lightstone.Models
{
    public class Car
    {
        public int Car_ID { get; set; }
        public int CarType_ID { get; set; }
        // public virtual CarType CarType { get; set; }
        public string CarFullName { get; set; }
        public string CarModel { get; set; }
        public string BodyShape { get; set; }
        public string FuelType { get; set; }

        public string Market { get; set; }
        public string GearType { get; set; }
        public bool IsDiscontinued { get; set; }
        public string ImageUrl { get; set; }
        public string ImageUrlSmall { get; set; }
        public string ImageSource { get; set; }
    }
}
