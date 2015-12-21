using System;
using System.Linq;
using Common.Logging;
using Lim.Domain.Base;
using Lim.Dtos;
using NHibernate.Linq;
using Toolbox.LSAuto.Entities;
using Toolbox.LSAuto.Entities.Factory;

namespace Toolbox.LightstoneAuto.Repository
{
    public class DatabaseExtractCommit : AbstractPersistenceRepository<DatabaseExtractDto>
    {
        private static readonly ILog Log = LogManager.GetLogger<DatabaseExtractCommit>();
        public DatabaseExtractCommit()
        {
        }

        public override bool Persist(DatabaseExtractDto dto)
        {
            try
            {
                if (dto == null)
                    return false;

                var entity = new DatabaseExtract
                {
                    Id = dto.Id,
                    AggregateId = dto.AggregateId,
                    Activated = dto.Activated,
                    Name = dto.Name,
                    Version = dto.Version,
                    Description = dto.Description
                    //CreatedBy = dto.CreatedBy,
                    //ModifiedBy = dto.ModifiedBy
                };

                var fields = dto.Fields.Select(s => new DatabaseExtractField
                {
                    Id = s.Id,
                    Name = s.Name,
                    DatabaseExtract = entity,
                    DisplayName = s.DisplayName,
                    Selected = s.Selected
                });

                using (var session = LightstoneAutoFactoryManager.Instance.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    var exists = session.Query<DatabaseView>().ToList().Where(w => w.Id == entity.Id);
                    if (!exists.Any())
                    {
                        session.Save(entity);
                        foreach (var field in fields)
                        {
                            session.Save(field);
                        }
                    }
                    else
                    {
                        session.Update(entity);
                        foreach (var field in fields)
                        {
                            session.Update(field);
                        }
                    }

                    transaction.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Failed to save information in the LIM LS AUTO database, because {0}", ex, ex.Message);
            }

            return false;
        }
    }
}
