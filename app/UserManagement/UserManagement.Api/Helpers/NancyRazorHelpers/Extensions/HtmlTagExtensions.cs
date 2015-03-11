using UserManagement.Api.Helpers.NancyRazorHelpers.Tag;

namespace UserManagement.Api.Helpers.NancyRazorHelpers.Extensions
{
    public static class HtmlTagExtensions
    {
        public static void ApplyModelProperty(this HtmlTag tag, object model, string property)
        {
            if (model != null)
            {
                var modelProperty = model.GetType().GetProperty(property);
                if (modelProperty != null && modelProperty.CanRead)
                {
                    tag.WithNonEmptyAttribute("value", modelProperty.GetValue(model));
                }
            }

        }
    }
}