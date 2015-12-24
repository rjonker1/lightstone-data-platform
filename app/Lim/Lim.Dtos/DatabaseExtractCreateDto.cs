using System.Collections.Generic;

namespace Lim.Dtos
{
    public class DatabaseExtractCreateDto
    {
        public DatabaseExtractCreateDto()
        {
            
        }

        public DatabaseExtractCreateDto(IReadOnlyCollection<DatabaseViewDto> selectableDatabaseViews)
        {
            SelectableDatabaseViews = selectableDatabaseViews;
        }

        public string Name { get; set; }
        public long ViewId { get; set; }
        public bool Activated { get; set; }
        public IReadOnlyCollection<DatabaseViewDto> SelectableDatabaseViews;
    }
}
