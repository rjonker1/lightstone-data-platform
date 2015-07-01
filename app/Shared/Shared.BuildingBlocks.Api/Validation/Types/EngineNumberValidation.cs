namespace Shared.BuildingBlocks.Api.Validation.Types
{
    public sealed class EngineNumberValidation : IValidateRequestField
    {
        static EngineNumberValidation()
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
