﻿using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class AccountNumberRequestField : IAmCarIdRequestField
    {
        public AccountNumberRequestField(string field)
        {
            Field = field;
        }

        public string Field { get; private set; }
    }
}
