namespace DataPlatform.Shared.Validation
{
    public interface IValidateRequestField
    {
        string RuleError { get; }
        bool RulesPass(string field);
    }
}
