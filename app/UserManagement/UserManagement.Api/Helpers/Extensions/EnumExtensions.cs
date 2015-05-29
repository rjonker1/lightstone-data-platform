using System;
using System.Collections.Generic;
using System.Linq;
using UserManagement.Api.Helpers.NancyRazorHelpers;

namespace UserManagement.Api.Helpers.Extensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectList<TEnum>(this TEnum enumObj)
           where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return from TEnum e in Enum.GetValues(typeof(TEnum))
                   select new SelectListItem(e + "", e + "");
        }
    }
}