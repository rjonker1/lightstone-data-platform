using System;
using Common.Logging;
using Lim.Domain.Dto;
using Lim.Domain.Entities;
using Lim.Domain.Entities.Contracts;
using Lim.Domain.Entities.Repository;

namespace Lim.Web.UI.Commits
{
    public class ClientCommit : IPersistObject<ClientDto>
    {
        private readonly IAmRepository _repository;
        private readonly ILog _log;

        public ClientCommit(IAmRepository repository)
        {
            _repository = repository;
            _log = LogManager.GetLogger(GetType());
        }

        public bool Persist(ClientDto clientDto)
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
                _repository.Flush();
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