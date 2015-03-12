namespace UserManagement.Api.ViewModels
{
    public class HeaderViewModel
    {
        public string Title { get; set; } 
        public string Description { get; set; }
        public string IconClass { get; set; }

        public HeaderViewModel(string title, string description = "", string iconClass = "")
        {
            Title = title;
            Description = description;
            IconClass = iconClass;
        }
    }
}