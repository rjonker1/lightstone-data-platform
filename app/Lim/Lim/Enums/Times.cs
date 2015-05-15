using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lim.Enums
{
    public enum Month
    {
        JAN = 0,
        FEB = 1,
        MAR = 2,
        APR = 3,
        MAY = 4,
        JUN = 5,
        JUL = 6,
        AUG = 7,
        SEP = 8,
        OCT = 9,
        NOV = 10,
        DEC = 11,
    }

    public enum WeekDay
    {
        SUN = 1,
        MON = 2,
        TUE = 3,
        WED = 4,
        THU = 5,
        FRI = 6,
        SAT = 7
    }

    public enum Frequency
    {
        EveryMinute = 1,
        Hourly =2,
        Daily = 3,
        Custom = 4
    }
}
