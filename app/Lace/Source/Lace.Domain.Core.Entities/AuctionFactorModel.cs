﻿using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class AuctionFactorModel : IRespondWithAuctionFactorModel
    {
        public AuctionFactorModel(string make, decimal value)
        {
            Make = make;
            Value = value;
        }

        [DataMember]
        public string Make
        {
            get;
            private set;
        }
        [DataMember]
        public decimal Value
        {
            get;
            private set;
        }

        public string TypeName
        {
            get
            {
                return GetType().Name;
            }
        }
        public Type Type
        {
            get
            {
                return GetType();
            }
        }
    }
}
