namespace Lace.Request
{
    public interface IProvideCoOrdinateInformationForRequest
    {
        double Latitude { get; }
        double Longitude { get; }
        string Image { get; }
    }
}
