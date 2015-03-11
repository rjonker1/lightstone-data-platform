namespace UserManagement.Api.Helpers.NancyRazorHelpers
{
    public class SelectListItem
    {

        public SelectListItem()
        {
        }

        public SelectListItem(SelectListItem item)
        {
        }

        public SelectListItem(string text, string value, bool selected = false)
        {
            Text = text;
            Value = value;
            Selected = selected;
        }

        public string Value { get; set; }
        public string Text { get; set; }

        public bool Selected { get; set; }
    }
}