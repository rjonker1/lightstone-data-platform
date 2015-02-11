﻿using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Domain.DataProviders.Lightstone.UnitOfWork
{
    public class MakeUnitOfWork : IGetMakes
    {
        private readonly ILog _log;
        public IEnumerable<Make> Makes { get; private set; }
        private readonly IReadOnlyRepository<Make> _repository;

        public MakeUnitOfWork(IReadOnlyRepository<Make> repository)
        {
            _log = LogManager.GetLogger(GetType());
            _repository = repository;
        }

        public void GetMakes(IProvideCarInformationForRequest request)
        {
            try
            {
                Makes = _repository.GetAll();
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error getting Make data because of {0}", ex.Message);
            }
        }
    }
}
