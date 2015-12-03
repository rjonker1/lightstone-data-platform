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
            var message = entity as DataSet;
            var ds = FakeDatabase.DataSetList.FirstOrDefault(w => w.Id == message.Id);
            ds = message;

            FakeDatabase.DataSetList.RemoveAll(w => w.Id == message.Id);
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
            FakeDatabase.DataSetList.RemoveAll(w => w.Id == ds.Id);
        }
    }

    //public class FakeDataSetDetailDtoRepository : IWriteOnlyRepository
    //{
    //    public void Save<T>(T entity) where T : class
    //    {
    //        var val = entity as DataSetExportCreated;
    //        FakeDatabase.Details.Add(val.Id, new DataSetDetailsDto(val.Id, val.Name, 0, 0));
    //    }

    //    public void SaveOrUpdate<T>(T entity) where T : class
    //    {
    //        var message = entity as DataSetRenamed;
    //        var dto = FakeDatabase.Details[message.Id];
    //        dto.Name = message.NewName;

    //        FakeDatabase.Details.Remove(message.Id);
    //        FakeDatabase.Details.Add(message.Id, dto);
    //    }

    //    public void Update<T>(T entity) where T : class
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Merge<T>(T entity) where T : class
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Delete<T>(T entity) where T : class
    //    {
    //        var message = entity as DataSetDeActivated;
    //        FakeDatabase.Details.Remove(message.Id);
    //    }
    //}

    
}
