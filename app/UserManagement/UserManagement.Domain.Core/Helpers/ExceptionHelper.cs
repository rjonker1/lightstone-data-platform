using System;
using DataPlatform.Shared.Enums;
using Shared.Logging;

namespace UserManagement.Domain.Core.Helpers
{
    public class ExceptionHelper
    {
        public static void IgnoreException(Action action, bool logException = true)
        {
            try
            {
                action();
            }
            catch (Exception exception)
            {
                if (logException)
                    typeof(ExceptionHelper).Error(() => exception, SystemName.UserManagement);
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
                typeof(ExceptionHelper).Error(() => exception, SystemName.UserManagement);
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
                typeof(ExceptionHelper).Error(() => exception, SystemName.UserManagement);
                return null;
            }
        } 
    }
}