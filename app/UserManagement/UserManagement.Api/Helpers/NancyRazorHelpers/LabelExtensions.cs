using System;
using System.Linq.Expressions;
using Nancy.ViewEngines.Razor;
using UserManagement.Api.Helpers.NancyRazorHelpers.Tag;

namespace UserManagement.Api.Helpers.NancyRazorHelpers
{
    public static class LabelExtensions
    {
        public static IHtmlString LabelFor<TModel, TR>(this HtmlHelpers<TModel> html,
           Expression<Func<TModel, TR>> prop) where TModel : class
        {
            return LabelFor(html, prop, null);
        }

        public static IHtmlString LabelFor<TModel, TR>(this HtmlHelpers<TModel> html,
            Expression<Func<TModel, TR>> prop, object htmlAttributes) where TModel : class
        {
            var label = HtmlTagBuilder.CreateLabelFor(prop, htmlAttributes);
            return label != null ? new NonEncodedHtmlString(label.ToString()) : NonEncodedHtmlString.Empty;
        }
    }
}