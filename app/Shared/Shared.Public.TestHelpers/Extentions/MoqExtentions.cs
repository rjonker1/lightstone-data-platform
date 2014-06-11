using System;
using System.Linq.Expressions;
using Moq;

namespace Shared.Public.TestHelpers.Extentions
{
    public static class MoqExtentions
    {
        public static void IsNeverCalled<T>(this Mock<T> mock, Expression<Action<T>> expression) where T : class
        {
            mock.Verify(expression, Times.Never());
        }
    }
}