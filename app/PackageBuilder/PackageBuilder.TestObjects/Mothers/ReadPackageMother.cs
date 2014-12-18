using System;
using PackageBuilder.Domain.Entities.Packages.ReadModels;
using PackageBuilder.Domain.Entities.States.WriteModels;
using PackageBuilder.TestObjects.Builders;

namespace PackageBuilder.TestObjects.Mothers
{
    public class ReadPackageMother
    {
        private readonly Guid _id;
        private readonly State _state;

        public ReadPackageMother(Guid? id, State state)
        {
            _id = id ?? Guid.NewGuid();
            _state = state;
        }

        public ReadPackageMother(State state)
        {
            _state = state;
        }

        public Package VVi
        {
            get
            {
                return new ReadPackageBuilder()
                    .With(_id)
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
                    .With(_id)
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
                    .With(_id)
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