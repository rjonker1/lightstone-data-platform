using System;
namespace Lace.Request
{
    public interface ILaceRequest
    {
        Guid UserId { get; }
        string UserName { get; }
        string UserFirstName { get; }
        string UserLastName { get; }
       // string UserPassword { get; }

        string UserEmail { get; }
        string UserPhone { get; }

        string CompanyId { get; }
        string ContractId { get; }
        DateTime RequestDate { get; }

        //string LicensePlateNumber { get; }
        
        string EngineNo { get; }
        string VinOrChassis { get; }
        string Make { get; }
        string RegisterNo { get; }
        string LicenceNo { get; }
        string Product { get; }
        string ReasonForApplication { get; }

        string Vin { get; }

        string[] Sources { get; }
    }
}
