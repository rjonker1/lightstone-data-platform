using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UserManagement.Domain.Dtos
{
    [DataContract]
    public class PagedCollectionDto<T>
    {
        [DataMember]
        public IEnumerable<T> Data { get; set; }
        [DataMember]
        public int PageIndex { get; set; }
        [DataMember]
        public int PageSize { get; set; }
        [DataMember]
        public int PageTotal { get; set; }
        [DataMember]
        public int RecordsTotal { get; set; }
        [DataMember]
        public int RecordsFiltered { get; set; }
        [DataMember]
        public bool HasPreviousPage { get; set; }
        [DataMember]
        public bool HasNextPage { get; set; }
    }
}