using System;
using AutoMapper;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.Billings
{
    public class BillingMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            //Mapper.CreateMap<Billing, BillingDto>();
            Mapper.CreateMap<CustomerDto, Billing>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id))
                .ForMember(dest => dest.ContactNumber, opt => opt.MapFrom(x => x.BillingContactNumber))
                .ForMember(dest => dest.ContractPerson, opt => opt.MapFrom(x => x.BillingContractPerson))
                .ForMember(dest => dest.CompanyRegistration, opt => opt.MapFrom(x => x.BillingCompanyRegistration))
                .ForMember(dest => dest.DebitOrderDate, opt => opt.MapFrom(x => x.BillingDebitOrderDate))
                .ForMember(dest => dest.PastelId, opt => opt.MapFrom(x => x.BillingPastelId))
                .ForMember(dest => dest.VatNumber, opt => opt.MapFrom(x => x.BillingVatNumber))
                .ForMember(dest => dest.PaymentType, opt => opt.MapFrom(x => Mapper.Map<Tuple<Guid, Type>, Entity>(new Tuple<Guid, Type>(x.BillingPaymentTypeId, typeof(PaymentType)))));
        }
    }
}