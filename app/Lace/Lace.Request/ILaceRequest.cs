using System;
using DataPlatform.Shared.Public.Entities;

namespace Lace.Request
{
    public interface ILaceRequest
    {
        Guid UserId { get; }
        Guid Token { get; }
        string UserName { get; }
        string UserFirstName { get; }
        string UserLastName { get; }

        string UserEmail { get; }
        string UserPhone { get; }

        DateTime RequestDate { get; }
        
        string EngineNo { get; }
        string VinOrChassis { get; }
        string Make { get; }
        string RegisterNo { get; }
        string LicenceNo { get; }
        string Product { get; }
        string ReasonForApplication { get; }

        string Vin { get; }

        string SecurityCode { get; }

        IPackage Package { get; }
    }
}
