using System.Linq;
using NHibernate;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.Repositories
{
    public interface IIndividualRepository : IRepository<Individual>
    {
        Individual GetExistingIndividual(Individual individual);
    }

    public class IndividualRepository : Repository<Individual>, IIndividualRepository
    {
        public IndividualRepository(ISession session)
            : base(session)
        {
        }

        public Individual GetExistingIndividual(Individual individual)
        {
            return this.FirstOrDefault(
                x => (x.Name + "").Trim().ToLower() == (individual.Name + "").Trim().ToLower()
                && (x.Surname + "").Trim().ToLower() == (individual.Surname + "").Trim().ToLower()
                && (x.IdNumber + "").Trim().ToLower() == (individual.IdNumber + "").Trim().ToLower()
                );
        }
    }
}