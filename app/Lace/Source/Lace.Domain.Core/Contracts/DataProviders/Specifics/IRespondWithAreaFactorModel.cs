namespace Lace.Domain.Core.Contracts.DataProviders.Specifics
{
    public interface IRespondWithAreaFactorModel
    {
        string Municipality { get; }
        int Index { get; }
        double Value { get; }
    }
}