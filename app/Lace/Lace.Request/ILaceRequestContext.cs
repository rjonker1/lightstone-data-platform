namespace Lace.Request
{
    public interface ILaceRequestContext
    {
        string Product { get; }
        string ReasonForApplication { get; }

       // string Vin { get; }

        string SecurityCode { get; }
    }
}
