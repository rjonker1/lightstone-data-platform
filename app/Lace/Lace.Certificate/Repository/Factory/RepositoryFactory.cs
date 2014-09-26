﻿using System.Data;
using Lace.Certificate.Definitions;
using Lace.Certificate.Models;
using ServiceStack.Redis;

namespace Lace.Certificate.Repository.Factory
{
    public class RepositoryFactory : ISetupCertificateRepository
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _redisClient;
        private readonly string _certficateConfiguration;

        public RepositoryFactory(IDbConnection connection, IRedisClient redisClient)
        {
            _connection = connection;
            _redisClient = redisClient;
        }

        public RepositoryFactory(string certficateConfiguration)
        {
            _certficateConfiguration = certficateConfiguration;
        }

        public IReadOnlyRepository<BaseStation> BaseStationRepository()
        {
            return new BaseStationRepository(_connection, _redisClient);
        }

        public IReadOnlyRepository<CoOrdinateCertificate> CertifcateRepository()
        {
            return new CertificateRepository(_certficateConfiguration);
        }
    }
}
