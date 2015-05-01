using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Lace.Domain.Core.Requests.Contracts;

namespace Workflow.Lace.Identifiers
{
    [DataContract]
    public class SearchRequestIndentifier
    {
        public SearchRequestIndentifier()
        {
        }

        private SearchRequestIndentifier(int dataProvider, string package, long packageVersion)
        {
            NumberOfDataProviders = dataProvider;
            PackageName = package;
            PackageVersion = packageVersion;
        }

        public static SearchRequestIndentifier Determine(ICollection<IPointToLaceRequest> request)
        {
            return new SearchRequestIndentifier(request.First().Package.DataProviders.Count(), request.First().Package.Name,
                request.First().Package.Version);
        }


        [DataMember]
        public int NumberOfDataProviders { get; private set; }

        [DataMember]
        public string PackageName { get; private set; }

        [DataMember]
        public long PackageVersion { get; private set; }
    }
}
