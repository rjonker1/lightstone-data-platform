namespace UserManagement.Api.ViewModels
{
    public class PageHeadingViewModel
    {
        public string Title { get; set; } 
        public string Description { get; set; }

        public PageHeadingViewModel(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}