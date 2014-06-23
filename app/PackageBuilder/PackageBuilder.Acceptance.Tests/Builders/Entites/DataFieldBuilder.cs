using DataPlatform.Shared.Entities;
using PackageBuilder.Domain;

namespace PackageBuilder.Acceptance.Tests.Builders.Entites
{
    public class DataFieldBuilder
    {
        public static IDataField Get(string name)
        {
            return new DataField(name) { Type = typeof(string).ToString() };
        }
    }
}