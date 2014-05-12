namespace Lace.Request.Entry.Checks
{
    public class CheckTheReceivedRequest : ICheckForDuplicateRequests
    {
        public bool IsRequestDuplicated(ILaceRequest request)
        {
            return false;
        }
    }
}
