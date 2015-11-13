using System;
using DataPlatform.Shared.Enums;

namespace Lace.Test.Helper.Mothers.Packages
{
    public class PropertyPackage
    {
        private readonly DataProviderName[] _dataProviders;
        private readonly Guid _packageId;

        public PropertyPackage(DataProviderName[] dataProviders, Guid packageId)
        {
            _dataProviders = dataProviders;
            _packageId = packageId;
        }

        public Guid Id
        {
            get
            {
                return _packageId;
            }
        }

        public long Version
        {
            get { return 1; }
        }

        public DataProviderName[] DataProviders
        {
            get { return _dataProviders; }
        }

        public string Name
        {
            get { return "PropertySearch"; }
        }

        public string Action
        {
            get { return "Property Search"; }
        }
    }
}
