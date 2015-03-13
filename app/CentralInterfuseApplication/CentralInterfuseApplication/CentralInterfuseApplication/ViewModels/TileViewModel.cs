namespace CentralInterfuseApplication.ViewModels
{
    public class SystemViewModel
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Colour { get; set; }

        public SystemViewModel(string url, string name, string description, string icon, string colour)
        {
            Url = url;
            Name = name;
            Description = description;
            Icon = icon;
            Colour = colour;
        }
    }
}