﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Nancy.ViewEngines.Razor;
using UserManagement.Api.Helpers.NancyRazorHelpers.Extensions;
using UserManagement.Api.Helpers.NancyRazorHelpers.Tag;

namespace UserManagement.Api.Helpers.NancyRazorHelpers
{
    public static class SelectExtensions
    {
        public static IHtmlString DropDownListFor<TModel, TR>(this HtmlHelpers<TModel> html,
            Expression<Func<TModel, TR>> prop, SelectList items) where TModel : class
        {
            var tag = HtmlTagBuilder.CreateSelectFor(html.Model, prop, items);
            return tag != null ? new NonEncodedHtmlString(tag.ToString()) : NonEncodedHtmlString.Empty;
        }

        public static IHtmlString DropDownListFor<TModel, TS, TV, TT>(this HtmlHelpers<TModel> html,
            Expression<Func<TModel, IEnumerable<TS>>> source,
            Expression<Func<TModel, TV>> propModelValue,
            Expression<Func<TS, TV>> propItemValue, Expression<Func<TS, TT>> propItemText) where TModel : class
        {

            var model = html.Model;
            if (model == null) return NonEncodedHtmlString.Empty;
            var sourceProperty = source.AsPropertyInfo();
            var items = sourceProperty.GetValue(model) as IEnumerable<TS>;
            var list = SelectList.CreateFrom(items, propItemValue, propItemText);
            var tag = HtmlTagBuilder.CreateSelectFor(model, propModelValue, list);
            return tag != null ? new NonEncodedHtmlString(tag.ToString()) : NonEncodedHtmlString.Empty;
        }


    }
}