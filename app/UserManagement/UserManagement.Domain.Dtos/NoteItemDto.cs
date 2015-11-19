using System;
using System.Collections.Generic;

namespace UserManagement.Domain.Dtos
{
    public class NoteDto : EntityDto
    {
        public Guid EntityNoteId { get; set; }
        public Guid NoteId { get; set; }
        public Guid EntityId { get; set; }
        public string AssemblyQualifiedName { get; set; }
        public string NoteText { get; set; }
        public string RedirectPath { get; set; }
        public IEnumerable<NoteItemDto> Notes { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int PageTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public int RecordsTotal { get; set; }

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
        public Guid Id { get; set; }
        public Guid NoteId { get; set; }
        public string NoteNoteText { get; set; }
    }
}