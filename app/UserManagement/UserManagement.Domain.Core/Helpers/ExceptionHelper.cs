using System;
using DataPlatform.Shared.Helpers.Extensions;

namespace UserManagement.Domain.Core.Helpers
{
    public class ExceptionHelper
    {
        public static void IgnoreException(Action action)
        {
            try
            {
                action();
            }
            catch (Exception exception)
            {
                typeof(ExceptionHelper).Error(() => exception);
            }
        }

        public static object IgnoreException<TResult>(Func<TResult> action)
        {
            try
            {
                return action.Invoke();
            }
            catch (Exception exception)
            {
                typeof(ExceptionHelper).Error(() => exception);
                return null;
            }
        }

        public static object IgnoreException<T, TResult>(Func<T, TResult> action, T param)
        {
            try
            {
                return action.Invoke(param);
            }
            catch (Exception exception)
            {
                typeof(ExceptionHelper).Error(() => exception);
                return null;
            }
        } 
    }
}