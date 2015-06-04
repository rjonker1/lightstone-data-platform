using System.Collections.Generic;
using System.Linq;
using Nancy;
using UserManagement.Domain.Dtos;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Api.Modules
{
    public class IntegrationModule : NancyModule
    {
        public IntegrationModule(ICustomerRepository customers, IClientRepository clients)
        {
            Get["/Integration/ClientCustomerContracts/All"] = param =>
            {
                var result = new List<IntegrationClientDto>();
                var clientContracts = clients.ToList().Select(
                    s =>
                        new IntegrationClientDto(s.Id, s.Name, s.ClientAccountNumber.ToString(), s.IsActive,
                            s.Contracts
                                .Select(c => new IntegrationContractDto(c.Id, c.Name, c.Packages
                                    .Select(p => new PackageDto() {PackageId = p.PackageId, Name = p.Name, IsActive = p.IsActive}))))).ToList();

                result.AddRange(clientContracts.Where(w => w.Contracts.Any()));

                var customerContracts = customers.ToList().Select(
                    s =>
                        new IntegrationClientDto(s.Id, s.Name, s.CustomerAccountNumber.ToString(), s.IsActive,
                            s.Contracts.Select(c => new IntegrationContractDto(c.Id, c.Name, c.Packages
                                .Select(p => new PackageDto() { Id = p.Id, PackageId = p.PackageId, Name = p.Name, IsActive = p.IsActive}))))).ToList();

                result.AddRange(customerContracts.Where(w => w.Contracts.Any()));

                return Response.AsJson(result);
            };
        }
    }
}