using System;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Test.Helper.Mothers.Requests.Dto
{
    public class RequestUserInformation : IHaveUser
    {
        public Guid UserId
        {
            get
            {
                return new Guid("5a7222e1-ee65-433b-b673-827319e89cbb");
            }
        }

        public Guid AggregateId
        {
            get
            {
                return Guid.NewGuid();
            }
        }

        public string UserName
        {
            get
            {
                return null;
            }
        }

        public string UserFirstName
        {
            get
            {
                return "Murray";
            }
        }

        public string UserLastName
        {
            get
            {
                return null;
            }
        }

        public string UserEmail
        {
            get
            {
                return "murrayw@lightstone.co.za";
            }
        }

        public string UserPhone
        {
            get
            {
                return null;
            }
        }
    }
}
