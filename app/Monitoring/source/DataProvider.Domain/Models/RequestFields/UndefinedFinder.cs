using System.Collections.Generic;
using System.Linq;
using DataProvider.Domain.Enums;
using Newtonsoft.Json.Linq;

namespace DataProvider.Domain.Models.RequestFields
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