using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lace.Models.Enums
{
    public enum ServiceCallState
    {
        NotStarted = 0,
        CallStarted = 1,
        CallCompleted = 2,
        CallCompletedWithErrors = 3,
        CallFailed = 4,
    }
}
