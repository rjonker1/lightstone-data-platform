using Lace.Response;

namespace Lace.Source.Repository
{
    public interface IRequestProductDataFromRepository
    {
        void FetchDataFromRepository(ILaceResponse response, IGetProductDataFromRepository repository);
    }
}
