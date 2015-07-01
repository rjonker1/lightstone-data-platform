using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace DataPlatform.Shared.Validation.Types
{
    public sealed class LicensePlateValidation : IValidateRequestField
    {
        private static MandatoryLicensePlateRules _mandatoryRules;
        private static LicensePlateLegislationRules _legislationRules; 

        static LicensePlateValidation()
        {
            
        }

        public bool RulesPass(string field)
        {
            _mandatoryRules= new MandatoryLicensePlateRules(field);
            _legislationRules = new LicensePlateLegislationRules(_mandatoryRules.LicensePlate);
            return _mandatoryRules.IsValid && _legislationRules.IsValid;
        }

        public string RuleError
        {
            get
            {
                return !_mandatoryRules.IsValid ? _mandatoryRules.ErrorMessage : _legislationRules.GetError();
            }
        }

        public static string GetCleanedLicensePlate
        {
            get
            {
                return _mandatoryRules.LicensePlate.ToUpper();
            }
        }

    }

    internal sealed class MandatoryLicensePlateRules
    {
        public readonly string LicensePlate;
        public readonly string ErrorMessage = "Invalid License Plate Number";

        static MandatoryLicensePlateRules()
        {
            
        }

        public MandatoryLicensePlateRules(string licensePlate)
        {
            LicensePlate = RemoveWhitespace(licensePlate);
        }

        public bool IsValid
        {
            get
            {
                return !string.IsNullOrWhiteSpace(LicensePlate) && IsMaxNineCharacters && IsAMinimumOfThreeCharacters &&
                       IsAlpanumeric && HasNoSpecialCharacters;
            }
        }

        private bool IsMaxNineCharacters
        {
            get
            {
                return LicensePlate.Length < 10;
            }
        }

        private bool IsAMinimumOfThreeCharacters
        {
            get
            {
                return LicensePlate.Length >= 3;
            }
        }

        private bool IsAlpanumeric
        {
            get
            {
                return !LicensePlate.All(char.IsNumber);
            }
        }

        private bool HasNoSpecialCharacters
        {
            get
            {
                return
                    (Regex.Replace(LicensePlate, @"[^0-9a-zA-Z]+", "")
                        .Equals(LicensePlate, StringComparison.CurrentCultureIgnoreCase));
            }
        }

        private static string RemoveWhitespace(string plate)
        {
            return Regex.Replace(plate, @"\s+", "");
        }
    }

    internal sealed class LicensePlateLegislationRules
    {
        private readonly string _licensePlate;

        static LicensePlateLegislationRules()
        {
            
        }

        public LicensePlateLegislationRules(string licensePlate)
        {
            _licensePlate = licensePlate;
        }

        public bool IsValid
        {
            get
            {
                return IsCompatible.True && IsNotGoverment.True && IsProvincial.True;
            }
        }

        public string GetError()
        {
            var checks = new[]
            {
                IsCompatible,
                IsNotGoverment,
                IsProvincial
            };

            return checks.Any(f => f.True == false)
                ? checks.FirstOrDefault(f => f.True == false).ErrorMessage
                : string.Empty;
        }

        private RuleCheck IsCompatible
        {
            get
            {
                return
                    new RuleCheck(
                        IncompatibleLicensePlates.FirstOrDefault(
                            f => f.Equals(_licensePlate, StringComparison.CurrentCultureIgnoreCase)) == null,
                        "Invalid License Plate. Please enter the correct license plate number");
            }
        }

        private RuleCheck IsNotGoverment
        {
            get
            {
                return new RuleCheck(
                    GovermentPlates.FirstOrDefault(
                        f => _licensePlate.EndsWith(f, StringComparison.CurrentCultureIgnoreCase)) ==
                    null, "Vehicle not eligible for quering");
            }
        }

        private RuleCheck IsProvincial
        {
            get
            {
                return new RuleCheck(IsEndingWithProvincial || IsStartingWithProvincial, "License Plate Number is Invalid");
            }
        }

        private bool IsEndingWithProvincial
        {
            get
            {
                return
                    ProvincialPlatesEnding.FirstOrDefault(
                        f => _licensePlate.EndsWith(f, StringComparison.CurrentCultureIgnoreCase)) != null;
            }
        }

        private bool IsStartingWithProvincial
        {
            get
            {
                return
                    ProvincialPlateStart.FirstOrDefault(
                        f => _licensePlate.StartsWith(f, StringComparison.CurrentCultureIgnoreCase)) != null;
            }
        }


        private static readonly string[] IncompatibleLicensePlates = new[]
        {
            "TBA",
            "UNKNOWN"
        };

        private static readonly string[] GovermentPlates = new[]
        {
            "ZK",
            "G",
            "B",
            "D"
        };

        private static readonly string[] ProvincialPlatesEnding = new[]
        {
            "L",
            "GP",
            "FS",
            "MP",
            "NC",
            "NW",
            "EC",
            "Z",
            "N",
            "WP"
        };

        private static readonly string[] ProvincialPlateStart = new[]
        {
            "N",
            "C"
        };
    }

    public class RuleCheck
    {
        public readonly bool True;
        public readonly string ErrorMessage;

        public RuleCheck(bool @true, string errorMessage)
        {
            True = @true;
            ErrorMessage = errorMessage;
        }
    }
}