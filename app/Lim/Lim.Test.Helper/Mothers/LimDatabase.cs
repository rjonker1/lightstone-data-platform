using System;
using System.Collections.Generic;
using System.Linq;
using Lim.Entities;

namespace Lim.Test.Helper.Mothers
{
    public class LimDatabase
    {
        public static List<Configuration> Configurations()
        {
            return new List<Configuration>()
            {
                new Configuration()
                {
                    ActionType = new ActionType()
                    {
                        Id = (short) Enums.IntegrationAction.Push,
                        Type = Enums.IntegrationAction.Push.ToString()
                    },
                    Client = new Client()
                    {
                        ContactNumber = "",
                        ContactPerson = "",
                        Id = 1,
                        IsActive = true,
                        Name = "Lim Client"
                    },
                    ConfigurationKey = Guid.NewGuid(),
                    CustomFrequencyDay = Enums.Weekdays.Wednesday.ToString(),
                    CustomFrequencyTime = TimeSpan.Parse("14:00:00.00"),
                    FrequencyType = new FrequencyType()
                    {
                        Id = (short) Enums.Frequency.Custom,
                        Type = Enums.Frequency.Custom.ToString()
                    },
                    Id = 1,
                    IntegrationType = new IntegrationType()
                    {
                        Id = (short) Enums.IntegrationType.Api,
                        Type = Enums.IntegrationType.Api.ToString()
                    },
                    DateCreated = DateTime.UtcNow,
                    DateModified = null,
                    IsActive = true
                },
                new Configuration()
                {
                    ActionType = new ActionType()
                    {
                        Id = (short) Enums.IntegrationAction.Push,
                        Type = Enums.IntegrationAction.Push.ToString()
                    },
                    Client = new Client()
                    {
                        ContactNumber = "",
                        ContactPerson = "",
                        Id = 1,
                        IsActive = true,
                        Name = "Lim Client"
                    },
                    ConfigurationKey = Guid.NewGuid(),
                    CustomFrequencyDay = null,
                    CustomFrequencyTime = null,
                    FrequencyType = new FrequencyType()
                    {
                        Id = (short) Enums.Frequency.AlwaysOn,
                        Type = Enums.Frequency.AlwaysOn.ToString()
                    },
                    Id = 2,
                    IntegrationType = new IntegrationType()
                    {
                        Id = (short) Enums.IntegrationType.Api,
                        Type = Enums.IntegrationType.Api.ToString()
                    },
                    DateCreated = DateTime.UtcNow,
                    DateModified = null,
                    IsActive = true
                },
                new Configuration()
                {
                    ActionType = new ActionType()
                    {
                        Id = (short) Enums.IntegrationAction.Push,
                        Type = Enums.IntegrationAction.Push.ToString()
                    },
                    Client = new Client()
                    {
                        ContactNumber = "",
                        ContactPerson = "",
                        Id = 1,
                        IsActive = true,
                        Name = "Lim Client"
                    },
                    ConfigurationKey = Guid.NewGuid(),
                    CustomFrequencyDay = null,
                    CustomFrequencyTime = null,
                    FrequencyType = new FrequencyType()
                    {
                        Id = (short) Enums.Frequency.Daily,
                        Type = Enums.Frequency.Daily.ToString()
                    },
                    Id = 3,
                    IntegrationType = new IntegrationType()
                    {
                        Id = (short) Enums.IntegrationType.Api,
                        Type = Enums.IntegrationType.Api.ToString()
                    },
                    DateCreated = DateTime.UtcNow,
                    DateModified = null,
                    IsActive = true
                },
                new Configuration()
                {
                    ActionType = new ActionType()
                    {
                        Id = (short) Enums.IntegrationAction.Push,
                        Type = Enums.IntegrationAction.Push.ToString()
                    },
                    Client = new Client()
                    {
                        ContactNumber = "",
                        ContactPerson = "",
                        Id = 1,
                        IsActive = true,
                        Name = "Lim Client"
                    },
                    ConfigurationKey = Guid.NewGuid(),
                    CustomFrequencyDay = null,
                    CustomFrequencyTime = null,
                    FrequencyType = new FrequencyType()
                    {
                        Id = (short) Enums.Frequency.EveryMinute,
                        Type = Enums.Frequency.EveryMinute.ToString()
                    },
                    Id = 4,
                    IntegrationType = new IntegrationType()
                    {
                        Id = (short) Enums.IntegrationType.Api,
                        Type = Enums.IntegrationType.Api.ToString()
                    },
                    DateCreated = DateTime.UtcNow,
                    DateModified = null,
                    IsActive = true
                },
                new Configuration()
                {
                    ActionType = new ActionType()
                    {
                        Id = (short) Enums.IntegrationAction.Push,
                        Type = Enums.IntegrationAction.Push.ToString()
                    },
                    Client = new Client()
                    {
                        ContactNumber = "",
                        ContactPerson = "",
                        Id = 1,
                        IsActive = true,
                        Name = "Lim Client"
                    },
                    ConfigurationKey = Guid.NewGuid(),
                    CustomFrequencyDay = null,
                    CustomFrequencyTime = null,
                    FrequencyType = new FrequencyType()
                    {
                        Id = (short) Enums.Frequency.Hourly,
                        Type = Enums.Frequency.Hourly.ToString()
                    },
                    Id = 5,
                    IntegrationType = new IntegrationType()
                    {
                        Id = (short) Enums.IntegrationType.Api,
                        Type = Enums.IntegrationType.Api.ToString()
                    },
                    DateCreated = DateTime.UtcNow,
                    DateModified = null,
                    IsActive = true
                }
            };
        }

        public static List<ConfigurationApi> ApiConfigurations()
        {
            return new List<ConfigurationApi>()
            {
                new ConfigurationApi()
                {
                    AuthenticationKey = "X-Auth-Token",
                    AuthenticationToken = "2b1eeb42-0cf7-4234-b798-3bbaa293e273",
                    AuthenticationType = new AuthenticationType()
                    {
                        Id = (short) Enums.AuthenticationType.Basic,
                        Type = Enums.AuthenticationType.Basic.ToString()
                    },
                    BaseAddress = "http://dev.lim.test.api.lightstone.co.za",
                    Configuration = Configurations().FirstOrDefault(w => w.Id == 1),
                    HasAuthentication = true,
                    Id = 1,
                    Password = "49q42FwDSajrF9",
                    Username = "LightStoneAuto",
                    DateCreated = DateTime.UtcNow

                },
                new ConfigurationApi()
                {
                    AuthenticationKey = "X-Auth-Token",
                    AuthenticationToken = "2b1eeb42-0cf7-4234-b798-3bbaa293e273",
                    AuthenticationType = new AuthenticationType()
                    {
                        Id = (short) Enums.AuthenticationType.Basic,
                        Type = Enums.AuthenticationType.Basic.ToString()
                    },
                    BaseAddress = "http://dev.lim.test.api.lightstone.co.za",
                    Configuration = Configurations().FirstOrDefault(w => w.Id == 2),
                    HasAuthentication = true,
                    Id = 2,
                    Password = "49q42FwDSajrF9",
                    Username = "LightStoneAuto",
                    DateCreated = DateTime.UtcNow
                },
                new ConfigurationApi()
                {
                    AuthenticationKey = "X-Auth-Token",
                    AuthenticationToken = "2b1eeb42-0cf7-4234-b798-3bbaa293e273",
                    AuthenticationType = new AuthenticationType()
                    {
                        Id = (short) Enums.AuthenticationType.Basic,
                        Type = Enums.AuthenticationType.Basic.ToString()
                    },
                    BaseAddress = "http://dev.lim.test.api.lightstone.co.za",
                    Configuration = Configurations().FirstOrDefault(w => w.Id == 3),
                    HasAuthentication = true,
                    Id = 3,
                    Password = "49q42FwDSajrF9",
                    Username = "LightStoneAuto",
                    DateCreated = DateTime.UtcNow
                },
                new ConfigurationApi()
                {
                    AuthenticationKey = "X-Auth-Token",
                    AuthenticationToken = "2b1eeb42-0cf7-4234-b798-3bbaa293e273",
                    AuthenticationType = new AuthenticationType()
                    {
                        Id = (short) Enums.AuthenticationType.Basic,
                        Type = Enums.AuthenticationType.Basic.ToString()
                    },
                    BaseAddress = "http://dev.lim.test.api.lightstone.co.za",
                    Configuration = Configurations().FirstOrDefault(w => w.Id == 4),
                    HasAuthentication = true,
                    Id = 4,
                    Password = "49q42FwDSajrF9",
                    Username = "LightStoneAuto",
                    DateCreated = DateTime.UtcNow
                },
                new ConfigurationApi()
                {
                    AuthenticationKey = "X-Auth-Token",
                    AuthenticationToken = "2b1eeb42-0cf7-4234-b798-3bbaa293e273",
                    AuthenticationType = new AuthenticationType()
                    {
                        Id = (short) Enums.AuthenticationType.Basic,
                        Type = Enums.AuthenticationType.Basic.ToString()
                    },
                    BaseAddress = "http://dev.lim.test.api.lightstone.co.za",
                    Configuration = Configurations().FirstOrDefault(w => w.Id == 5),
                    HasAuthentication = true,
                    Id = 5,
                    Password = "49q42FwDSajrF9",
                    Username = "LightStoneAuto",
                    DateCreated = DateTime.UtcNow
                }
            };
        }

        public static List<IntegrationClient> Clients()
        {
            return new List<IntegrationClient>()
            {
                new IntegrationClient()
                {
                    AccountNumber = 1,
                    ClientCustomerId = new Guid("E59C827E-B2CF-4B4B-8DD8-0EFEA3BA6410"),
                    Configuration = Configurations().FirstOrDefault(w => w.Id == 1),
                    Id = 1,
                    IsActive = true
                },
                new IntegrationClient()
                {
                    AccountNumber = 1,
                    ClientCustomerId = new Guid("E59C827E-B2CF-4B4B-8DD8-0EFEA3BA6410"),
                    Configuration = Configurations().FirstOrDefault(w => w.Id == 2),
                    Id = 1,
                    IsActive = true
                },
                new IntegrationClient()
                {
                    AccountNumber = 1,
                    ClientCustomerId = new Guid("E59C827E-B2CF-4B4B-8DD8-0EFEA3BA6410"),
                    Configuration = Configurations().FirstOrDefault(w => w.Id == 3),
                    Id = 1,
                    IsActive = true
                },
                new IntegrationClient()
                {
                    AccountNumber = 1,
                    ClientCustomerId = new Guid("E59C827E-B2CF-4B4B-8DD8-0EFEA3BA6410"),
                    Configuration = Configurations().FirstOrDefault(w => w.Id == 4),
                    Id = 1,
                    IsActive = true
                },
                new IntegrationClient()
                {
                    AccountNumber = 1,
                    ClientCustomerId = new Guid("E59C827E-B2CF-4B4B-8DD8-0EFEA3BA6410"),
                    Configuration = Configurations().FirstOrDefault(w => w.Id == 5),
                    Id = 1,
                    IsActive = true
                },
            };
        }

        public static List<IntegrationContract> Contracts()
        {
            return new List<IntegrationContract>()
            {
                new IntegrationContract()
                {
                    ClientCustomerId = new Guid("E59C827E-B2CF-4B4B-8DD8-0EFEA3BA6410"),
                    Configuration = Configurations().FirstOrDefault(f => f.Id == 1),
                    Contract = new Guid("B63F6F0C-D26A-4959-9E75-7C8C485CC495"),
                    DateCreated = DateTime.UtcNow,
                    Id = 1,
                    IsActive = true
                },
                new IntegrationContract()
                {
                    ClientCustomerId = new Guid("E59C827E-B2CF-4B4B-8DD8-0EFEA3BA6410"),
                    Configuration = Configurations().FirstOrDefault(f => f.Id == 2),
                    Contract = new Guid("B63F6F0C-D26A-4959-9E75-7C8C485CC495"),
                    DateCreated = DateTime.UtcNow,
                    Id = 2,
                    IsActive = true
                },
                new IntegrationContract()
                {
                    ClientCustomerId = new Guid("E59C827E-B2CF-4B4B-8DD8-0EFEA3BA6410"),
                    Configuration = Configurations().FirstOrDefault(f => f.Id == 3),
                    Contract = new Guid("B63F6F0C-D26A-4959-9E75-7C8C485CC495"),
                    DateCreated = DateTime.UtcNow,
                    Id = 3,
                    IsActive = true
                },
                new IntegrationContract()
                {
                    ClientCustomerId = new Guid("E59C827E-B2CF-4B4B-8DD8-0EFEA3BA6410"),
                    Configuration = Configurations().FirstOrDefault(f => f.Id == 4),
                    Contract = new Guid("B63F6F0C-D26A-4959-9E75-7C8C485CC495"),
                    DateCreated = DateTime.UtcNow,
                    Id = 4,
                    IsActive = true
                },
                new IntegrationContract()
                {
                    ClientCustomerId = new Guid("E59C827E-B2CF-4B4B-8DD8-0EFEA3BA6410"),
                    Configuration = Configurations().FirstOrDefault(f => f.Id == 5),
                    Contract = new Guid("B63F6F0C-D26A-4959-9E75-7C8C485CC495"),
                    DateCreated = DateTime.UtcNow,
                    Id = 4,
                    IsActive = true
                }
            };
        }

        public static List<IntegrationPackage> Packages()
        {
            return new List<IntegrationPackage>()
            {
                new IntegrationPackage()
                {
                    Configuration = Configurations().FirstOrDefault(f => f.Id == 1),
                    ContractId = Contracts().FirstOrDefault(w => w.Contract == new Guid("B63F6F0C-D26A-4959-9E75-7C8C485CC495")).Contract,
                    Id = 1,
                    IsActive = true,
                    PackageId = new Guid("390CD416-FC52-4A0B-98CE-8E8940212354")
                },
                new IntegrationPackage()
                {
                    Configuration = Configurations().FirstOrDefault(f => f.Id == 2),
                    ContractId = Contracts().FirstOrDefault(w => w.Contract == new Guid("B63F6F0C-D26A-4959-9E75-7C8C485CC495")).Contract,
                    Id = 2,
                    IsActive = true,
                    PackageId = new Guid("390CD416-FC52-4A0B-98CE-8E8940212354")
                },
                new IntegrationPackage()
                {
                    Configuration = Configurations().FirstOrDefault(f => f.Id == 3),
                    ContractId = Contracts().FirstOrDefault(w => w.Contract == new Guid("B63F6F0C-D26A-4959-9E75-7C8C485CC495")).Contract,
                    Id = 3,
                    IsActive = true,
                    PackageId = new Guid("390CD416-FC52-4A0B-98CE-8E8940212354")
                },
                new IntegrationPackage()
                {
                    Configuration = Configurations().FirstOrDefault(f => f.Id == 4),
                    ContractId = Contracts().FirstOrDefault(w => w.Contract == new Guid("B63F6F0C-D26A-4959-9E75-7C8C485CC495")).Contract,
                    Id = 4,
                    IsActive = true,
                    PackageId = new Guid("390CD416-FC52-4A0B-98CE-8E8940212354")
                },
                new IntegrationPackage()
                {
                    Configuration = Configurations().FirstOrDefault(f => f.Id == 5),
                    ContractId = Contracts().FirstOrDefault(w => w.Contract == new Guid("B63F6F0C-D26A-4959-9E75-7C8C485CC495")).Contract,
                    Id = 5,
                    IsActive = true,
                    PackageId = new Guid("390CD416-FC52-4A0B-98CE-8E8940212354")
                },
            };
        }

        public static List<PackageResponses> PackageResponseses()
        {
            return new List<PackageResponses>()
            {
                new PackageResponses()
                {
                    AccountNumber = 1,
                    CommitDate = DateTime.Now.AddDays(-10),
                    ContractId = new Guid("B63F6F0C-D26A-4959-9E75-7C8C485CC495"),
                    HasResponse = true,
                    PackageId = new Guid("390CD416-FC52-4A0B-98CE-8E8940212354"),
                    RequestId = Guid.NewGuid(),
                    Id = 1,
                    Payload = new byte[0],
                    ResponseDate = DateTime.Now.AddDays(-10)
                }
            };
        }
    }
}
