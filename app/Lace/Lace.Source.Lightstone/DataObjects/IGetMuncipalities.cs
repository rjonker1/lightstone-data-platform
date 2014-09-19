﻿using System.Collections.Generic;
using Lace.Request;
using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.DataObjects
{
    public interface IGetMuncipalities
    {
        IEnumerable<Municipality> Municipalities { get; }
        void GetMunicipalities(IProvideCarInformationForRequest request);
    }
}
