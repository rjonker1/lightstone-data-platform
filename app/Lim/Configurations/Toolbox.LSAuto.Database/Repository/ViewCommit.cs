using System;
using System.Linq;
using Common.Logging;
using Lim.Domain.Base;
using Lim.Dtos;
using Toolbox.LSAuto.Entities;
using Toolbox.LSAuto.Entities.Factory;

namespace Toolbox.LightstoneAuto.Repository
{
    public class ViewCommit : AbstractPersistenceRepository<ViewDto>
    {
        private static readonly ILog Log = LogManager.GetLogger<ViewCommit>();

        public override bool Persist(ViewDto dto)
        {
            try
            {
                if (dto == null)
                    return false;

                var viewEntitiy = new View
                {
                    Id = dto.Id,
                    AggregateId = dto.AggregateId,
                    Activated = dto.Activated,
                    Name = dto.Name,
                    Version = dto.Version,
                    DisplayName = dto.DisplayName
                };

                var dataFields = dto.ViewColumns.Select(s => new ViewColumn()
                {
                    Id = s.Id,
                    Name = s.Name,
                    View = viewEntitiy,
                    DisplayName = s.DisplayName
                });

                using (var session = LsAutoFactoryManager.Instance.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(viewEntitiy);
                    foreach (var field in dataFields)
                    {
                        session.SaveOrUpdate(field);
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