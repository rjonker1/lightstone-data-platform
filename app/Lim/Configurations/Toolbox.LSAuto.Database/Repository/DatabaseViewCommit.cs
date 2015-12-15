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
    public class DatabaseViewCommit : AbstractPersistenceRepository<DatabaseViewDto>
    {
        private static readonly ILog Log = LogManager.GetLogger<DatabaseViewCommit>();

        public DatabaseViewCommit()
        {
            
        }

        public override bool Persist(DatabaseViewDto dto)
        {
            try
            {
                if (dto == null)
                    return false;

                var viewEntitiy = new DatabaseView
                {
                    Id = dto.Id,
                    AggregateId = dto.AggregateId,
                    Activated = dto.Activated,
                    Name = dto.Name,
                    Version = dto.Version,
                    DisplayName = dto.DisplayName
                };

                var dataFields = dto.ViewColumns.Select(s => new DatabaseViewColumn()
                {
                    Id = s.Id,
                    Name = s.Name,
                    DatabaseView = viewEntitiy,
                    DisplayName = s.DisplayName
                });

                using (var session = LightstoneAutoFactoryManager.Instance.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    var nameExists = session.Query<DatabaseView>().ToList().Where(w => w.Name == viewEntitiy.Name);
                    if (!nameExists.Any())
                    {
                        session.Save(viewEntitiy);
                        foreach (var field in dataFields)
                        {
                            session.Save(field);
                        }
                    }
                    else
                    {
                        session.Update(viewEntitiy);
                        foreach (var field in dataFields)
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