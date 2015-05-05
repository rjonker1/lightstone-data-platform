using Workflow.Reporting.Entities;

namespace Workflow.Reporting.Dtos
{
    public class ReportDto
    {
        public ReportTemplate template { get; set; }
        public ReportData data { get; set; }    
    }
}