namespace Lace.Domain.Core.Contracts.Requests
{
    public interface IProvideContextForRequest
    {
        string Product { get; }
        string ReasonForApplication { get; }

       // string Vin { get; }

        string SecurityCode { get; }
    }
}
