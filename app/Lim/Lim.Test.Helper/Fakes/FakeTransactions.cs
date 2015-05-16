using Lim.Push.Models;

namespace Lim.Test.Helper.Fakes
{
    public class FakeTransactions
    {
        public static Transaction ForPushApi()
        {
            return new Transaction();
        }
    }
}
