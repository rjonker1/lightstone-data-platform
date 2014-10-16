using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using LightstoneApp.Domain.PackageBuilderModule.Entities.PackageBuilder;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.ComponentModel;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities.Abstract
{
    namespace PackageBuilder
    {

        #region Owner
        public abstract class Owner : INotifyPropertyChanged, IHasPackageBuilderContext
        {
            #region Owner INotifyPropertyChanged Implementation

            private PropertyChangedEventHandler _propertyChangedEventHandler;

            event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        PropertyChangedEventHandler currentHandler;
                        while (
                            Interlocked.CompareExchange(ref _propertyChangedEventHandler,
                                (PropertyChangedEventHandler)
                                    Delegate.Combine(currentHandler = _propertyChangedEventHandler, value),
                                currentHandler) != (object)currentHandler)
                        {
                        }
                    }
                }
                remove
                {
                    if ((object)value != null)
                    {
                        PropertyChangedEventHandler currentHandler;
                        while (
                            Interlocked.CompareExchange(ref _propertyChangedEventHandler,
                                (PropertyChangedEventHandler)
                                    Delegate.Remove(currentHandler = _propertyChangedEventHandler, value),
                                currentHandler) != (object)currentHandler)
                        {
                        }
                    }
                }
            }

            private void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler eventHandler;
                if ((object)(eventHandler = _propertyChangedEventHandler) != null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs(propertyName));
                }
            }

            #endregion // Owner INotifyPropertyChanged Implementation

            #region Owner Property Change Events

            private Delegate[] _events;

            private Delegate[] Events
            {
                get
                {
                    Delegate[] localEvents;
                    return (localEvents = _events) ??
                           Interlocked.CompareExchange(ref _events, localEvents = new Delegate[2], null) ?? localEvents;
                }
            }

            private static void InterlockedDelegateCombine(ref Delegate location, Delegate value)
            {
                Delegate currentHandler;
                while (
                    Interlocked.CompareExchange(ref location, Delegate.Combine(currentHandler = location, value),
                        currentHandler) != (object)currentHandler)
                {
                }
            }

            private static void InterlockedDelegateRemove(ref Delegate location, Delegate value)
            {
                Delegate currentHandler;
                while (
                    Interlocked.CompareExchange(ref location, Delegate.Remove(currentHandler = location, value),
                        currentHandler) != (object)currentHandler)
                {
                }
            }

            public event EventHandler<PropertyChangingEventArgs<Owner, string>> OwnerValueChanging
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[0], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[0], value);
                    }
                }
            }

            protected bool OnOwnerValueChanging(string newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<Owner, string>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Owner, string>>)events[0]) != null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<Owner, string>(this, "OwnerValue", OwnerValue, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<Owner, string>> OwnerValueChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[1], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[1], value);
                    }
                }
            }

            protected void OnOwnerValueChanged(string oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<Owner, string>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Owner, string>>)events[1]) != null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<Owner, string>(this, "OwnerValue", oldValue, OwnerValue),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("OwnerValue");
                }
            }

            #endregion // Owner Property Change Events

            #region Owner Abstract Properties

            public abstract PackageBuilderContext Context { get; }

            
            public abstract string OwnerValue { get; set; }

            
            public abstract IEnumerable<Package> PackageViaPackageOwnerCollection { get; }

            
            public abstract IEnumerable<DataSource> DataSourceViaDataSourceOwnerCollection { get; }

            #endregion // Owner Abstract Properties

            #region Owner ToString Methods

            public override string ToString()
            {
                return ToString(null);
            }

            public virtual string ToString(IFormatProvider provider)
            {
                return string.Format(provider, @"Owner{0}{{{0}{1}OwnerValue = ""{2}""{0}}}", Environment.NewLine, @"	",
                    OwnerValue);
            }

            #endregion // Owner ToString Methods
        }

        #endregion // Owner

        #region State

        #endregion // State

        #region Industry

        #endregion // Industry

        #region Package

        #endregion // Package

        #region DataSource

        #endregion // DataSource

        #region DateField

        #endregion // DateField

        #region FileAttachment

        #endregion // FileAttachment
    }
}
