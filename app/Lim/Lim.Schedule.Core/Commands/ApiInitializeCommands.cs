using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Lim.Domain.Dto;
using Lim.Enums;
using Lim.Schedule.Core.Identifiers;

namespace Lim.Schedule.Core.Commands
{
    public class ApiInitializePullCommand
    {
        public ApiInitializePullCommand()
        {

        }

    }

    [DataContract]
    public class ApiInitializePushCommand
    {
        public ApiInitializePushCommand(IEnumerable<IntegrationPackageDto> packages, AuthenticationType authenticationType, AuditIntegrationCommand audit, ApiConfigurationIdentifier configuration, long configurationId)
        {
            Packages = packages;
            PackageTransactions = new List<PackageTransactionDto>();
        //    DateRange = dateRange;
            AuthenticationType = authenticationType;
            Audit = audit;
            Configuration = configuration;
            ConfigurationId = configurationId;
        }

        [DataMember] public readonly long ConfigurationId;
        [DataMember] public readonly IEnumerable<IntegrationPackageDto> Packages;
        [DataMember] public readonly List<PackageTransactionDto> PackageTransactions;
      //  [DataMember] public readonly DateTime DateRange;
        [DataMember] public readonly AuthenticationType AuthenticationType;
        [DataMember] public readonly AuditIntegrationCommand Audit;
        [DataMember] public readonly ApiConfigurationIdentifier Configuration;
    }
}