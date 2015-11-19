using System;

namespace UserManagement.Domain.Entities
{
    public class ClientIndustry : Entity
    {
        public virtual Client Client { get; protected internal set; }
        public virtual Guid IndustryId { get; protected internal set; }
        protected ClientIndustry()
        {
        }

        public ClientIndustry(Client client, Guid industryId)
        {
            Id = Guid.NewGuid();
            Client = client;
            IndustryId = industryId;
        }
    }
}