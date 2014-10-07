namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface ITransformResponseFromDataProvider
    {
        bool Continue { get; }
        void Transform();
    }
}
