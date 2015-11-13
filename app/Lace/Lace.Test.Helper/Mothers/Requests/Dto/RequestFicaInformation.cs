using System;


namespace Lace.Test.Helper.Mothers.Requests.Dto
{
    class RequestFicaInformation
    {
        public int FicaTransactionId { get; private set; }

        public long IdNumber { get; private set; }

        public Guid TransactionToken { get; private set; }

        public string Username { get; private set; }
    }
}
