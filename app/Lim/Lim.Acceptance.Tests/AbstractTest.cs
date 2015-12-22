using Lim.Web.UI;
using Xunit.Extensions;

namespace Lim.Acceptance.Tests
{
    public abstract class AbstractTest : Specification
    {
        protected AbstractTest()
        {
            AutoMapperConfiguration.Configure();
        }
    }
}