using System;
using AutoMapper;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.Billings
{
    public class BillingMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<CustomerDto, Billing>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.BillingId))
                .ForMember(dest => dest.LegalEntityName, opt => opt.MapFrom(x => x.BillingLegalEntityName))
                .ForMember(dest => dest.AccountContactName, opt => opt.MapFrom(x => x.BillingAccountContactName))
                .ForMember(dest => dest.AccountContactNumber, opt => opt.MapFrom(x => x.BillingAccountContactNumber))
                .ForMember(dest => dest.AccountContactEmail, opt => opt.MapFrom(x => x.BillingAccountContactEmail))
                .ForMember(dest => dest.CompanyRegistration, opt => opt.MapFrom(x => x.BillingCompanyRegistration))
                .ForMember(dest => dest.DebitOrderDate, opt => opt.MapFrom(x => x.BillingDebitOrderDate))
                .ForMember(dest => dest.PastelId, opt => opt.MapFrom(x => x.BillingPastelId))
                .ForMember(dest => dest.VatNumber, opt => opt.MapFrom(x => x.BillingVatNumber));
                //.ForMember(dest => dest.PaymentType, opt => opt.MapFrom(x => ServiceLocator.Current.GetInstance<IValueEntityRepository<PaymentType>>().Get(x.BillingPaymentTypeId)));

            Mapper.CreateMap<ClientDto, Billing>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.BillingId))
                .ForMember(dest => dest.LegalEntityName, opt => opt.MapFrom(x => x.BillingLegalEntityName))
                .ForMember(dest => dest.AccountContactName, opt => opt.MapFrom(x => x.BillingAccountContactName))
                .ForMember(dest => dest.AccountContactNumber, opt => opt.MapFrom(x => x.BillingAccountContactNumber))
                .ForMember(dest => dest.AccountContactEmail, opt => opt.MapFrom(x => x.BillingAccountContactEmail))
                .ForMember(dest => dest.CompanyRegistration, opt => opt.MapFrom(x => x.BillingCompanyRegistration))
                .ForMember(dest => dest.DebitOrderDate, opt => opt.MapFrom(x => x.BillingDebitOrderDate))
                .ForMember(dest => dest.PastelId, opt => opt.MapFrom(x => x.BillingPastelId))
                .ForMember(dest => dest.VatNumber, opt => opt.MapFrom(x => x.BillingVatNumber));
            //.ForMember(dest => dest.PaymentType, opt => opt.MapFrom(x => ServiceLocator.Current.GetInstance<IValueEntityRepository<PaymentType>>().Get(x.BillingPaymentTypeId)));
        }
    }
}