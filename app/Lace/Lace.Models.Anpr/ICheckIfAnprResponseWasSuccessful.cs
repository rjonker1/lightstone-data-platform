using Lace.Models.Responses.Sources;

namespace Lace.Models.Anpr
{
    public interface ICheckIfAnprResponseWasSuccessful
    {
        IProvideDataFromAnpr WasASuccess();
        IProvideDataFromAnpr WasAFailure(string errorMessage);
    }
}
