using System;
//using Lace.Domain.DataProviders.Lightstone.Business.Director.LightstoneBusinessServiceReference;

namespace Lace.Domain.DataProviders.Lightstone.Business.Director.Infrastructure.Dto
{
    public class Confirmation
    {
        private Confirmation(bool paid, Guid reportGuid)
        {
            Paid = paid;
            ReportGuid = reportGuid;
        }

        //public static Confirmation Get(reportTrans report)
        //{
        //    return new Confirmation(report.paid,report.report_guid);
        //}

        public bool Valid()
        {
            return ReportGuid != Guid.Empty;
        }

        public bool Paid { get; private set; }
        public Guid ReportGuid { get; private set; }
    }
}
