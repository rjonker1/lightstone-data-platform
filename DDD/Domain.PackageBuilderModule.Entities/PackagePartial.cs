using System;
using System.Collections.Generic;
using LightstoneApp.Domain.PackageBuilderModule.Entities.Context.PackageBuilder;
using LightstoneApp.Domain.PackageBuilderModule.Entities.DTO;
using LightstoneApp.Domain.PackageBuilderModule.Entities.Events;
using Version = LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities
{
    public class Package : DTO.PackageBuilder.Package
    {
        private readonly IPackageBuilderContext _context;
        private readonly IEnumerable<PackageDataField> _packageDataFieldViaPackageCollection;

        public Package(IPackageBuilderContext context)
        {
            _context = context;

            _packageDataFieldViaPackageCollection = new List<PackageDataField>();
        }

        private Package SetupCompleted()
        {
            //DataProvider dataProvider;

            //var dataProviderFound = Version != null && !(string.IsNullOrEmpty(Name) &&
            //    _context.TryGetDataProviderByDataProviderNameAndVersionUniquenessConstraint(Name, Version, out dataProvider));

            //if (dataProviderFound)
            //{

            //}

            var packageCreatedEvent = new PackageCreatedEvent(this);

            RaiseEvent(packageCreatedEvent);

            return this;
        }

        public class Factory
        {
            private readonly IPackageBuilderContext _context;

            public Factory(IPackageBuilderContext context)
            {
                _context = context;
            }


            public Package CreatePackage(string name, string version)
            {
                Version checkVersion;

                var v = Infrastructure.CrossCutting.NetFramework.Version.TryParse(version, out checkVersion);

                if (checkVersion != null)
                {
                    var package = new Package(_context)
                    {
                        //Id = "people/" + Guid.NewGuid().ToString(),
                        //Id = IdentityGenerator.NewSequentialGuid(),
                        Name = name,
                        Version = checkVersion.ToString() 
                    };

                    package = package.SetupCompleted();

                    //package.Id = GuidUtil.NewSequentialId();

                    return package;
                }
                return null;
            }

            public Package CreatePackage(Package newPackage)
            {
                var package = newPackage.SetupCompleted();
                return package;
            }
        }

        public override PackageBuilderContext Context
        {
            get { return _context as PackageBuilderContext; }
        }

        public override sealed string Name { get; set; }
        public override string Description { get; set; }
        public override string Owner { get; set; }
        public override DateTime? Created { get; set; }
        public override DateTime? Edited { get; set; }
        public override sealed string Version { get; set; }


        public override object Clone()
        {
            var version = new Version(Version);

            var revisionNr = version.Revision + 1;

            var newVersion = new Version(version.Major, version.Minor, version.Publish, revisionNr).ToString();

            var clone = MemberwiseClone() as Package;

            if (clone != null)
            {
                var package = base.Clone() as Package;

                if (package != null)
                {
                    package.Version = newVersion;

                    var pce = new PackageClonedEvent(package);

                    return pce.PackageCreated;
                }
            }

            return null;
        }

        public override bool? Published { get; set; }
        public override DateTime? RevisionDate { get; set; }
        public override decimal? CostOfSale { get; set; }
        public override decimal? RecomendedRetailPrice { get; set; }
        public override DTO.State State { get; set; }
        public override DTO.Industry Industry { get; set; }

        public override IEnumerable<PackageDataField> PackageDataFieldViaPackageCollection
        {
            get { return _packageDataFieldViaPackageCollection; }
        }
    }
}