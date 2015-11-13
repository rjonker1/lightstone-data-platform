using System.Security.Cryptography.X509Certificates;

namespace Billing.Domain.Core.Entities
{
    public interface INamedEntity
    {
        string Name { get; } 
    }
}