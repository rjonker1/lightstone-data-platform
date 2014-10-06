namespace Lace.Domain.Core.Contracts
{
    public interface IResponseProviderHandled
    {
        bool Handled { get; }
        void HasNotBeenHandled();
        void HasBeenHandled();
    }
}
