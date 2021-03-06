﻿using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lim.Domain.Entities.Factory;
using NHibernate.Linq;

namespace Lim.Domain.Entities.Repository
{
    public interface ISaveApiConfiguration
    {
        bool SaveConfiguration(long clientId, short actionId, short frequencyId, short integrationId, short authenticationId, Configuration configuration, ConfigurationApi apiConfiguration, List<IntegrationPackage> packages,
            List<IntegrationContract> contracts, List<IntegrationClient> clients);
    }

    public class SaveApiConfiguration : ISaveApiConfiguration
    {
        private readonly ILog _log;

        public SaveApiConfiguration()
        {
            _log = LogManager.GetLogger(GetType());
        }

        public bool SaveConfiguration(long clientId, short actionId, short frequencyId, short integrationId, short authenticationId, Configuration configuration, ConfigurationApi apiConfiguration, List<IntegrationPackage> packages,
            List<IntegrationContract> contracts, List<IntegrationClient> clients)
        {
            try
            {
                using (var session = FactoryManager.Instance.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        var client = session.Get<Client>(clientId);
                        if (client == null || client.Id == 0)
                            throw new Exception("Could not insert LIM configuration because LIM Client is not valid");

                        var frequency = session.Get<FrequencyType>(frequencyId);
                        var action = session.Get<ActionType>(actionId);
                        var integration = session.Get<IntegrationType>(integrationId);

                        configuration.Client = client;
                        configuration.FrequencyType = frequency;
                        configuration.ActionType = action;
                        configuration.IntegrationType = integration;
                        session.SaveOrUpdate(configuration);
                        session.Flush();

                        if (configuration.Id == 0)
                            throw new Exception("Could not insert LIM configuration because configuration id is not valid");

                        var authentication = session.Get<AuthenticationType>(authenticationId);

                        apiConfiguration.AuthenticationType = authentication;

                        var apiConfigurationId = session.Query<ConfigurationApi>().Where(w => w.Configuration.Id == configuration.Id);
                        var currentApiId = apiConfigurationId.FirstOrDefault() == null || apiConfigurationId.FirstOrDefault().Id == 0 ? 0 : apiConfigurationId.FirstOrDefault().Id;

                        apiConfiguration.Id = currentApiId;
                        session.Merge(apiConfiguration);
                        session.Flush();
                        

                        var integrationClients = session.Query<IntegrationClient>().Where(w => w.Configuration.Id == configuration.Id);
                        var integrationContracts = session.Query<IntegrationContract>().Where(w => w.Configuration.Id == configuration.Id);
                        var integrationPackages = session.Query<IntegrationPackage>().Where(w => w.Configuration.Id == configuration.Id);

                        foreach (var integrationClient in integrationClients)
                        {
                            integrationClient.IsActive = false;
                            session.Merge(integrationClient);
                        }

                        foreach (var integrationContract in integrationContracts)
                        {
                            integrationContract.IsActive = false;
                            session.Merge(integrationContract);
                        }

                        foreach (var integrationPackage in integrationPackages)
                        {
                            integrationPackage.IsActive = false;
                            session.Merge(integrationPackage);
                        }

                        foreach (var package in packages)
                        {
                            var existing = integrationPackages.FirstOrDefault(w => w.PackageId == package.PackageId);
                            var id = existing == null || existing.Id == 0 ? 0 : existing.Id;

                            if (id > 0)
                            {
                                var evict = session.Get(typeof (IntegrationPackage), id);
                                session.Evict(evict);
                            }

                            package.Id = id;
                            session.Merge(package);
                        }

                        foreach (var contract in contracts)
                        {
                            var existing = integrationContracts.FirstOrDefault(w => w.Contract == contract.Contract);
                            var id = existing == null || existing.Id == 0 ? 0 : existing.Id;

                            if (id > 0)
                            {
                                var evict = session.Get(typeof (IntegrationContract), id);
                                session.Evict(evict);
                            }
                            contract.Id = id;
                            session.Merge(contract);
                        }

                        foreach (var clientCustomer in clients)
                        {
                            var existing = integrationClients.FirstOrDefault(w => w.ClientCustomerId == clientCustomer.ClientCustomerId);
                            var id = existing == null || existing.Id == 0 ? 0 : existing.Id;

                            clientCustomer.Id = id;

                            if (id > 0)
                            {
                                var evict = session.Get(typeof (IntegrationClient), id);
                                session.Evict(evict);
                            }

                            session.Merge(clientCustomer);
                        }

                        transaction.Commit();
                        session.Flush();
                        return configuration.Id > 0;
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