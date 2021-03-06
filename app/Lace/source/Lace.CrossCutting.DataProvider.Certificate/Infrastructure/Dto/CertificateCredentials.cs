﻿using Lace.CrossCutting.DataProvider.Certificate.Core.Contracts;

namespace Lace.CrossCutting.DataProvider.Certificate.Infrastructure.Dto
{
    public class CertificateCredentials: IDefineTheCredentials
    {
        public CertificateCredentials(string domain, string userName, string password)
        {
            Domain = domain;
            Username = userName;
            Password = password;
        }

        public string Domain { get; private set; }

        public string Username { get; private set; }

        public string Password { get; private set; }
    }
}
