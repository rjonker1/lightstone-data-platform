using System;
using System.Collections;
using UserManagement.Domain.Entities;

namespace UserManagement.TestHelper.Helpers
{
    public class CustomEqualityComparer : IEqualityComparer
    {
        public bool Equals(object x, object y)
        {
            if (x == null || y == null)
                return false;
            if (x is Entity && y is Entity)
                return ((Entity)x).Id == ((Entity)y).Id;
            if (x is IntEntity && y is IntEntity)
                return ((IntEntity)x).Id == ((IntEntity)y).Id;
            return x.Equals(y);
        }

        public int GetHashCode(object obj)
        {
            throw new NotImplementedException();
        }
    }
}