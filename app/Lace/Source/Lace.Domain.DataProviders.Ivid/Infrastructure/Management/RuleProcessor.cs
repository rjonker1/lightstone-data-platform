using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;

namespace Lace.Domain.DataProviders.Ivid.Infrastructure.Management
{
    public static class RuleProcessor
    {
        private static StatusMessageType _statusMessage;
        static RuleProcessor()
        {

        }

        public static void ForReportStatusMessage(HpiStandardQueryRequest request, IvidResponse response)
        {
            CheckFurtherInvestigation(response);
            CheckLicensePlate(request,response);
        }

        private static void CheckFurtherInvestigation(IvidResponse response)
        {
            _statusMessage = response.HasIssues || response.HasNoRecords
                ? StatusMessageType.FurtherInvestigation
                : StatusMessageType.NoStatusFeedbackRequired;
            response.AddReportStatusMessage(ReportStatusMessages.FirstOrDefault(w => w.Key == _statusMessage).Value);
        }

        private static void CheckLicensePlate(HpiStandardQueryRequest request, IvidResponse response)
        {
            _statusMessage = !string.IsNullOrEmpty(request.LicenceNo) && !string.IsNullOrEmpty(response.License) &&
                   !response.License.Equals(request.LicenceNo, StringComparison.CurrentCultureIgnoreCase)
                ? StatusMessageType.LicensePlateMismatch
                : StatusMessageType.NoStatusFeedbackRequired;

            response.AddReportStatusMessage(ReportStatusMessages.FirstOrDefault(w => w.Key == _statusMessage).Value);
        }

        private enum StatusMessageType
        {
            NoStatusFeedbackRequired,
            FurtherInvestigation,
            LicensePlateMismatch
        }

        private static readonly IDictionary<StatusMessageType, string> ReportStatusMessages = new Dictionary<StatusMessageType, string>()
        {
            {
                StatusMessageType.FurtherInvestigation,
                "Vehicle requires further investigation.  Please contact IVID on (033) 234 4083 or ivid@telkomsa.net"
            },
            {StatusMessageType.LicensePlateMismatch, "The licence plate number for this vehicle has changed. Please check the vehicle carefully."},
            {StatusMessageType.NoStatusFeedbackRequired, null}

        };
    }
}