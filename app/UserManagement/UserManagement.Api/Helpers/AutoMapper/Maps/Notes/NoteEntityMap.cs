using System;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using Nancy.Security;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.Notes
{
    public class NoteEntityMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<Note, NoteItemDto>();
            Mapper.CreateMap<NoteDto, Note>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.NoteId == new Guid() ? Guid.NewGuid() : x.NoteId))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(x => string.IsNullOrEmpty(x.Created) ? DateTime.UtcNow : DateTime.Parse(x.Created)))
                .ForMember(dest => dest.Modified, opt => opt.MapFrom(x => DateTime.UtcNow))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(x => ServiceLocator.Current.GetInstance<IUserRepository>().GetByUserName(x.CreatedBy)))
                .ForMember(dest => dest.ModifiedBy, opt => opt.MapFrom(x => ServiceLocator.Current.GetInstance<IUserIdentity>().UserName));

            Mapper.CreateMap<EntityNote, NoteDto>()
                .ForMember(x => x.AssemblyQualifiedName, opt => opt.MapFrom(x => x.GetType().AssemblyQualifiedName))
                .Include<CustomerNote, NoteDto>();
            Mapper.CreateMap<CustomerNote, NoteDto>();

            Mapper.CreateMap<NoteDto, EntityNote>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id))
                .Include<NoteDto, CustomerNote>();
            Mapper.CreateMap<NoteDto, CustomerNote>()
                .ForMember(dest => dest.Entity, opt => opt.MapFrom(x => Mapper.Map<Guid, Customer>(x.EntityId)))
                .ForMember(dest => dest.Note, opt => opt.MapFrom(x => Mapper.Map<Guid, Note>(x.NoteId) ?? new Note(x.NoteText, Guid.NewGuid())));

        }
    }
}