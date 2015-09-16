using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lim.Domain.Base;
using Toolbox.Bmw.Dtos;
using Toolbox.Bmw.Entities.Factory;

namespace Toolbox.Bmw.Finance
{
    public class SaveFinanceData : AbstractPersistenceRepository<List<BmwFinanceDataDto>>
    {
        private readonly ILog _log = LogManager.GetLogger<SaveFinanceData>();

        public SaveFinanceData()
        {
        }

        public override bool Persist(List<BmwFinanceDataDto> financedata)
        {
            try
            {
                if (!financedata.Any())
                    return false;

                var financeEntities = financedata.Select(s => new Entities.Finance()
                {
                    Chassis = s.Chassis,
                    Engine = s.Engine,
                    DealStatus = s.DealStatus,
                    DealType = s.DealType,
                    Description = s.Description,
                    RegistrationNumber = s.RegistrationNumber,
                    RegistrationYear = s.RegistrationYear
                });

                using (var session = BmwFactoryManager.BmwInstance.OpenSession())
                using (var transaction = session.BeginTransaction())
                {

                    session.Delete("delete from Finances");

                    foreach (var entity in financeEntities)
                    {
                        session.Save(entity);
                    }

                    transaction.Commit();
                    session.Flush();
                }

                return true;

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Failed to save information in the LIM Bmw database, because {0}", ex, ex.Message);
            }

            return false;
        }
    }
}