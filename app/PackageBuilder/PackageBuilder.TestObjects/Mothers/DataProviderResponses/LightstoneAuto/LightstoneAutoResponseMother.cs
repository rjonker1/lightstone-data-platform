﻿using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneAuto;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses.LightstoneAuto
{
    public class LightstoneAutoResponseMother
    {
        public static IProvideDataFromLightstoneAuto Response
        {
            get
            {
                return new LightstoneAutoResponseBuilder()
                            .With(107483, 2008)
                            .With("SB1KV58E40F039277", "http://www.rgt.co.za/photos/TOYOTA/107483_1_P.jpg", "3rd Quarter", "TOYOTA Auris 1.6 RT 5-dr", "Auris 1.6 RT 5-dr")
                            .With(VehicleValuationMother.VehicleValuation)
                            .Build();
            }
        }
    }
}