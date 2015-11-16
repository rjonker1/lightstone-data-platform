using System;
using System.Collections.Generic;

namespace UserManagement.Domain.Dtos
{
    public class NoteDto : EntityDto
    {
        public Guid NoteId { get; set; }
        public Guid EntityId { get; set; }
        public string AssemblyQualifiedName { get; set; }
        public string NoteText { get; set; }
        public IEnumerable<NoteItemDto> Notes { get; set; }

        // Json.net
        public NoteDto() { }

        public NoteDto(Guid entityId, Type entityType, IEnumerable<NoteItemDto> notes)
        {
            EntityId = entityId;
            AssemblyQualifiedName = entityType.AssemblyQualifiedName;
            Notes = notes;
        }
    }
    public class NoteItemDto : EntityDto
    {
        public string NoteText { get; set; }
    }
}