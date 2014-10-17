using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading;
using LightstoneApp.Domain.PackageBuilderModule.Entities.Context.PackageBuilder;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.ComponentModel;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities.DTO.PackageBuilder
{
    [DataObject]
    [DataContract]
    [StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
    public abstract class State : INotifyPropertyChanged, IHasPackageBuilderContext
    {
        #region State INotifyPropertyChanged Implementation

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
                                Delegate.Combine(currentHandler = _propertyChangedEventHandler, value),
                            currentHandler) != (object) currentHandler)
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
                                Delegate.Remove(currentHandler = _propertyChangedEventHandler, value),
                            currentHandler) != (object) currentHandler)
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

        public event EventHandler<PropertyChangingEventArgs<State, string>> ValueChanging
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
            EventHandler<PropertyChangingEventArgs<State, string>> eventHandler;
            if ((events = _events) != null &&
                (object) (eventHandler = (EventHandler<PropertyChangingEventArgs<State, string>>) events[0]) != null)
            {
                return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                    new PropertyChangingEventArgs<State, string>(this, "Value", Value, newValue));
            }
            return true;
        }

        public event EventHandler<PropertyChangedEventArgs<State, string>> ValueChanged
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
            EventHandler<PropertyChangedEventArgs<State, string>> eventHandler;
            if ((events = _events) != null &&
                (object) (eventHandler = (EventHandler<PropertyChangedEventArgs<State, string>>) events[1]) != null)
            {
                EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                    new PropertyChangedEventArgs<State, string>(this, "Value", oldValue, Value),
                    _propertyChangedEventHandler);
            }
            else
            {
                OnPropertyChanged("Value");
            }
        }

        #endregion // State Property Change Events

        #region State Abstract Properties

        public abstract PackageBuilderContext Context { get; }

        [DataObjectField(false, false, false)]
        [DataMember]
        public abstract string Value { get; set; }

        [DataObjectField(false, false, true)]
        [DataMember]
        public abstract IEnumerable<Package> PackageViaStateCollection { get; }

        [DataObjectField(false, false, true)]
        [DataMember]
        public abstract IEnumerable<DataProvider> DataProviderViaStateCollection { get; }

        #endregion // State Abstract Properties

        #region State ToString Methods

        public override string ToString()
        {
            return ToString(null);
        }

        public virtual string ToString(IFormatProvider provider)
        {
            return string.Format(provider, @"State{0}{{{0}{1}Value = ""{2}""{0}}}", Environment.NewLine, @"	", Value);
        }

        #endregion // State ToString Methods

        #region Constants

        private const string UnderConstruction = "Under construction";
        private const string Published = "Published";
        private const string Expired = "Expired";
        
        #endregion

        /// <summary>
        /// CONSTRAINT State_Value_RoleValueConstraint1 CHECK ("Value" IN (N'Under construction', N'Published', N'Expired'))
        /// </summary>
        public static readonly string ConstraintValues = new {UnderConstruction, Published, Expired}.ToString();



    }

    
   
    
}