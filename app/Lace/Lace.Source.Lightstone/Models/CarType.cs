namespace Lace.Source.Lightstone.Models
{
    public class CarType
    {

        public CarType()
        {
            
        }

        public CarType(int carTypeId, string carTypeName, int makeId)
        {
            CarType_ID = carTypeId;
            CarTypeName = carTypeName;
            Make_ID = makeId;
        }


        public int CarType_ID { get; set; }
        public string CarTypeName { get; set; }
        public int Make_ID { get; set; }
    }
}
