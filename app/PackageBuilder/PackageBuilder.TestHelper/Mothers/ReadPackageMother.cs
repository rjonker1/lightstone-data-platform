using System;
using PackageBuilder.Domain.Entities.Packages.ReadModels;
using PackageBuilder.Domain.Entities.States.WriteModels;
using PackageBuilder.TestHelper.Builders.Entites;

namespace PackageBuilder.TestHelper.Mothers
{
    public class ReadPackageMother
    {
        private readonly State _state;

        public ReadPackageMother(State state)
        {
            _state = state;
        }

        public Package VVi
        {
            get
            {
                return new ReadPackageBuilder()
                    .With(Guid.NewGuid())
                    .With("VVi")
                    .With(DateTime.Now)
                    .With(_state)
                    .With(1)
                    .With(0.1m)
                    .Build();
            }
        }

        public Package VLi
        {
            get
            {
                return new ReadPackageBuilder()
                    .With(Guid.NewGuid())
                    .With("VLi")
                    .With(DateTime.Now)
                    .With(_state)
                    .With(1)
                    .With(0.1m)
                    .Build();
            }
        }

        public Package VPi
        {
            get
            {
                return new ReadPackageBuilder()
                    .With(Guid.NewGuid())
                    .With("VPi")
                    .With(DateTime.Now)
                    .With(_state)
                    .With(1)
                    .With(0.1m)
                    .Build();
            }
        }
    }
}