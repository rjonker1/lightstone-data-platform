namespace Lace.Domain.DataProviders.Lightstone.Core.Models
{
    public class Municipality
    {
        private const string SelectAll = @"SELECT * FROM Municipality";
        public Municipality()
        {

        }

        public Municipality(int muncipalityId, string muncipalityName)
        {
            Municipality_ID = muncipalityId;
            MunicipalityName = muncipalityName;
        }

        public static string GetAll()
        {
            return SelectAll;
        }

        public int Municipality_ID { get; set; }
        public string MunicipalityName { get; set; }
    }
}
