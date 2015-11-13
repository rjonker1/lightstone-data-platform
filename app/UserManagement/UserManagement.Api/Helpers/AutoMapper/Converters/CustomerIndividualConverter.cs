using System;
using AutoMapper;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Enums;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Api.Helpers.AutoMapper.Converters
{
    public class CustomerIndividualConverter : TypeConverter<CustomerDto, Individual>
    {
        private readonly IIndividualRepository _individuals;

        public CustomerIndividualConverter(IIndividualRepository individuals)
        {
            _individuals = individuals;
        }

        protected override Individual ConvertCore(CustomerDto dto)
        {
            var individual = new Individual(dto.IndividualName, dto.IndividualSurname, dto.IndividualIdNumber, dto.IndividualId == new Guid() ? Guid.NewGuid() : dto.IndividualId);
            var existingIndividual = _individuals.GetExistingIndividual(individual);
            if (existingIndividual != null)
                individual = existingIndividual;

            individual.SetContactNumber(dto.IndividualContactNumber, ContactNumberType.Work);
            individual.SetEmail(dto.IndividualEmail);

            return individual;
        }
    }
}