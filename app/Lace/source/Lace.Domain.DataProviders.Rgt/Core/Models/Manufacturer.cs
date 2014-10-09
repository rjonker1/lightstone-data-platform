namespace Lace.Domain.DataProviders.Rgt.Core.Models
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            
        }

        public Manufacturer(int manufacturerId, string manufacturerName)
        {
            Manufacturer_ID = manufacturerId;
            ManufacturerName = manufacturerName;
        }

        public int Manufacturer_ID { get; set; }
        public string ManufacturerName { get; set; }
    }
}
