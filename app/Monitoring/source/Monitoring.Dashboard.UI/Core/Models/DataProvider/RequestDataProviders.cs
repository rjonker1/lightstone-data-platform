using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Monitoring.Dashboard.UI.Core.Models.DataProvider
{
   [DataContract] public class DataProviders
    {
       public string Name { get; set; }
       List<RequestField> Request { get; set; }
    }
}