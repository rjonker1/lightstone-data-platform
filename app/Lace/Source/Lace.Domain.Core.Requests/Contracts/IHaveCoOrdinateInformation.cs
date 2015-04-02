namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IHaveCoOrdinateInformation
    {
        double Latitude { get; }
        double Longitude { get; }
        string Image { get; }
    }
}
