using System;
using System.Collections.Generic;
using AutoMapper;
using Nancy;
using Nancy.Responses.Negotiation;
using Shared.BuildingBlocks.Api.Security;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Helpers;

namespace UserManagement.Api.Modules
{
    public class NoteModule : SecureModule
    {
        public NoteModule(IEntityByTypeRepository entityRetriever)
        {
            Get["/Notes/{type}/{id}"] = _ =>
            {
                var typeName = _.type.ToString();
                var type = Type.GetType(typeName);
                var notes = Mapper.Map<IEnumerable<Note>, IEnumerable<NoteItemDto>>(entityRetriever.GetEntityNotes(type));

                return Negotiate
                    .WithView("Index")
                    .WithModel(new NoteDto(notes))
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new NoteDto(notes));
            };

            Post["/Notes"] = _ =>
            {
                return null;
            };
        }
    }
}