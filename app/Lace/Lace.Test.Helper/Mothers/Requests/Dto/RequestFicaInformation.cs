﻿using System;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Test.Helper.Mothers.Requests.Dto
{
    class RequestFicaInformation : IHaveFica
    {
        public int FicaTransactionId { get; private set; }

        public long IdNumber { get; private set; }

        public Guid TransactionToken { get; private set; }

        public string Username { get; private set; }
    }
}
