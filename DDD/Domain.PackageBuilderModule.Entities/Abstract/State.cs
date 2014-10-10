using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using LightstoneApp.Domain.PackageBuilderModule.Entities.PackageBuilder;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.ComponentModel;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities.Abstract
{
    public abstract class State : INotifyPropertyChanged, IHasPackageBuilderContext
    {
        #region State INotifyPropertyChanged Implementation

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

        #endregion // State INotifyPropertyChanged Implementation

        #region State Property Change Events

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

        public event EventHandler<PropertyChangingEventArgs<State, string>> StateValueChanging
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

        protected bool OnStateValueChanging(string newValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangingEventArgs<State, string>> eventHandler;
            if ((events = _events) != null &&
                (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<State, string>>)events[0]) != null)
            {
                return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                    new PropertyChangingEventArgs<State, string>(this, "StateValue", StateValue, newValue));
            }
            return true;
        }

        public event EventHandler<PropertyChangedEventArgs<State, string>> StateValueChanged
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

        protected void OnStateValueChanged(string oldValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangedEventArgs<State, string>> eventHandler;
            if ((events = _events) != null &&
                (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<State, string>>)events[1]) != null)
            {
                EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                    new PropertyChangedEventArgs<State, string>(this, "StateValue", oldValue, StateValue),
                    _propertyChangedEventHandler);
            }
            else
            {
                OnPropertyChanged("StateValue");
            }
        }

        #endregion // State Property Change Events

        #region State Abstract Properties

        public abstract PackageBuilderContext Context { get; }

        
        public abstract string StateValue { get; set; }

        
        public abstract IEnumerable<Package> PackageViaPackageStateCollection { get; }

        
        public abstract IEnumerable<DataSource> DataSourceViaDataSourceStateCollection { get; }

        #endregion // State Abstract Properties

        #region State ToString Methods

        public override string ToString()
        {
            return ToString(null);
        }

        public virtual string ToString(IFormatProvider provider)
        {
            return string.Format(provider, @"State{0}{{{0}{1}StateValue = ""{2}""{0}}}", Environment.NewLine, @"	",
                StateValue);
        }

        #endregion // State ToString Methods
    }
}