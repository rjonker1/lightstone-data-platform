﻿using System;
namespace Lace.Request
{
    public interface ILaceRequest
    {
        Guid UserId { get; }
        string UserName { get; }
        string UserFirstName { get; }
        string UserLastName { get; }

        string UserEmail { get; }
        string UserPhone { get; }

        //int CompanyId { get; set; }
        //int ContractId { get; set; }
        //string ProductName { get; set; }
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

        string[] Sources { get; }
    }
}
