using System;

namespace Lim.Entities
{
    public class IntegrationDataExtract
    {
        public virtual long Id { get; set; }
        public virtual Configuration Configuration { get; set; }
        public virtual long DataExtractId { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime? DateModified { get; set; }
        public virtual string ModifiedBy { get; set; }
    }
}
