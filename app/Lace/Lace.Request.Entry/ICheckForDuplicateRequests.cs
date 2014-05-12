namespace Lace.Request.Entry
{
    public interface ICheckForDuplicateRequests
    {
        bool IsRequestDuplicated(ILaceRequest request);
    }
}
