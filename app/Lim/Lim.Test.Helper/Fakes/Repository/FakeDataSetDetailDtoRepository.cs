using System;
using System.Collections.Generic;
using System.Linq;
using Lim.Core;
using Toolbox.LSAuto.Entities;

namespace Lim.Test.Helper.Fakes.Repository
{
    public class FakeDatabase
    {
       // public static Dictionary<Guid, DataSetDetailsDto> Details = new Dictionary<Guid, DataSetDetailsDto>();
        public static List<DataSet> DataSetList = new List<DataSet>();
        public static List<DataField> DataFieldList = new List<DataField>(); 
    }

    public class FakeDataSetRepository : IWriteOnlyRepository
    {
        public void Save<T>(T entity) where T : class
        {
            var ds = entity as DataSet;

            if(ds == null)
                return;
            FakeDatabase.DataSetList.Add(ds);
           
        }

        public void SaveOrUpdate<T>(T entity) where T : class
        {
            var ds = entity as DataSet;
            if (ds == null)
                return;
            var dsToUpdate = FakeDatabase.DataSetList.FirstOrDefault(w => w.AggregateId == ds.AggregateId);
            dsToUpdate = ds;

            FakeDatabase.DataSetList.RemoveAll(w => w.AggregateId == ds.AggregateId);
            FakeDatabase.DataSetList.Add(ds);

        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Merge<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            var ds = entity as DataSet;
            FakeDatabase.DataSetList.RemoveAll(w => w.AggregateId == ds.AggregateId);
        }
    }
}
