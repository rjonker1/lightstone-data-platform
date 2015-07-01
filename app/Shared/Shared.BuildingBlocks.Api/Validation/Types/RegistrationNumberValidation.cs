namespace Shared.BuildingBlocks.Api.Validation.Types
{
    public sealed class RegistrationNumberValidation : IValidateRequestField
    {
        static RegistrationNumberValidation()
        {
        }

        public string RuleError
        {
            get { return null; }
        }

        public bool RulesPass(string field)
        {
            return true;
        }
    }
}
