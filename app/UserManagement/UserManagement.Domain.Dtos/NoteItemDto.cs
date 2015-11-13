using System.Collections.Generic;

namespace UserManagement.Domain.Dtos
{
    public class NoteDto
    {
        public IEnumerable<NoteItemDto> Notes { get; set; }

        public NoteDto(IEnumerable<NoteItemDto> notes)
        {
            Notes = notes;
        }
    }
    public class NoteItemDto : EntityDto
    {
        public string NoteText { get; set; }
    }
}