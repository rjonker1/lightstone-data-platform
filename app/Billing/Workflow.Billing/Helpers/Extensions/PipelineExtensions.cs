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
            session.BeginTransaction();
            return session;
        }

        public void AfterTransaction(ISession session)
        {
            if (session == null)
                return;
            if (!session.Transaction.IsActive)
                return;

            session.Transaction.Commit();
        }
    }
}