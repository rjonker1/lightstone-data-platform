using System.Linq;

namespace DataPlatform.Shared.Validation
{
    public sealed class VinNumberValidation
    {
        private static MandatoryVinRules _mandatoryRules;
        static VinNumberValidation()
        {
            
        }

        public static bool RulesPass(string vinNumber)
        {
            _mandatoryRules = new MandatoryVinRules(vinNumber);
            return _mandatoryRules.IsValid;
        }

        public static string RuleError
        {
            get
            {
                return _mandatoryRules.Error;
            }
        }
    }

    internal sealed class MandatoryVinRules
    {
        public readonly string VinNumber;
      

        static MandatoryVinRules()
        {
        }

        public MandatoryVinRules(string vinNumber)
        {
            VinNumber = vinNumber;
        }

        public bool IsValid
        {
            get
            {
                return !string.IsNullOrWhiteSpace(VinNumber) && IsAlphanumeric.True && IsNotGreaterThanSeventeenCharacters.True &&
                       IsLessThanSixCharacters.True;
            }
        }

        public string Error
        {
            get
            {
                var checks = new[]
                {
                    IsAlphanumeric,
                    IsNotGreaterThanSeventeenCharacters,
                    IsLessThanSixCharacters
                };

                return checks.Any(f => f.True == false)
                    ? checks.FirstOrDefault(f => f.True == false).ErrorMessage
                    : string.Empty;
            }
        }

        private RuleCheck IsAlphanumeric
        {
            get
            {
                return new RuleCheck(!VinNumber.All(char.IsNumber), "Vin number is not alphanumeric");
            }
        }

        private RuleCheck IsNotGreaterThanSeventeenCharacters
        {
            get
            {
                return new RuleCheck(17 >= VinNumber.Length, "Vin number cannot be greater than 17 characters");
            }
        }

        private RuleCheck IsLessThanSixCharacters
        {
            get
            {
                return new RuleCheck(6 >= VinNumber.Length, "Vin number cannot be smaller than 6 characters");
            }
        }
    }
}