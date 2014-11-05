using System;
using NHibernate;

namespace PackageBuilder.TestHelper.Extensions
{
    public static class SessionExtensions
    {
        public static void EncloseInTransaction(this ISession session, Action<ISession> work)
        {
            var tx = session.BeginTransaction();
            try
            {
                work(session);
                tx.Commit();
                tx.Dispose();
            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw;
            }
        }
    }
}