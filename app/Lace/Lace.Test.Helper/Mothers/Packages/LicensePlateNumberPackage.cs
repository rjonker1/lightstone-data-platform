﻿using System;
using Lace.Domain.Core.Requests.Contracts;
using PackageBuilder.Domain.Entities.Enums.DataProviders;

namespace Lace.Test.Helper.Mothers.Packages
{
    public class LicensePlateNumberPackage : IHavePackageForRequest
    {
        private readonly DataProviderName[] _dataProviders;
        private readonly Guid _packageId;

        public LicensePlateNumberPackage(DataProviderName[] dataProviders, Guid packageId)
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
            get { return "LicensePlatePackage"; }
        }

        public string Action
        {
            get { return "License plate search"; }
        }
    }
}
