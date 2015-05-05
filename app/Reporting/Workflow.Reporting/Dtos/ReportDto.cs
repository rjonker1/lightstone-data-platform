using Workflow.Reporting.Entities;

namespace Workflow.Reporting.Dtos
{
    public class ReportDto
    {
        public ReportTemplate Template { get; set; }
        public ReportData Data { get; set; }    
    }
}