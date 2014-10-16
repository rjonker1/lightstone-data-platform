using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace LightstoneApp.Infrastructure.Data.Core
{
    public class QueryableUtils
    {
        #region OrderBy

        public static readonly MethodInfo OrderByMethod =
            typeof (Queryable).GetMethods()
                .Where(method => method.Name == "OrderBy")
                .Single(method => method.GetParameters().Length == 2);

        public static readonly MethodInfo OrderByDescending =
            typeof (Queryable).GetMethods()
                .Where(method => method.Name == "OrderByDescending")
                .Single(method => method.GetParameters().Length == 2);

        public static IQueryable<TSource> CallOrderBy<TSource>(IQueryable<TSource> source, string propertyName,
            bool ascending)
        {
            MethodInfo orderMethod = ascending ? OrderByMethod : OrderByDescending;
            Type propertyType;
            LambdaExpression lambda = GenerateSelector<TSource>(propertyName, out propertyType);

            MethodInfo genericMethod = orderMethod.MakeGenericMethod(new[] {typeof (TSource), propertyType});
            object ret = genericMethod.Invoke(null, new object[] {source, lambda});
            return (IQueryable<TSource>) ret;
        }

        private static LambdaExpression GenerateSelector<TEntity>(String propertyName, out Type resultType)
        {
            ParameterExpression parameter = Expression.Parameter(typeof (TEntity), "Entity");
            PropertyInfo property;
            Expression propertyAccess;

            if (propertyName.Contains('.'))
            {
                string[] childProperties = propertyName.Split('.');
                property = typeof (TEntity).GetProperty(childProperties[0],
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
                for (int i = 1; i < childProperties.Length; i++)
                {
                    property = property.PropertyType.GetProperty(childProperties[i],
                        BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    propertyAccess = Expression.MakeMemberAccess(propertyAccess, property);
                }
            }
            else
            {
                property = typeof (TEntity).GetProperty(propertyName,
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
            }
            resultType = property.PropertyType;

            return Expression.Lambda(propertyAccess, parameter);
        }

        #endregion
    }
}