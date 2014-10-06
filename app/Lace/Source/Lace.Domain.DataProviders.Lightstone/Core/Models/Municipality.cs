namespace Lace.Domain.DataProviders.Lightstone.Core.Models
{
    public class Municipality
    {
        public Municipality()
        {

        }

        public Municipality(int muncipalityId, string muncipalityName)
        {
            Municipality_ID = muncipalityId;
            MunicipalityName = muncipalityName;
        }

        public int Municipality_ID { get; set; }
        public string MunicipalityName { get; set; }
    }
}
