using System.Collections.Generic;

namespace Workflow.Reporting.Entities
{
    public class ReportCustomer
    {
        public string Name { get; set; }
        public long TaxRegistration { get; set; }
        public List<ReportPackage> Packages { get; set; }
    }
}