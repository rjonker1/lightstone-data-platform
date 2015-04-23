namespace Lace.Domain.Core.Requests.Contracts.Requests
{
    public interface IAmJisRequest : IPointToLaceRequest
    {
        IHaveJisInformation Jis { get; }
    }
}
