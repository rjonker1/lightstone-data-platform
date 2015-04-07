namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IHaveCoOrdinates
    {
        double Latitude { get; }
        double Longitude { get; }
        string Image { get; }
    }
}
