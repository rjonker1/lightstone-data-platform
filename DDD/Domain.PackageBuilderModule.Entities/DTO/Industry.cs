using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Threading;
using LightstoneApp.Domain.PackageBuilderModule.Entities.Context.PackageBuilder;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.ComponentModel;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities.DTO
{
    [DataObject]
    [GeneratedCode("OIALtoPLiX", "1.0")]
    [StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
    public abstract class Industry : INotifyPropertyChanged, IHasPackageBuilderContext
    {
        #region Industry INotifyPropertyChanged Implementation

        private PropertyChangedEventHandler _propertyChangedEventHandler;

        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                if ((object) value != null)
                {
                    PropertyChangedEventHandler currentHandler;
                    while (
                        Interlocked.CompareExchange(ref _propertyChangedEventHandler,
                            (PropertyChangedEventHandler)
                                Delegate.Combine(currentHandler = _propertyChangedEventHandler, value), currentHandler) !=
                        (object) currentHandler)
                    {
                    }
                }
            }
            remove
            {
                if ((object) value != null)
                {
                    PropertyChangedEventHandler currentHandler;
                    while (
                        Interlocked.CompareExchange(ref _propertyChangedEventHandler,
                            (PropertyChangedEventHandler)
                                Delegate.Remove(currentHandler = _propertyChangedEventHandler, value), currentHandler) !=
                        (object) currentHandler)
                    {
                    }
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler eventHandler;
            if ((object) (eventHandler = _propertyChangedEventHandler) != null)
            {
                EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion // Industry INotifyPropertyChanged Implementation

        #region Industry Property Change Events

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
                    currentHandler) != (object) currentHandler)
            {
            }
        }

        private static void InterlockedDelegateRemove(ref Delegate location, Delegate value)
        {
            Delegate currentHandler;
            while (
                Interlocked.CompareExchange(ref location, Delegate.Remove(currentHandler = location, value),
                    currentHandler) != (object) currentHandler)
            {
            }
        }

        public event EventHandler<PropertyChangingEventArgs<Industry, string>> ValueChanging
        {
            add
            {
                if ((object) value != null)
                {
                    InterlockedDelegateCombine(ref Events[0], value);
                }
            }
            remove
            {
                Delegate[] events;
                if ((object) value != null && (events = _events) != null)
                {
                    InterlockedDelegateRemove(ref events[0], value);
                }
            }
        }

        protected bool OnValueChanging(string newValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangingEventArgs<Industry, string>> eventHandler;
            if ((events = _events) != null &&
                (object) (eventHandler = (EventHandler<PropertyChangingEventArgs<Industry, string>>) events[0]) != null)
            {
                return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                    new PropertyChangingEventArgs<Industry, string>(this, "Value", Value, newValue));
            }
            return true;
        }

        public event EventHandler<PropertyChangedEventArgs<Industry, string>> ValueChanged
        {
            add
            {
                if ((object) value != null)
                {
                    InterlockedDelegateCombine(ref Events[1], value);
                }
            }
            remove
            {
                Delegate[] events;
                if ((object) value != null && (events = _events) != null)
                {
                    InterlockedDelegateRemove(ref events[1], value);
                }
            }
        }

        protected void OnValueChanged(string oldValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangedEventArgs<Industry, string>> eventHandler;
            if ((events = _events) != null &&
                (object) (eventHandler = (EventHandler<PropertyChangedEventArgs<Industry, string>>) events[1]) != null)
            {
                EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                    new PropertyChangedEventArgs<Industry, string>(this, "Value", oldValue, Value),
                    _propertyChangedEventHandler);
            }
            else
            {
                OnPropertyChanged("Value");
            }
        }

        #endregion // Industry Property Change Events

        #region Industry Abstract Properties

        public abstract PackageBuilderContext Context { get; }

        [DataObjectField(false, false, false)]
        public abstract string Value { get; set; }

        [DataObjectField(false, false, true)]
        public abstract IEnumerable<PackageBuilder.Package> PackageViaIndustryCollection { get; }

        [DataObjectField(false, false, true)]
        public abstract IEnumerable<DataField> DataFieldViaIndustryCollection { get; }

        #endregion // Industry Abstract Properties

        #region Industry ToString Methods

        public override string ToString()
        {
            return ToString(null);
        }

        public virtual string ToString(IFormatProvider provider)
        {
            return string.Format(provider, @"Industry{0}{{{0}{1}Value = ""{2}""{0}}}", Environment.NewLine, @"	", Value);
        }

        #endregion // Industry ToString Methods
    }
}