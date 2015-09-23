using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;

namespace PackageBuilder.Domain.Entities.Requests
{
    public class CriticalDataProviders
    {
        public static ICauseCriticalFailure Find(DataProviderName name)
        {
            var critical = Critical.FirstOrDefault(w => w.Key == name);
            return critical.Value ?? CauseCriticalFailure.No();
        }


        private static readonly IDictionary<DataProviderName, ICauseCriticalFailure> Critical = new Dictionary
            <DataProviderName, ICauseCriticalFailure>()
        {
            {DataProviderName.IVIDVerify_E_WS, CauseCriticalFailure.Yes()},
            {DataProviderName.LSAutoCarStats_I_DB, CauseCriticalFailure.Yes()},
            {DataProviderName.LSAutoSpecs_I_DB, CauseCriticalFailure.Yes()}
        };
    }

    [DataContract]
    public class CauseCriticalFailure : ICauseCriticalFailure
    {
        private const string CriticalFailureMessage =
            "We have encountered a technical problem and are unable to create a report. Please try again later or contact Lightstone Support on 087 236 7740.";

        public static CauseCriticalFailure No()
        {
            return new CauseCriticalFailure(false,"");
        }

        public static CauseCriticalFailure Yes(string message = null)
        {
            return new CauseCriticalFailure(true, message ?? CriticalFailureMessage);
        }

        private CauseCriticalFailure(bool @true, string message)
        {
            Message = message ?? CriticalFailureMessage;
            True = @true;
        }

        [DataMember]
        public string Message { get; private set; }

        [DataMember]
        public bool True { get; private set; }
    }
}