using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Nancy.ViewEngines.Razor;
using UserManagement.Api.Helpers.NancyRazorHelpers.Tag;

namespace UserManagement.Api.Helpers.NancyRazorHelpers
{
    public static class ValidationMessageExtensions
    {
        public static IHtmlString ValidationMessageFor<TModel, TR>(this HtmlHelpers<TModel> html,
            Expression<Func<TModel, TR>> prop) where TModel : class
        {

            ////Custom attributes
            //var memberExpression = prop.Body as MemberExpression;

            //if (memberExpression != null)
            //{
            //    //Getting the Display attribute.
            //    var displayAttribute = memberExpression.Member
            //                       .GetCustomAttributes(typeof(DisplayAttribute), false)
            //                       .Cast<DisplayAttribute>()
            //                       .SingleOrDefault();

            //    //Or iterate the CustomAttributes collection ...
            //    //foreach (var attribute in memberExpression.Member.CustomAttributes)
            //    //{
            //    //    var test = attribute;
            //    //}
            //}

            var validationResult = html.RenderContext.Context.ModelValidationResult;
            if (validationResult == null || validationResult.IsValid)
            {
                return NonEncodedHtmlString.Empty;
            }

            var property = ((MemberExpression) prop.Body).Member as PropertyInfo;
            var displayAttribute = ((MemberExpression)prop.Body).Member
                                   .GetCustomAttributes(typeof(DisplayAttribute), false)
                                   .Cast<DisplayAttribute>()
                                   .SingleOrDefault();


            if (displayAttribute != (null))
            {
                var displayMessage = displayAttribute.Name;
                var tagAppendedDisplayMessage = new HtmlTag("span").WithAttribute("class", "error-message");
                tagAppendedDisplayMessage.RawContent = displayMessage;

                return new NonEncodedHtmlString(tagAppendedDisplayMessage.ToString());
            }

            var keyName = property.Name;

            var hasError = validationResult.Errors.Any(err => keyName.Equals(err.Key));
            if (!hasError)
            {
                return NonEncodedHtmlString.Empty;
            }

            var error = validationResult.Errors.First(err => keyName.Equals(err.Key));
            var tag = new HtmlTag("span").WithAttribute("class", "error-message");
            tag.RawContent = error.Value.First().ErrorMessage;

            return new NonEncodedHtmlString(tag.ToString());
        }



        public static IHtmlString ValidationSummaryFor<TModel, TR>(this HtmlHelpers<TModel> html,
            Expression<Func<TModel, TR>> prop) where TModel : class
        {
            return ValidationSummaryFor(html, prop, false);
        }

        public static IHtmlString ValidationSummaryFor<TModel, TR>(this HtmlHelpers<TModel> html,
            Expression<Func<TModel, TR>> prop, bool useAllKeys) where TModel : class
        {
            var validationResult = html.RenderContext.Context.ModelValidationResult;
            if (validationResult == null || validationResult.IsValid)
            {
                return NonEncodedHtmlString.Empty;
            }

            var property = (prop.Body as MemberExpression).Member as PropertyInfo;
            var keyName = property.Name;
            var tag = new HtmlTag("ul").WithAttribute("class", "error-list");

            var errorsToLook = useAllKeys
                ? validationResult.Errors
                : validationResult.Errors.Where(x => x.Key == string.Empty);

            foreach (var error in errorsToLook)
            {
                var evalues = error.Value.Where(ev => ev.MemberNames.Contains(keyName)).ToList();
                foreach (var evalue in evalues)
                {
                    var child = tag.WithChild("li").WithAttribute("class", "error-list-item");
                    child.RawContent = evalue.ErrorMessage;
                }
            }

            return new NonEncodedHtmlString(tag.ToString());
        }
    }
}