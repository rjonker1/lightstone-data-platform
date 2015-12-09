using System;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using Nancy.Security;
using UserManagement.Api.Helpers.Extensions;
using UserManagement.Api.Helpers.Security;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.Notes
{
    public class NoteEntityMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<EntityNote, NoteItemDto>()
                .Include<CustomerNote, NoteItemDto>()
                .Include<UserNote, NoteItemDto>();
            Mapper.CreateMap<CustomerNote, NoteItemDto>()
                .ForMember(dest => dest.Created, opt => opt.MapFrom(x => x.Note.Created))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(x => x.Note.CreatedBy));
            Mapper.CreateMap<UserNote, NoteItemDto>()
                .ForMember(dest => dest.Created, opt => opt.MapFrom(x => x.Note.Created))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(x => x.Note.CreatedBy));

            Mapper.CreateMap<NoteDto, Note>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.NoteId == new Guid() ? Guid.NewGuid() : x.NoteId))
                .ForMember(dest => dest.NoteText, opt => opt.MapFrom(x => x.NoteText.FirstNCharacters(255)))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(x => string.IsNullOrEmpty(x.Created) ? DateTime.UtcNow : DateTime.Parse(x.Created)))
                .ForMember(dest => dest.Modified, opt => opt.MapFrom(x => DateTime.UtcNow))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(x => ServiceLocator.Current.GetInstance<ICurrentUserIdentity>().UserIdentity.UserName))
                .ForMember(dest => dest.ModifiedBy, opt => opt.MapFrom(x => ServiceLocator.Current.GetInstance<ICurrentUserIdentity>().UserIdentity.UserName));

            Mapper.CreateMap<NoteDto, EntityNote>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id))
                .Include<NoteDto, CustomerNote>()
                .Include<NoteDto, UserNote>();
            Mapper.CreateMap<NoteDto, CustomerNote>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.EntityNoteId == new Guid() ? Guid.NewGuid() : x.EntityNoteId))
                .ForMember(dest => dest.Entity, opt => opt.MapFrom(x => Mapper.Map<Guid, Customer>(x.EntityId)))
                .ForMember(dest => dest.Note, opt => opt.MapFrom(x => Mapper.Map(x, Mapper.Map<Guid, Note>(x.NoteId) ?? new Note(x.NoteText, Guid.NewGuid()), typeof(NoteDto), typeof(Note))));
            Mapper.CreateMap<NoteDto, UserNote>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.EntityNoteId == new Guid() ? Guid.NewGuid() : x.EntityNoteId))
                .ForMember(dest => dest.Entity, opt => opt.MapFrom(x => Mapper.Map<Guid, User>(x.EntityId)))
                .ForMember(dest => dest.Note, opt => opt.MapFrom(x => Mapper.Map(x, Mapper.Map<Guid, Note>(x.NoteId) ?? new Note(x.NoteText, Guid.NewGuid()), typeof(NoteDto), typeof(Note))));
        }
    }
}