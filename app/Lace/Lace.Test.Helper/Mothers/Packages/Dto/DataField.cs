using System;
using DataPlatform.Shared.Entities;

namespace Lace.Test.Helper.Mothers.Packages.Dto
{
    public class DataField : IDataProvider
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Type ResponseType { get; set; }

    
    }
}
