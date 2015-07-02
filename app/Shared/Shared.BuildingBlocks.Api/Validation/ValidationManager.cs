﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Shared.BuildingBlocks.Api.Validation.Types;

namespace Shared.BuildingBlocks.Api.Validation
{
    public class ValidationResult
    {
        public readonly bool IsValid;
        public readonly string Error;

        public ValidationResult(bool isValid, string error)
        {
            IsValid = isValid;
            Error = error;
        }
    }

    public sealed class ValidationManager
    {
        private static readonly Dictionary<int, Func<IValidateRequestField>> Validators = new Dictionary<int, Func<IValidateRequestField>>()
        {
            {1, () => new VinNumberValidation()},
            {2, () => new LicensePlateValidation()},
            {3, () => new RegistrationNumberValidation()},
            {4, () => new EngineNumberValidation()},
            {16, () => new IdentityNumberValidation()}
        };

        static ValidationManager()
        {
        }

        public static ValidationResult Validate(int type, string field)
        {
            var validator = Validators.FirstOrDefault(w => w.Key == type);
            return validator.Key > 0 && validator.Value != null
                ? new ValidationResult(validator.Value().RulesPass(RemoveWhitespace(field)), validator.Value().RuleError)
                : new ValidationResult(true, string.Empty);
        }

        private static string RemoveWhitespace(string plate)
        {
            return Regex.Replace(plate, @"\s+", "");
        }
    }
}