using System;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Xml.Linq;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.ExpressionTreeSerialization;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework
{
    [DataContract]
    public class CustomQuery<TEntity>
    {
        #region Properties

        [DataMember]
        public string SerializedExpression { get; set; }

        #endregion

        #region Constructors

        public CustomQuery()
        {
        }

        public CustomQuery(Expression<Func<TEntity, bool>> expresion)
        {
            var predicate = (Expression<Func<TEntity, bool>>) ExpressionBuilder.ReplaceFilterValues(expresion);
            SerializedExpression = new ExpressionSerializer().Serialize(predicate).ToString();
        }

        #endregion

        #region Public Methods

        public Expression<Func<TEntity, bool>> ToDomainExpression()
        {
            if (SerializedExpression == null)
                throw new ArgumentException("SerializedExpression");

            // It's need because AutoMapper doesn't know map dto to domain entities...
            string domainExpression = SerializedExpression.Replace("Application.BoundedContext.Dtos",
                "Domain.BoundedContext.Entities");

            XElement aux = XElement.Parse(domainExpression);
            return new ExpressionSerializer().Deserialize<Func<TEntity, bool>>(aux);
        }

        /// <summary>
        /// </summary>
        /// <param name="applicationBoundedContextDtos">"Application.BoundedContext.Dtos"</param>
        /// <param name="domainBoundedContextEntities">"Domain.BoundedContext.Entities"</param>
        /// <returns></returns>
        public Expression<Func<TEntity, bool>> ToDomainExpression(string applicationBoundedContextDtos,
            string domainBoundedContextEntities)
        {
            if (SerializedExpression == null)
                throw new ArgumentException("SerializedExpression");

            // It's need because AutoMapper doesn't know map dto to domain entities...
            string domainExpression = SerializedExpression.Replace(applicationBoundedContextDtos,
                domainBoundedContextEntities);

            XElement aux = XElement.Parse(domainExpression);
            return new ExpressionSerializer().Deserialize<Func<TEntity, bool>>(aux);
        }

        #endregion
    }
}