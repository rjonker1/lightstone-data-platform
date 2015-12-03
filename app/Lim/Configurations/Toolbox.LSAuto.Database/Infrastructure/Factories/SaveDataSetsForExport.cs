using System;
using System.Linq;
using Common.Logging;
using Lim.Domain.Base;
using Lim.Dtos;
using Toolbox.LSAuto.Entities;
using Toolbox.LSAuto.Entities.Factory;

namespace Toolbox.LightstoneAuto.Database.Infrastructure.Factories
{
    public class SaveDataSetsForExport : AbstractPersistenceRepository<DataSetDto>
    {
        private static readonly ILog Log = LogManager.GetLogger<SaveDataSetsForExport>();

        public SaveDataSetsForExport()
        {
        }

        public override bool Persist(DataSetDto dto)
        {
            try
            {
                if (dto == null)
                    return false;

                var dataSetEntity = new DataSet
                {
                    Id = dto.Id,
                    Activated = dto.Activated,
                    Name = dto.Name,
                    Version = dto.Version,
                    DateCreated = DateTime.UtcNow,
                    Description = dto.Description
                };

                var dataFields = dto.DataFields.Select(s => new DataField
                {
                    DateCreated = DateTime.UtcNow,
                    Name = s.Name,
                    Id = s.Id,
                    Activated = s.Activated,
                    DataSet = dataSetEntity,
                    DisplayName = s.DisplayName,
                    Selected = s.Selected
                });

                using (var session = LsAutoFactoryManager.LsAutoInstance.OpenStatelessSession())
                using (var transaction = session.BeginTransaction())
                {
                    foreach (var field in dataFields)
                    {
                        session.Insert(field);
                    }
                    session.Insert(dataSetEntity);
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
