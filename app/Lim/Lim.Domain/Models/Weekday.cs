using System;
using System.Collections.Generic;
using System.Linq;
using Lim.Enums;

namespace Lim.Domain.Models
{
    public class Weekday
    {
        //public const string Select = @"select Id, Day from Weekdays";

        public Weekday(int id, string day)
        {
            Id = id;
            Day = day;
        }

        public static List<Weekday> Weekdays()
        {
            return Enum.GetValues(typeof (Weekdays)).Cast<Weekdays>().Select(s => new Weekday((int) s, s.ToString())).ToList();
        }

        public int Id { get; private set; }
        public string Day { get; private set; }
    }
}
