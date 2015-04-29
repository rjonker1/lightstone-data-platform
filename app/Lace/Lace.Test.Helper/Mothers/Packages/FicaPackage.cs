using System;
using DataPlatform.Shared.Enums;

namespace Lace.Test.Helper.Mothers.Packages
{
    public class FicaPackage
    {
        private readonly DataProviderName[] _dataProviders;
        private readonly Guid _packageId;

        public FicaPackage(DataProviderName[] dataProviders, Guid packageId)
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
            get { return "FicaPackage"; }
        }

        public string Action
        {
            get { return "Fica"; }
        }
    }
}
