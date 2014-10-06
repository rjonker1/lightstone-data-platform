namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface ITransform
    {
        bool Continue { get; }
        void Transform();
    }
}
