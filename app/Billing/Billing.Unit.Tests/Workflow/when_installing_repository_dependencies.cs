using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing.TestHelper.BaseTests;
using DataPlatform.Shared.Repositories;
using Workflow.Billing.Domain.Entities;
using Workflow.Billing.Repository;
using Xunit.Extensions;

namespace Billing.Api.Tests.Workflow
{
    public class when_installing_repository_dependencies : BaseTestHelper
    {
        private IRepository<PreBilling> _testingDB;
        private PreBilling _newRecord;
        private PreBilling _cacheRecord;

        public override void Observe()
        {
            _testingDB = Container.Resolve<IRepository<PreBilling>>();
            _newRecord = new PreBilling {Id = Guid.NewGuid()};
            _cacheRecord = new PreBilling { Id = Guid.NewGuid() };
        }

        [Observation]
        public void should_resolve_IRepository_of_type_PreBilling()
        {
            Container.Resolve<IRepository<PreBilling>>().ShouldNotBeNull();
        }
        
        [Observation]
        public void should_resolve_IRepository_of_type_StageBilling()
        {
            Container.Resolve<IRepository<StageBilling>>().ShouldNotBeNull();
        }
        
        [Observation]
        public void should_resolve_IRepository_of_type_FinalBilling()
        {
            Container.Resolve<IRepository<FinalBilling>>().ShouldNotBeNull();
        }


        [Observation]
        public void should_have_saveupdate_capability()
        {
            _testingDB.SaveOrUpdate(_newRecord);
        }

        [Observation]
        public void should_have_saveupdate_with_cache_capability()
        {
            _testingDB.SaveOrUpdate(_cacheRecord, true);
        }

        [Observation]
        public void should_have_delete_capability()
        {
            _testingDB.Delete(_newRecord);
        }

        [Observation]
        public void should_have_delete_from_db_and_cache_functionality()
        {
            _testingDB.Delete(_cacheRecord, true);
        }
    }
}
