namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IAmJisRequest : IPointToLaceRequest
    {
        IHaveJisInformation Jis { get; }
    }
}
