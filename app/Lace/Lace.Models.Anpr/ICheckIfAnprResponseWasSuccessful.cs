namespace Lace.Models.Anpr
{
    public interface ICheckIfAnprResponseWasSuccessful
    {
        void WasASuccess();
        void WasAFailure(string errorMessage);
    }
}
