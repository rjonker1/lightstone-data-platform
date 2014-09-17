namespace Lace.Models
{
    public interface IResponseHandled
    {
        bool Handled { get; }
        void HasNotBeenHandled();
        void HasBeenHandled();
    }
}
