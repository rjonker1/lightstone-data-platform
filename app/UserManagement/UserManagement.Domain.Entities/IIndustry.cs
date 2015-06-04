using System.Collections.Generic;

namespace UserManagement.Domain.Entities
{
    public interface IIndustry
    {
        ISet<ClientIndustry> Industries { get; }
        //Guid[] Industries { get; }
    }
}