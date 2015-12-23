using System;

namespace Lim.Dtos
{
    public class IntegrationDataExtractDto
    {
        public IntegrationDataExtractDto()
        {

        }

        private IntegrationDataExtractDto(long id, long configuration, long dataExtractId, DateTime dateCreated, string createdBy,
            DateTime? dateModified, string modifiedBy)
        {
            Id = id;
            Configuration = configuration;
            DataExtractId = dataExtractId;
            DateCreated = dateCreated;
            CreatedBy = createdBy;
            DateModified = dateModified;
            ModifiedBy = modifiedBy;
        }

        public static IntegrationDataExtractDto Existing(long id, long configuration, long dataExtractId, DateTime dateCreated,
            string createdBy,
            DateTime? dateModified, string modifiedBy)
        {
            return new IntegrationDataExtractDto(id, configuration, dataExtractId, dateCreated, createdBy, dateModified, modifiedBy);
        }

        public long Id { get; set; }
        public long Configuration { get; set; }
        public long DataExtractId { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
