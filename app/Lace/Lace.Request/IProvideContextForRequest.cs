namespace Lace.Request
{
    public interface IProvideContextForRequest
    {
        string Product { get; }
        string ReasonForApplication { get; }

       // string Vin { get; }

        string SecurityCode { get; }
    }
}
