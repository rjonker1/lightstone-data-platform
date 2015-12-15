using NHibernate;
using Toolbox.LSAuto.Entities.Factory;
using Xunit.Extensions;

namespace Lim.Test.Helper.Database
{
    public abstract class AbstracLsAutoInMemoryDatabase : Specification
    {
        private ISession _session;

        public void SetupDatabase()
        {
            _session = LightstoneAutoInMemoryFactoryManager.Instance.OpenSession();
        }
       
        public void TearDownDatabase()
        {
            if (_session != null)
                _session.Dispose();
        }
        protected ISession Session
        {
            get { return _session; }
        }
    }
}