﻿using Lace.Domain.Core.Requests.Contracts.RequestFields;

namespace Lace.Domain.Core.Entities.RequestFields
{
    public class CarIdRequestField : IAmCarIdRequestField
    {
        public string Field { get; private set; }

        public CarIdRequestField(string field)
        {
            Field = field;
        }
    }
}