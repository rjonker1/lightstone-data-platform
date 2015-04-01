namespace Lace.Domain.Core.Contracts.Requests
{
    public interface IHaveCoOrdinateInformation
    {
        double Latitude { get; }
        double Longitude { get; }
        string Image { get; }
    }
}
