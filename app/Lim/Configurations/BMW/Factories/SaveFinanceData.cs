using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lim.Domain.Base;
using Lim.Domain.Extensions;
using Toolbox.Bmw.Dtos;
using Toolbox.Bmw.Entities.Factory;

namespace Toolbox.Bmw.Factories
{
    public class SaveFinanceData : AbstractPersistenceRepository<List<BmwFinanceDataDto>>
    {
        private static readonly ILog Log = LogManager.GetLogger<SaveFinanceData>();

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
                    Chassis = s.Chassis.RemoveWhiteSpace(),
                    Engine = s.Engine.RemoveWhiteSpace(),
                    DealStatus = s.DealStatus.Fix(),
                    Description = s.Description.Fix(),
                    RegistrationNumber = s.RegistrationNumber.RemoveWhiteSpace(),
                    RegistrationYear = s.RegistrationYear,
                    FinanceHouse = s.FinanceHouse.Fix(),
                    StartDate = s.StartDate,
                    DealReference = s.DealReference.Fix(),
                    ExpireDate = s.ExpireDate,
                    ClientNumber = s.ClientNumber.Fix()
                }.SetVinEngineId()).ToList();

                Log.InfoFormat("Inserting {0} records into the BMW Finance", financeEntities.Count);

                using (var session = BmwFactoryManager.BmwInstance.OpenStatelessSession())
                using (var transaction = session.BeginTransaction())
                {
                    session.CreateSQLQuery("delete from Finances").ExecuteUpdate();
                    session.SetBatchSize(1000);
                    foreach (var entity in financeEntities)
                    {
                        session.Insert(entity);
                    }

                    transaction.Commit();
                }

                return true;

            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Failed to save information in the LIM Bmw database, because {0}", ex, ex.Message);
            }

            return false;
        }
    }
}