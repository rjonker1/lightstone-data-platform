using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lace.Source.Helpers
{
    public static class ConvertFunctions
    {
        public static T ConvertObject<T>(Object input)
        {
            return (T)Convert.ChangeType(input, typeof(T));
        }
    }
}
