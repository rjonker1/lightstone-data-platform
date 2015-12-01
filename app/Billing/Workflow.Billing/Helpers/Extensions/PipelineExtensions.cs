using DataPlatform.Shared.Messaging.Billing.Helpers;
using NHibernate;

namespace Workflow.Billing.Helpers.Extensions
{
    public class PipelineExtensions
    {
        public PipelineExtensions()
        {
        }

        public ISession BeforeTransaction(ISession session)
        {
            session.Flush();
            session.FlushMode = FlushMode.Always;

            //Entity IEntity = session.Load<Entity>(entity.Id);

            //if (IEntity.Id == entity.Id) session.Evict(session.Load<Entity>(entity.Id));

            session.BeginTransaction();
            return session;
        }

        public IStatelessSession BeforeTransaction(IStatelessSession statelessSession)
        {
            statelessSession.BeginTransaction();
            return statelessSession;
        }

        public void AfterTransaction(ISession session)
        {
            if (session == null)
                return;
            if (!session.Transaction.IsActive)
                return;

            session.Transaction.Commit();
        }

        public void AfterTransaction(IStatelessSession statelessSession)
        {
            if (statelessSession == null)
                return;
            if (!statelessSession.Transaction.IsActive)
                return;

            statelessSession.Transaction.Commit();
        }
    }
}