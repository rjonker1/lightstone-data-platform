﻿using System.Collections.Generic;
using Lace.Toolbox.Database.Repositories;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    //
    public class FakeMakeRepository : IReadOnlyRepository
    {
        public IEnumerable<TItem> GetAll<TItem>(System.Func<TItem, bool> predicate) where TItem : class
        {
            return (IEnumerable<TItem>)Builders.Sources.Lightstone.MakeDataBuilder.ForAllMakes();
        }

        public IEnumerable<TItem> Get<TItem>(string sql, object param) where TItem : class
        {
            return (IEnumerable<TItem>)Builders.Sources.Lightstone.MakeDataBuilder.ForAllMakes();
        }
    }
}
