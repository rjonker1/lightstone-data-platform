﻿using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Factories;
using Lace.Shared.Extensions;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Dtos;
using Lace.Toolbox.Database.Repositories;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace Lace.Toolbox.Database.Factories
{
    public class Vin12VehicleDataFactory :
        AbstractVin12VehicleFactory<ICollection<IPointToLaceProvider>, IAmRequestField, IReadOnlyRepository, List<Vin12CarinformationDto>>
    {
        private static readonly IMineResponseData<ICollection<IPointToLaceProvider>> Factory = new ResponseDataMiningFactory();
        private static readonly ILog Log = LogManager.GetLogger<Vin12VehicleDataFactory>();

        public override List<Vin12CarinformationDto> Vin12CarInformation(ICollection<IPointToLaceProvider> response, IAmRequestField request,
            IReadOnlyRepository repository)
        {
            try
            {
                return repository.Get<Vin12CarinformationDto>(Vin12CarinformationDto.Select, new { @Vin = FindVinNumber(request, response) }).ToList();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error getting VIN12 information because of {0}", ex, ex.Message);
                throw;
            }
        }

        private static string FindVinNumber(IAmRequestField field, ICollection<IPointToLaceProvider> response)
        {
            return !string.IsNullOrEmpty(field.GetValue())
                ? field.GetValue()
                : Factory.MineVinNumber(response);
        }
    }
}