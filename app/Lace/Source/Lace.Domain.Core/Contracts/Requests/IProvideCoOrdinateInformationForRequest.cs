namespace Lace.Domain.Core.Contracts.Requests
{
    public interface IProvideCoOrdinateInformationForRequest
    {
        double Latitude { get; }
        double Longitude { get; }
        string Image { get; }
    }
}
