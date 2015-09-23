using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Test.Helper.Mothers.Packages
{
    public class CriticalFailure : ICauseCriticalFailure
    {
        public CriticalFailure(bool @true, string message)
        {
            True = @true;
            Message = message;
        }
        public bool True { get; private set; }
        public string Message { get; private set; }
    }
}