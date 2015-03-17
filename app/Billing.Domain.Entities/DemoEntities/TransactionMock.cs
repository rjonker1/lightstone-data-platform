﻿using System;
using Billing.Domain.Core.Entities;

namespace Billing.Domain.Entities.DemoEntities
{
    public class TransactionMocks : Entity
    {
        public virtual string TransactionDetail { get; set; }

        public TransactionMocks()
        {
            TransactionDetail = "Trans001";
        }
    }
}