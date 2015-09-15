﻿using Lim.Core;
using Toolbox.Bmw.Entities.Factory;

namespace Toolbox.Bmw.Entities.Repository
{
    public class BmwRepository : IWriteOnlyRepository
    {
        public void Save<T>(T entity) where T : class
        {
            using (var session = BmwFactoryManager.BmwInstance.OpenSession())
                session.Save(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            using (var session = BmwFactoryManager.BmwInstance.OpenSession())
                session.Update(entity);
        }

        public void SaveOrUpdate<T>(T entity) where T : class
        {
            using (var session = BmwFactoryManager.BmwInstance.OpenSession())
                session.SaveOrUpdate(entity);
        }

        public void Merge<T>(T entity) where T : class
        {
            using (var session = BmwFactoryManager.BmwInstance.OpenSession())
            {
                session.Merge(entity);
                session.Flush();
            }
        }
    }
}