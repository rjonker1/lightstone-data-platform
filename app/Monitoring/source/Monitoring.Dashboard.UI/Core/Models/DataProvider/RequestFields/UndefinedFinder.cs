using System.Collections.Generic;
using System.Linq;
using Monitoring.Dashboard.UI.Core.Enums;
using Newtonsoft.Json.Linq;

namespace Monitoring.Dashboard.UI.Core.Models.DataProvider.RequestFields
{
    public class UndefinedFinder : IFindRequestField
    {
        public void DetermineRequestField(JObject obj, List<RequestFieldType> requestFields)
        {
            if(!requestFields.Any())
                requestFields.Add(RequestFieldType.Undefined);
        }
    }
}