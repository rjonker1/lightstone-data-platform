﻿using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Models;
using Lace.Toolbox.Database.Repositories;

namespace Lace.Domain.DataProviders.Lightstone.Queries
{
    public class MakeQuery : IGetMakes
    {
        private readonly ILog _log;
        public IEnumerable<Make> Makes { get; private set; }
        private readonly IReadOnlyRepository _repository;

        public MakeQuery(IReadOnlyRepository repository)
        {
            _log = LogManager.GetLogger(GetType());
            _repository = repository;
        }

        public void GetMakes(IHaveCarInformation request)
        {
            try
            {
                Makes = _repository.GetAll<Make>(null);
                if (!Makes.Any())
                    Makes = _repository.Get<Make>(Make.SelectAll, new {});
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error getting Make data because of {0}", ex, ex.Message);
                throw;
            }
        }
    }
}
