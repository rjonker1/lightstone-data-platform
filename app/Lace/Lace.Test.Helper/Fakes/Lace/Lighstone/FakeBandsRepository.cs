﻿using System.Linq;
using Lace.Shared.DataProvider.Repositories;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeBandsRepository : IReadOnlyRepository
    {
        public IQueryable<TItem> GetAll<TItem>(string sql) where TItem : class
        {
            return (IQueryable<TItem>)Builders.Sources.Lightstone.BandsDataBuilder.ForAllBands().AsQueryable();
        }

        public IQueryable<TItem> Get<TItem>(string sql, object param) where TItem : class
        {
            return (IQueryable<TItem>)Builders.Sources.Lightstone.BandsDataBuilder.ForAllBands().AsQueryable();
        }


        public IQueryable<TItem> GetAll<TItem>(string sql, System.Func<TItem, bool> predicate) where TItem : class
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<TItem> Get<TItem>(string sql, object param, System.Func<TItem, bool> predicate) where TItem : class
        {
            throw new System.NotImplementedException();
        }
    }
}
