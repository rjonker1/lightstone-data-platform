using System;
using System.Collections.Generic;
using PackageBuilder.Domain.Entities.DataFields.Write;

namespace PackageBuilder.Domain.Helpers
{
    public class DataFieldEqualityComparer : IEqualityComparer<DataField>
    {
        public bool Equals(DataField x, DataField y)
        {
            if (x == null || y == null)
                return false;

            return x.Namespace == y.Namespace;
        }

        public int GetHashCode(DataField obj)
        {
            throw new NotImplementedException();
        }
    }
}