using System;
using System.Collections.Generic;
using Lim.Core;
using Toolbox.LightstoneAuto.Database.Infrastructure.Dto;

namespace Lim.Test.Helper.Fakes.Repository
{
    public class FakeDatabase
    {
        public static Dictionary<Guid, DataSetDetailsDto> Details = new Dictionary<Guid, DataSetDetailsDto>();
        public static List<DataSetDto> List = new List<DataSetDto>();
    }

    public class FakeDataSetDetailDtoRepository : IWriteOnlyRepository
    {
        public void Save<T>(T entity) where T : class
        {
            var val = entity as DataSetDetailsDto;
            FakeDatabase.Details.Add(val.Id, new DataSetDetailsDto(val.Id, val.Name, 0, 0));
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

        public void Delete<T>(T entity) where T : class
        {
            var message = entity as DataSetDetailsDto;
            FakeDatabase.Details.Remove(message.Id);
        }
    }

    public class FakeDataSetDtoRepository : IWriteOnlyRepository
    {
        public void Save<T>(T entity) where T : class
        {
            var message = entity as DataSetDetailsDto;
            FakeDatabase.List.Add(new DataSetDto(message.Id, message.Name));
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

        public void Delete<T>(T entity) where T : class
        {
            var message = entity as DataSetDetailsDto;
            FakeDatabase.List.RemoveAll(w => w.Id == message.Id);
        }
    }
}
