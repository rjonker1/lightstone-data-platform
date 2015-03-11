using System;
using System.Linq.Expressions;
using System.Reflection;

namespace UserManagement.Api.Helpers.NancyRazorHelpers.Extensions
{
    public static class ExpressionExtensions
    {
        public static PropertyInfo AsPropertyInfo<T, TR>(this Expression<Func<T, TR>> expr)
        {
            var memExpr = expr.Body as MemberExpression;
            return memExpr != null ? memExpr.Member as PropertyInfo : null;
        }
    }
}