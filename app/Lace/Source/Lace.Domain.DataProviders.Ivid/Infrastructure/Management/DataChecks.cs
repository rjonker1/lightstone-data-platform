using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;

namespace Lace.Domain.DataProviders.Ivid.Infrastructure.Management
{
    public static class DataChecks
    {
        static DataChecks()
        {

        }

        public static readonly IDictionary<StatusMessageType, string> ReportStatusMessages = new Dictionary<StatusMessageType, string>()
        {
            {
                StatusMessageType.FurtherInvestigation,
                "Vehicle requires further investigation.  Please contact IVID on (033) 234 4083 or ivid@telkomsa.net"
            },
            {StatusMessageType.LicensePlateMismatch, "The licence plate number for this vehicle has changed. Please check the vehicle carefully."},
            {StatusMessageType.NoStatusFeedbackRequired, null}
        };

        public static StatusMessageType ResponseChecks(bool check, ValidationTest test)
        {
            var dataTests = new Dictionary<ValidationTest, Func<bool,StatusMessageType>>();
            dataTests[ValidationTest.LicensePlateMismatch] = (c) => c ? StatusMessageType.LicensePlateMismatch : StatusMessageType.NoStatusFeedbackRequired;
            dataTests[ValidationTest.FurtherInvestigation] = (c) => c ? StatusMessageType.FurtherInvestigation : StatusMessageType.NoStatusFeedbackRequired;
            return dataTests.FirstOrDefault(w => w.Key == test).Value(check);
        }

        public enum StatusMessageType
        {
            NoStatusFeedbackRequired,
            FurtherInvestigation,
            LicensePlateMismatch
        }

        public enum ValidationTest
        {
            LicensePlateMismatch,
            FurtherInvestigation
        }
    }
}