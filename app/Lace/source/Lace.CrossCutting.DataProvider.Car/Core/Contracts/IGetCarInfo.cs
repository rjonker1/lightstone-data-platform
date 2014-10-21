﻿using System.Collections.Generic;
using Lace.CrossCutting.DataProvider.Car.Core.Models;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.CrossCutting.DataProvider.Car.Core.Contracts
{
    public interface IGetCarInfo
    {
        IEnumerable<CarInfo> Cars { get; }
        void GetCarInfo(IProvideCarInformationForRequest request);
    }
}