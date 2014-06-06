﻿using System;
using Lace.Request;

namespace Lace.Tests.Data.RequestData
{
    public class RequestUserInformation : ILaceRequestUserInformation
    {
        public Guid UserId
        {
            get
            {
                return new Guid("4A17B499-845F-43E2-AA2F-CFCB06920AB6");
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
                return "Penny";
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
                return "pennyl@lightstone.co.za";
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