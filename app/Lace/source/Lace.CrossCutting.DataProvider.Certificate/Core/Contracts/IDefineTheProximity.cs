namespace Lace.CrossCutting.DataProviderCommandSource.Certificate.Core.Contracts
{
    public interface IDefineTheProximity
    {
        double Latitude { get; }
        double Longitude { get; }
        double Radius { get; }
    }
}
