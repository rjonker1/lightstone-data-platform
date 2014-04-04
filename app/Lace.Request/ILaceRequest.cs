using System;
namespace Lace.Request
{
    public interface ILaceRequest
    {
        Guid UserId { get; }
        string CompanyId { get; }
        string ContractId { get; }
        DateTime RequestDate { get; }

        string LicensePlateNumber { get; }
        string[] Sources { get; }
    }
}
