using System;
using System.Collections.Generic;
using System.Linq;
using Monitoring.Domain.Core.Contracts;

namespace Monitoring.Test.Helper.Fakes
{
    public class FakeMonitoringReadStoreage: IAccessToStorage
    {
        public readonly IList<object> Database = new List<object>();

        public void Add<TItem>(TItem item) where TItem : class
        {
            Database.Add(item);
        }

        public void Remove<TItem>(TItem item) where TItem : class
        {
            throw new NotImplementedException();
        }

        public void Update<TItem>(TItem item) where TItem : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<TItem> Items<TItem>() where TItem : class
        {
           throw new NotImplementedException();
        }

        public IQueryable<TItem> Items<TItem>(string sql) where TItem : class
        {
            throw new NotImplementedException();
        }
    }
}
