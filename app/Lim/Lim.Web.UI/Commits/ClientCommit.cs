using System;
using Common.Logging;
using Lim.Core;
using Lim.Domain.Base;
using Lim.Domain.Entities;
using Lim.Dtos;

namespace Lim.Web.UI.Commits
{
    public class ClientCommit : AbstractPersistenceRepository<ClientDto>
    {
        private readonly IRepository _repository;
        private readonly ILog _log;

        public ClientCommit(IRepository repository)
        {
            _repository = repository;
            _log = LogManager.GetLogger(GetType());
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
                _log.ErrorFormat("Failed to save a Client in the LIM database, because {0}", ex, ex.Message);
            }
            return false;
        }
    }
}