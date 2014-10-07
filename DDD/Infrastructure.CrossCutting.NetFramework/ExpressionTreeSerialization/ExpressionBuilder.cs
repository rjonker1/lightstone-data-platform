using System;
using System.Linq.Expressions;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.ExpressionTreeSerialization
{
    public static class ExpressionBuilder
    {
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            if (expr1 == null && expr2 == null) throw new ArgumentException();
            if (expr1 == null) return expr2;
            if (expr2 == null) return expr1;

            var p1 = expr1;
            var p2 = UpdateParameter(expr2, p1.Parameters[0]);
            var expr = Expression.Lambda<Func<T, bool>>(Expression.AndAlso(p1.Body, p2.Body), p1.Parameters);
            return expr;
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            if (expr1 == null && expr2 == null) throw new ArgumentException();
            if (expr1 == null) return expr2;
            if (expr2 == null) return expr1;

            var p1 = expr1;
            var p2 = UpdateParameter(expr2, p1.Parameters[0]);
            var expr = Expression.Lambda<Func<T, bool>>(Expression.OrElse(p1.Body, p2.Body), p1.Parameters);
            return expr;
        }

        public static Expression<Func<T, bool>> Not<T>(Expression<Func<T, bool>> expr1)
        {
            return Expression.Lambda<Func<T, bool>>(Expression.Not(expr1.Body), expr1.Parameters);
        }

        #region Replace expression

        private static Expression<Func<T, bool>> UpdateParameter<T>(Expression<Func<T, bool>> expr, ParameterExpression newParameter)
        {
            var visitor = new ParameterUpdateVisitor(expr.Parameters[0], newParameter);
            var body = visitor.Visit(expr.Body);

            return Expression.Lambda<Func<T, bool>>(body, newParameter);
        }

        public static Expression ReplaceFilterValues<T>(Expression<Func<T, bool>> expression)
        {
            return Expression.Lambda<Func<T, bool>>(new ExprVisitorFilterReplacer().Visit(expression.Body), expression.Parameters);
        }

        #endregion

        #region Nested type: ExprVisitorFilterReplacer

        private class ExprVisitorFilterReplacer : ExpressionVisitor
        {
            protected override Expression VisitMember(MemberExpression node)
            {
                var expression = Visit(node.Expression);
                if (expression is ConstantExpression)
                    return Expression.Constant(GetValue(node));
                return base.VisitMember(node);
            }

            private static object GetValue(Expression member)
            {
                var objectMember = Expression.Convert(member, typeof(object));
                var getterLambda = Expression.Lambda<Func<object>>(objectMember);
                var getter = getterLambda.Compile();
                return getter();
            }
        } 

        #endregion

        #region Nested type: ParameterUpdateVisitor

        private class ParameterUpdateVisitor : ExpressionVisitor
        {
            private readonly ParameterExpression _newParameter;
            private readonly ParameterExpression _oldParameter;

            public ParameterUpdateVisitor(ParameterExpression oldParameter, ParameterExpression newParameter)
            {
                _oldParameter = oldParameter;
                _newParameter = newParameter;
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                if (ReferenceEquals(node, _oldParameter))
                    return _newParameter;

                return base.VisitParameter(node);
            }
        }

        #endregion
    }
}
