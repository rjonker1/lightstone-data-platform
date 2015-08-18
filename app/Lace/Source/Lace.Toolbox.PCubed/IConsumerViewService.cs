using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lace.Toolbox.PCubed.Domain;
using RestSharp;

namespace Lace.Toolbox.PCubed
{
    public interface IConsumerViewService
    {
        void AddConfiguration(IConfiguration config);
        IRestResponse<ConsumerViewResponse> Search(ConsumerViewQuery query);
        IRestResponse SearchAsString(ConsumerViewQuery query, ConsumerViewQuery.ResponseFormat format);
    }
}
