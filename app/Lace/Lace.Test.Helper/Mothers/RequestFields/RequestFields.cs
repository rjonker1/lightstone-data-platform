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

    public class RegisterNumberRequestField : IAmRegisterNumberRequestField
    {
        private RegisterNumberRequestField(string field)
        {
            Field = field;
        }

        public static IAmRegisterNumberRequestField Get(string field)
        {
            return new RegisterNumberRequestField(field);
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

    public class UsernameRequestField : IAmUserNameRequestField
    {
        private UsernameRequestField(string field)
        {
            Field = field;
        }

        public static IAmUserNameRequestField Get(string field)
        {
            return new UsernameRequestField(field);
        }

        public string Field { get; private set; }
    }

    public class RegistrationCodeRequestField : IAmRegistrationCodeRequestField
    {
        private RegistrationCodeRequestField(string field)
        {
            Field = field;
        }

        public static IAmRegistrationCodeRequestField Get(string field)
        {
            return new RegistrationCodeRequestField(field);
        }

        public string Field { get; private set; }
    }

    public class ScanDataRequestField : IAmScanDataRequestField
    {
        private ScanDataRequestField(string field)
        {
            Field = field;
        }

        public static IAmScanDataRequestField Get(string field)
        {
            return new ScanDataRequestField(field);
        }

        public string Field { get; private set; }
    }

    public class CompanyNameRequestField : IAmCompanyNameRequestField
    {
        private CompanyNameRequestField(string field)
        {
            Field = field;
        }

        public static IAmCompanyNameRequestField Get(string field)
        {
            return new CompanyNameRequestField(field);
        }

        public string Field { get; private set; }
    }

    public class CompanyRegistrationNumberRequestField : IAmCompanyRegistrationNumberRequestField
    {
        private CompanyRegistrationNumberRequestField(string field)
        {
            Field = field;
        }

        public static IAmCompanyRegistrationNumberRequestField Get(string field)
        {
            return new CompanyRegistrationNumberRequestField(field);
        }

        public string Field { get; private set; }
    }

    public class CompanyVatNumberRequestField : IAmCompanyVatNumberRequestField
    {
        private CompanyVatNumberRequestField(string field)
        {
            Field = field;
        }

        public static IAmCompanyVatNumberRequestField Get(string field)
        {
            return new CompanyVatNumberRequestField(field);
        }

        public string Field { get; private set; }
    }

    //IAmSurnameRequestField
    public class FirstNameRequestField : IAmFirstNameRequestField
    {
        private FirstNameRequestField(string field)
        {
            Field = field;
        }

        public static IAmFirstNameRequestField Get(string field)
        {
            return new FirstNameRequestField(field);
        }

        public string Field { get; private set; }
    }

    public class SurnameRequestField : IAmSurnameRequestField
    {
        private SurnameRequestField(string field)
        {
            Field = field;
        }

        public static IAmSurnameRequestField Get(string field)
        {
            return new SurnameRequestField(field);
        }

        public string Field { get; private set; }
    }
}
