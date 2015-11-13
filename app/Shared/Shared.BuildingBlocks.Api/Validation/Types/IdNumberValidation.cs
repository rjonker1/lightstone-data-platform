namespace Shared.BuildingBlocks.Api.Validation.Types
{
    public sealed class IdentityNumberValidation : IValidateRequestField
    {
        private static MandatoryIdentityRules _mandatoryRules;

        static IdentityNumberValidation()
        {
        }

        public bool RulesPass(string field)
        {
            _mandatoryRules = new MandatoryIdentityRules(field);
            return _mandatoryRules.IsValid;
        }

        public string RuleError
        {
            get { return _mandatoryRules.ErrorMessage; }
        }
    }

    internal sealed class MandatoryIdentityRules
    {
        public readonly string IdentityNumber;
        public readonly string ErrorMessage = "ID number provided is not valid";

        static MandatoryIdentityRules()
        {
        }

        public MandatoryIdentityRules(string identityNumber)
        {
            IdentityNumber = identityNumber;
        }

        public bool IsValid
        {
            get
            {
                return IsThirteenCharacters && IsAValidIdNumber;
            }
        }

        private bool IsThirteenCharacters
        {
            get
            {
                return !string.IsNullOrEmpty(IdentityNumber) && IdentityNumber.Length == 13;
            }
        }

        

        private bool IsAValidIdNumber
        {
            get
            {
                var d = -1;
                try
                {
                    var a = 0;
                    for (var i = 0; i < 6; i++)
                    {
                        a += int.Parse(IdentityNumber[2 * i].ToString());
                    }
                    var b = 0;
                    for (var i = 0; i < 6; i++)
                    {
                        b = b * 10 + int.Parse(IdentityNumber[2 * i + 1].ToString());
                    }
                    b *= 2;
                    var c = 0;
                    do
                    {
                        c += b%10;
                        b = b/10;
                    } while (b > 0);
                    c += a;
                    d = 10 - (c%10);
                    if (d == 10) d = 0;
                }
                catch
                {

                }
                return d >= 0 && d <= 9;
            }
        }

    }
}
