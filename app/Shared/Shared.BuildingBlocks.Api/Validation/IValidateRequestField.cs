namespace Shared.BuildingBlocks.Api.Validation
{
    public interface IValidateRequestField
    {
        string RuleError { get; }
        bool RulesPass(string field);
    }
}
