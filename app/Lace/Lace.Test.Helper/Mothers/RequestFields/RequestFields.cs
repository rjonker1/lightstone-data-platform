using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace Lace.Test.Helper.Mothers.RequestFields
{
    public class VinNumberRequestField : IAmVinNumberRequestField
    {
        private VinNumberRequestField(string field)
        {
            Field = field;
        }

        public static IAmVinNumberRequestField Get(string field)
        {
            return new VinNumberRequestField(field);
        }

        public string Field { get; private set; }
    }

    public class ApplicatonNameField : IAmApplicantNameRequestField
    {
        private ApplicatonNameField(string field)
        {
            Field = field;
        }

        public static IAmApplicantNameRequestField Get(string field)
        {
            return new ApplicatonNameField(field);
        }

        public string Field { get; private set; }
    }

    public class PackageNameField : IAmLabelRequestField
    {
        private PackageNameField(string field)
        {
            Field = field;
        }

        public static IAmLabelRequestField Get(string field)
        {
            return new PackageNameField(field);
        }

        public string Field { get; private set; }
    }

    public class LicenceNumberField : IAmLicenceNumberRequestField
    {
        private LicenceNumberField(string field)
        {
            Field = field;
        }

        public static IAmLicenceNumberRequestField Get(string field)
        {
            return new LicenceNumberField(field);
        }

        public string Field { get; private set; }
    }

    public class EmailField : IAmRequesterEmailRequestField
    {
        private EmailField(string field)
        {
            Field = field;
        }

        public static IAmRequesterEmailRequestField Get(string field)
        {
            return new EmailField(field);
        }

        public string Field { get; private set; }
    }

    public class RequestorNameField : IAmRequesterNameRequestField
    {
        private RequestorNameField(string field)
        {
            Field = field;
        }

        public static IAmRequesterNameRequestField Get(string field)
        {
            return new RequestorNameField(field);
        }

        public string Field { get; private set; }
    }

    public class RequesterPhoneField : IAmRequesterPhoneRequestField
    {
        private RequesterPhoneField(string field)
        {
            Field = field;
        }

        public static IAmRequesterPhoneRequestField Get(string field)
        {
            return new RequesterPhoneField(field);
        }

        public string Field { get; private set; }
    }

    public class CarIdRequestField : IAmCarIdRequestField
    {
        private CarIdRequestField(string field)
        {
            Field = field;
        }

        public static IAmCarIdRequestField Get(string field)
        {
            return new CarIdRequestField(field);
        }

        public string Field { get; private set; }
    }

    public class YearRequestField : IAmYearRequestField
    {
        private YearRequestField(string field)
        {
            Field = field;
        }

        public static IAmYearRequestField Get(string field)
        {
            return new YearRequestField(field);
        }

        public string Field { get; private set; }
    }

    public class MakeRequestField : IAmMakeRequestField
    {
        private MakeRequestField(string field)
        {
            Field = field;
        }

        public static IAmMakeRequestField Get(string field)
        {
            return new MakeRequestField(field);
        }

        public string Field { get; private set; }
    }

    public class IdentityNumberRequestField : IAmIdentityNumberRequestField
    {
        private IdentityNumberRequestField(string field)
        {
            Field = field;
        }

        public static IAmIdentityNumberRequestField Get(string field)
        {
            return new IdentityNumberRequestField(field);
        }

        public string Field { get; private set; }
    }


    public class MaxRowsToReturnRequestField : IAmMaxRowsToReturnRequestField
    {
        private MaxRowsToReturnRequestField(string field)
        {
            Field = field;
        }

        public static IAmMaxRowsToReturnRequestField Get(string field)
        {
            return new MaxRowsToReturnRequestField(field);
        }

        public string Field { get; private set; }
    }

    public class TrackingNumberRequestField : IAmTrackingNumberRequestField
    {
        private TrackingNumberRequestField(string field)
        {
            Field = field;
        }

        public static IAmTrackingNumberRequestField Get(string field)
        {
            return new TrackingNumberRequestField(field);
        }

        public string Field { get; private set; }
    }

    public class UserIdRequestField : IAmUserIdRequestField
    {
        private UserIdRequestField(string field)
        {
            Field = field;
        }

        public static IAmUserIdRequestField Get(string field)
        {
            return new UserIdRequestField(field);
        }

        public string Field { get; private set; }
    }
}
