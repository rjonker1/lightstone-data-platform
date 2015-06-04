﻿using System;
using System.Linq;
using System.Linq.Expressions;
using Lim.Domain.Entities.Repository;
using Lim.Test.Helper.Mothers;

namespace Lim.Test.Helper.Fakes.Repository
{
    public class FakeLimPackageResponseRepository : IAmRepository
    {
        public T Get<T>(object id)
        {
            throw new NotImplementedException();
        }

        public T Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Get<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class
        {
            return (IQueryable<T>)LimDatabase.PackageResponseses().AsQueryable();
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return (IQueryable<T>)LimDatabase.PackageResponseses().AsQueryable();
        }

        public void Save<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void SaveOrUpdate<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Merge<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Flush()
        {
            throw new NotImplementedException();
        }
    }
}
