namespace Lace.Models
{
    public interface IResponseProviderHandled
    {
        bool Handled { get; }
        void HasNotBeenHandled();
        void HasBeenHandled();
    }
}
