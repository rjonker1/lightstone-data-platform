using System;
using System.Linq;
using Common.Logging;
using Lim.Domain.Entities;
using Lim.Domain.Entities.Contracts;
using Lim.Enums;
using Lim.Web.UI.Models.Api;
using NHibernate;
using NHibernate.Linq;

namespace Lim.Web.UI.Commits
{
    public class ApiPushCommit : IPersistObject<PushConfiguration>
    {
        private readonly ISessionFactory _session;
        private readonly ILog _log;

        public ApiPushCommit(ISessionFactory session)
        {
            _session = session;
            _log = LogManager.GetLogger(GetType());
        }

        public bool Persist(PushConfiguration pushConfig)
        {
            try
            {
                using (var session = _session.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        var client = session.Get<Client>(pushConfig.ClientId);
                        if (client == null || client.Id == 0)
                            throw new Exception("Could not insert LIM configuration because LIM Client is not valid");

                        var configuration = new Configuration()
                        {
                            Id = pushConfig.Id,
                            Client = client,
                            FrequencyType = pushConfig.FrequencyType,
                            ActionType = pushConfig.ActionType,
                            IntegrationType = pushConfig.IntegrationType,
                            IsActive = pushConfig.IsActive,
                            DateModified = DateTime.UtcNow,
                            ModifiedBy = pushConfig.User ?? Environment.MachineName,
                            CustomFrequencyTime = pushConfig.FrequencyType == (int)Frequency.Custom ? pushConfig.CustomFrequency.TimeOfDay : TimeSpan.Parse("00:00"),
                            CustomFrequencyDay = pushConfig.FrequencyType == (int)Frequency.Custom ? pushConfig.CustomDay : null,

                        };

                        session.SaveOrUpdate(configuration);

                        if (configuration.Id == 0)
                            throw new Exception("Could not insert LIM configuration because configuration id is not valid");

                        var apiConfiguration = new ConfigurationApi()
                        {
                            Id = pushConfig.ConfigurationApiId,
                            Configuration = configuration,
                            BaseAddress = pushConfig.BaseAddress,
                            Suffix = pushConfig.Suffix,
                            Username = pushConfig.Username,
                            Password = pushConfig.Password,
                            HasAuthentication = pushConfig.HasAuthentication,
                            AuthenticationToken = pushConfig.AuthenticationToken,
                            AuthenticationKey = pushConfig.AuthenticationKey,
                            AuthenticationType = pushConfig.AuthenticationType
                        };

                        session.SaveOrUpdate(apiConfiguration);

                        var integrationClients = session.Query<IntegrationClients>().Where(w => w.Configuration.Id == configuration.Id);
                        var integrationContracts = session.Query<IntegrationContracts>().Where(w => w.Configuration.Id == configuration.Id);
                        var integrationPackages = session.Query<IntegrationPackages>().Where(w => w.Configuration.Id == configuration.Id);

                        foreach (var integrationClient in integrationClients)
                        {
                            integrationClient.IsActive = false;
                            session.SaveOrUpdate(integrationClient);
                        }

                        foreach (var integrationContract in integrationContracts)
                        {
                            integrationContract.IsActive = false;
                            session.SaveOrUpdate(integrationContract);
                        }

                        foreach (var integrationPackage in integrationPackages)
                        {
                            integrationPackage.IsActive = false;
                            session.SaveOrUpdate(integrationPackage);
                        }

                        foreach (var package in pushConfig.IntegrationPackages)
                        {
                            var contractId = pushConfig.SelectableDataPlatformPackages.FirstOrDefault(w => w.Id == package).ContractId;
                            var existing = integrationPackages.FirstOrDefault(w => w.PackageId == package);

                            var id = existing == null || existing.Id == 0 ? 0 : existing.Id;

                            var integrationPackage = new IntegrationPackages()
                            {
                                Id = id,
                                Configuration = configuration,
                                PackageId = package,
                                ContractId = contractId,
                                IsActive = true,
                                DateModified = DateTime.UtcNow,
                                ModifiedBy = pushConfig.User ?? Environment.MachineName
                            };

                            if (id > 0)
                            {
                                var evict = session.Get(typeof (IntegrationPackages), id);
                                session.Evict(evict);
                            }

                            session.SaveOrUpdate(integrationPackage);
                        }

                        foreach (var contract in pushConfig.IntegrationContracts)
                        {
                            var clientCustomerId = pushConfig.SelectableDataPlatformContracts.FirstOrDefault(w => w.Id == contract).ClientId;
                            var existing = integrationContracts.FirstOrDefault(w => w.Contract == contract);

                            var id = existing == null || existing.Id == 0 ? 0 : existing.Id;

                            var integrationContract = new IntegrationContracts()
                            {
                                Id = id,
                                Configuration = configuration,
                                Contract = contract,
                                ClientCustomerId = clientCustomerId,
                                IsActive = true,
                                DateModified = DateTime.UtcNow,
                                ModifiedBy = pushConfig.User ?? Environment.MachineName
                            };


                            if (id > 0)
                            {
                                var evict = session.Get(typeof(IntegrationContracts), id);
                                session.Evict(evict);
                            }
                            session.SaveOrUpdate(integrationContract);
                        }

                        foreach (var clientCustomer in pushConfig.IntegrationClients)
                        {
                            var existing = integrationClients.FirstOrDefault(w => w.ClientCustomerId == clientCustomer);
                            var id = existing == null || existing.Id == 0 ? 0 : existing.Id;
                            var integrationClient = new IntegrationClients()
                            {
                                Id = id,
                                Configuration = configuration,
                                ClientCustomerId = clientCustomer,
                                AccountNumber = pushConfig.AccountNumber,
                                IsActive = true,
                                DateModified = DateTime.UtcNow,
                                ModifiedBy = pushConfig.User ?? Environment.MachineName
                            };

                            if (id > 0)
                            {
                                var evict = session.Get(typeof(IntegrationClients), id);
                                session.Evict(evict);
                            }

                            session.SaveOrUpdate(integrationClient);
                        }
                        transaction.Commit();
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Failed to save information in the LIM database, because {0}", ex, ex.Message);
            }

            return false;
        }
    }
}