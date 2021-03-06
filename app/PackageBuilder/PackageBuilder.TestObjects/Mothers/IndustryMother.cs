﻿using PackageBuilder.Domain.Entities.Industries.Read;
using PackageBuilder.TestObjects.Builders;

namespace PackageBuilder.TestObjects.Mothers
{
    public class IndustryMother
    {
        public static Industry Automotive
        {
            get
            {
                return new IndustryBuilder().With("Automotive").Build();
            }
        }

        public static Industry Finance
        {
            get
            {
                return new IndustryBuilder().With("Finance").Build();
            }
        }

        public static Industry All
        {
            get
            {
                return new IndustryBuilder().With("All").Build();
            }
        }

        public static Industry Property
        {
            get
            {
                return new IndustryBuilder().With("Property").Build();
            }
        }
    }
}