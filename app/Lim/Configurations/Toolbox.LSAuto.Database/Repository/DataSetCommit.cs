using System;
using System.Linq;
using Common.Logging;
using Lim.Domain.Base;
using Lim.Dtos;
using NHibernate;
using Toolbox.LSAuto.Entities;
using Toolbox.LSAuto.Entities.Factory;

namespace Toolbox.LightstoneAuto.Repository
{
    public class DataSetCommit : AbstractPersistenceRepository<DataSetDto>
    {
        private static readonly ILog Log = LogManager.GetLogger<DataSetCommit>();
        public DataSetCommit()
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
                    AggregateId = dto.AggregateId,
                    Activated = dto.Activated,
                    Name = dto.Name,
                    Version = dto.Version,
                    Description = dto.Description
                    //CreatedBy = dto.CreatedBy,
                    //ModifiedBy = dto.ModifiedBy
                };

                var dataFields = dto.DataFields.Select(s => new DataField
                {
                    Id = s.Id,
                    Name = s.Name,
                    Activated = s.Activated,
                    DataSet = dataSetEntity,
                    DisplayName = s.DisplayName,
                    Selected = s.Selected
                });

                using (var session = LsAutoFactoryManager.Instance.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                   
                    session.SaveOrUpdate(dataSetEntity);
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
