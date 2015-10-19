using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders.Vin12;

namespace Lace.Domain.Core.Entities
{
    [DataContract]public class Vin12Record : IRespondWithVin12
    {
        public Vin12Record()
        {
            
        }

        public static Vin12Record Empty()
        {
            return new Vin12Record();
        }

        public Vin12Record(int carId, int year, string carFullName, string imageUrl, string bodyShape, string make)
        {
            CarId = carId;
            Year = year;
            CarFullName = carFullName;
            ImageUrl = imageUrl;
            BodyShape = bodyShape;
            Make = make;
        }

        [DataMember]
        public int CarId { get; private set; }

        [DataMember]
        public int Year { get; private set; }

        [DataMember]
        public string CarFullName { get; private set; }

        [DataMember]
        public string ImageUrl { get; private set; }

        [DataMember]
        public string BodyShape { get; private set; }

        [DataMember]
        public string Make { get; private set; }

        [DataMember]
        public System.Type Type
        {
            get { return GetType(); }
        }

        [DataMember]
        public string TypeName
        {
            get { return GetType().Name; }
        }
    }
}
