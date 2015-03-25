using UserManagement.Domain.Dtos;

namespace UserManagement.Api.ViewModels
{
    public class HeaderViewModel
    {
        public string Title { get; set; } 
        public string Description { get; set; }
        public string IconClass { get; set; }
        public EntityDto EntityDto { get; set; }

        public HeaderViewModel(string title, string description = "", string iconClass = "", EntityDto entityDto = null)
        {
            Title = title;
            Description = description;
            IconClass = iconClass;
            EntityDto = entityDto ?? new EntityDto();
        }
    }
}