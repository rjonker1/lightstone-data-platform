using Lace.Domain.Core.Contracts.DataProviders;
namespace Lace.Domain.Core.Contracts
{
    public interface ICheckIfAnprResponseWasSuccessful
    {
        IProvideDataFromAnpr WasASuccess();
        IProvideDataFromAnpr WasAFailure(string errorMessage);
    }
}
