using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Lim.Core;
using NHibernate;
using NHibernate.Linq;
using Toolbox.LSAuto.Entities.Factory;

namespace Toolbox.LightstoneAuto.Repository
{
    //public interface ILsAutoRepository : IRepository
    //{
    //    void MergeWthSession<T>(T entity, ISession session) where T : class;
    //}

    //public class LsAutoRepository : ILsAutoRepository
    //{
    //    public T Get<T>(object id)
    //    {
    //        using (var session = LsAutoFactoryManager.Instance.OpenSession())
    //            return session.Get<T>(id);
    //    }

    //    public T Find<T>(Expression<Func<T, bool>> predicate) where T : class
    //    {
    //        using (var session = LsAutoFactoryManager.Instance.OpenSession())
    //            return session.Query<T>().CacheMode(CacheMode.Refresh).Where(predicate).FirstOrDefault();
    //    }

    //    public IEnumerable<T> Get<T>(Expression<Func<T, bool>> predicate) where T : class
    //    {
    //        using (var session = LsAutoFactoryManager.Instance.OpenSession())
    //            return session.Query<T>().CacheMode(CacheMode.Refresh).Where(predicate).ToList();
    //    }

    //    public void Save<T>(T entity) where T : class
    //    {
    //        using (var session = LsAutoFactoryManager.Instance.OpenSession())
    //            session.Save(entity);
    //    }

    //    public void Update<T>(T entity) where T : class
    //    {
    //        using (var session = LsAutoFactoryManager.Instance.OpenSession())
    //            session.Update(entity);
    //    }

    //    public void SaveOrUpdate<T>(T entity) where T : class
    //    {
    //        using (var session = LsAutoFactoryManager.Instance.OpenSession())
    //            session.SaveOrUpdate(entity);
    //    }

    //    public IEnumerable<T> GetAll<T>() where T : class
    //    {
    //        using (var session = LsAutoFactoryManager.Instance.OpenSession())
    //            return session.Query<T>().ToList();
    //    }
    //    public void Merge<T>(T entity) where T : class
    //    {
    //        using (var session = LsAutoFactoryManager.Instance.OpenSession())
    //        {
    //            session.Merge(entity);
    //            session.Flush();
    //        }
    //    }

    //    public void MergeWthSession<T>(T entity, ISession session) where T : class
    //    {
    //        session.Merge(entity);
    //    }

    //    private void CheckConnection()
    //    {
    //        using (var session = LsAutoFactoryManager.Instance.OpenSession())
    //            session.Connection.Open();
    //    }


    //    public void Delete<T>(T entity) where T : class
    //    {
    //        using (var session = LsAutoFactoryManager.Instance.OpenSession())
    //            session.Delete(entity);
    //    }

        
    //}
}
