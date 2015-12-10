
using System.Threading.Tasks;

namespace Workflow.Billing.Domain.Helpers.BillingRunHelpers
{
    public interface IPivotBilling<T> where T : class
    {
         void Pivot();
    }
}