using System;
using Common.Logging;
using Lim.Domain.Dto;
using Lim.Domain.Entities;
using Lim.Domain.Entities.Contracts;
using NHibernate;

namespace Lim.Web.UI.Commits
{
    public class ClientCommit : IPersistObject<ClientDto>
    {
        private readonly ISessionFactory _session;
        private readonly ILog _log;

        public ClientCommit(ISessionFactory session)
        {
            _session = session;
            _log = LogManager.GetLogger(GetType());
        }

        public bool Persist(ClientDto clientDto)
        {
            try
            {
                using (var session = _session.OpenSession())
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
                    session.SaveOrUpdate(client);
                    return client.Id > 0;
                }
               
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Failed to save a Client in the LIM database, because {0}", ex, ex.Message);
            }
            return false;
        }
    }
}