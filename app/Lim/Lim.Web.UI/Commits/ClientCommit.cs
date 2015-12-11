using System;
using Common.Logging;
using Lim.Core;
using Lim.Domain.Base;
using Lim.Domain.Entities;
using Lim.Dtos;
using Lim.Entities;

namespace Lim.Web.UI.Commits
{
    public class ClientCommit : AbstractPersistenceRepository<ClientDto>
    {
        private readonly IRepository _repository;
        private static readonly ILog Log = LogManager.GetLogger<ClientCommit>();

        public ClientCommit(IRepository repository)
        {
            _repository = repository;
        }

        public override bool Persist(ClientDto clientDto)
        {
            try
            {
                var client = new Client()
                {
                    Id = clientDto.Id,
                    IsActive = clientDto.IsActive,
                    Name = clientDto.Name,
                    Email = clientDto.Email,
                    ContactPerson = clientDto.ContactPerson,
                    ContactNumber = clientDto.ContactNumber,
                    CreatedBy = clientDto.CreatedBy ?? Environment.MachineName,
                    DateModified = DateTime.UtcNow,
                    ModifiedBy = clientDto.ModifiedBy ?? Environment.MachineName
                };
                _repository.Merge(client);
                return true;
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Failed to save a Client in the LIM database, because {0}", ex, ex.Message);
            }
            return false;
        }
    }
}