using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.ComponentModel;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities
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

            [DataObjectField(false, false, false)]
            public abstract string OwnerValue { get; set; }

            [DataObjectField(false, false, true)]
            public abstract IEnumerable<Package> PackageViaPackageOwnerCollection { get; }

            [DataObjectField(false, false, true)]
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

            [DataObjectField(false, false, false)]
            public abstract string StateValue { get; set; }

            [DataObjectField(false, false, true)]
            public abstract IEnumerable<Package> PackageViaPackageStateCollection { get; }

            [DataObjectField(false, false, true)]
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

        #endregion // State

        #region Industry



        public abstract class Industry : INotifyPropertyChanged, IHasPackageBuilderContext
        {
            #region Industry INotifyPropertyChanged Implementation

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

            public event EventHandler<PropertyChangingEventArgs<Industry, string>> IndustryValueChanging
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

            protected bool OnIndustryValueChanging(string newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<Industry, string>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Industry, string>>)events[0]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<Industry, string>(this, "IndustryValue", IndustryValue, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<Industry, string>> IndustryValueChanged
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

            protected void OnIndustryValueChanged(string oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<Industry, string>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Industry, string>>)events[1]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<Industry, string>(this, "IndustryValue", oldValue, IndustryValue),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("IndustryValue");
                }
            }

            #endregion // Industry Property Change Events

            #region Industry Abstract Properties

            public abstract PackageBuilderContext Context { get; }

            [DataObjectField(false, false, false)]
            public abstract string IndustryValue { get; set; }

            [DataObjectField(false, false, true)]
            public abstract IEnumerable<Package> PackageViaPackageIndustryCollection { get; }

            [DataObjectField(false, false, true)]
            public abstract IEnumerable<DateField> DateFieldViaIndustryCollection { get; }

            #endregion // Industry Abstract Properties

            #region Industry ToString Methods

            public override string ToString()
            {
                return ToString(null);
            }

            public virtual string ToString(IFormatProvider provider)
            {
                return string.Format(provider, @"Industry{0}{{{0}{1}IndustryValue = ""{2}""{0}}}", Environment.NewLine,
                    @"	", IndustryValue);
            }

            #endregion // Industry ToString Methods
        }

        #endregion // Industry

        #region Package



        public abstract class Package : INotifyPropertyChanged, IHasPackageBuilderContext
        {
            #region Package INotifyPropertyChanged Implementation

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

            #endregion // Package INotifyPropertyChanged Implementation

            #region Package Property Change Events

            private Delegate[] _events;

            private Delegate[] Events
            {
                get
                {
                    Delegate[] localEvents;
                    return (localEvents = _events) ??
                           Interlocked.CompareExchange(ref _events, localEvents = new Delegate[22], null) ?? localEvents;
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

            public event EventHandler<PropertyChangingEventArgs<Package, string>> NameChanging
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

            protected bool OnNameChanging(string newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<Package, string>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, string>>)events[0]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<Package, string>(this, "Name", Name, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<Package, string>> NameChanged
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

            protected void OnNameChanged(string oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<Package, string>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, string>>)events[1]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<Package, string>(this, "Name", oldValue, Name),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("Name");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<Package, string>> DescriptionChanging
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[2], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[2], value);
                    }
                }
            }

            protected bool OnDescriptionChanging(string newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<Package, string>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, string>>)events[2]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<Package, string>(this, "Description", Description, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<Package, string>> DescriptionChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[3], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[3], value);
                    }
                }
            }

            protected void OnDescriptionChanged(string oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<Package, string>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, string>>)events[3]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<Package, string>(this, "Description", oldValue, Description),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("Description");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<Package, int?>> CreatedChanging
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[4], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[4], value);
                    }
                }
            }

            protected bool OnCreatedChanging(int? newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<Package, int?>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, int?>>)events[4]) != null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<Package, int?>(this, "Created", Created, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<Package, int?>> CreatedChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[5], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[5], value);
                    }
                }
            }

            protected void OnCreatedChanged(int? oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<Package, int?>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, int?>>)events[5]) != null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<Package, int?>(this, "Created", oldValue, Created),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("Created");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<Package, int?>> EditedChanging
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[6], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[6], value);
                    }
                }
            }

            protected bool OnEditedChanging(int? newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<Package, int?>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, int?>>)events[6]) != null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<Package, int?>(this, "Edited", Edited, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<Package, int?>> EditedChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[7], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[7], value);
                    }
                }
            }

            protected void OnEditedChanged(int? oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<Package, int?>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, int?>>)events[7]) != null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<Package, int?>(this, "Edited", oldValue, Edited),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("Edited");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<Package, int?>> VersionChanging
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[8], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[8], value);
                    }
                }
            }

            protected bool OnVersionChanging(int? newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<Package, int?>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, int?>>)events[8]) != null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<Package, int?>(this, "Version", Version, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<Package, int?>> VersionChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[9], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[9], value);
                    }
                }
            }

            protected void OnVersionChanged(int? oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<Package, int?>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, int?>>)events[9]) != null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<Package, int?>(this, "Version", oldValue, Version),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("Version");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<Package, bool?>> PublishedChanging
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[10], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[10], value);
                    }
                }
            }

            protected bool OnPublishedChanging(bool? newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<Package, bool?>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, bool?>>)events[10]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<Package, bool?>(this, "Published", Published, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<Package, bool?>> PublishedChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[11], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[11], value);
                    }
                }
            }

            protected void OnPublishedChanged(bool? oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<Package, bool?>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, bool?>>)events[11]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<Package, bool?>(this, "Published", oldValue, Published),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("Published");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<Package, int?>> RevisionDateChanging
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[12], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[12], value);
                    }
                }
            }

            protected bool OnRevisionDateChanging(int? newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<Package, int?>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, int?>>)events[12]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<Package, int?>(this, "RevisionDate", RevisionDate, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<Package, int?>> RevisionDateChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[13], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[13], value);
                    }
                }
            }

            protected void OnRevisionDateChanged(int? oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<Package, int?>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, int?>>)events[13]) != null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<Package, int?>(this, "RevisionDate", oldValue, RevisionDate),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("RevisionDate");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<Package, decimal?>> CostOfSaleChanging
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[14], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[14], value);
                    }
                }
            }

            protected bool OnCostOfSaleChanging(decimal? newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<Package, decimal?>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, decimal?>>)events[14]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<Package, decimal?>(this, "CostOfSale", CostOfSale, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<Package, decimal?>> CostOfSaleChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[15], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[15], value);
                    }
                }
            }

            protected void OnCostOfSaleChanged(decimal? oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<Package, decimal?>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, decimal?>>)events[15]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<Package, decimal?>(this, "CostOfSale", oldValue, CostOfSale),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("CostOfSale");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<Package, Owner>> PackageOwnerChanging
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[16], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[16], value);
                    }
                }
            }

            protected bool OnPackageOwnerChanging(Owner newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<Package, Owner>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, Owner>>)events[16]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<Package, Owner>(this, "PackageOwner", PackageOwner, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<Package, Owner>> PackageOwnerChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[17], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[17], value);
                    }
                }
            }

            protected void OnPackageOwnerChanged(Owner oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<Package, Owner>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, Owner>>)events[17]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<Package, Owner>(this, "PackageOwner", oldValue, PackageOwner),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("PackageOwner");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<Package, State>> PackageStateChanging
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[18], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[18], value);
                    }
                }
            }

            protected bool OnPackageStateChanging(State newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<Package, State>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, State>>)events[18]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<Package, State>(this, "PackageState", PackageState, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<Package, State>> PackageStateChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[19], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[19], value);
                    }
                }
            }

            protected void OnPackageStateChanged(State oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<Package, State>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, State>>)events[19]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<Package, State>(this, "PackageState", oldValue, PackageState),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("PackageState");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<Package, Industry>> PackageIndustryChanging
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[20], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[20], value);
                    }
                }
            }

            protected bool OnPackageIndustryChanging(Industry newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<Package, Industry>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, Industry>>)events[20]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<Package, Industry>(this, "PackageIndustry", PackageIndustry,
                            newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<Package, Industry>> PackageIndustryChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[21], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[21], value);
                    }
                }
            }

            protected void OnPackageIndustryChanged(Industry oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<Package, Industry>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, Industry>>)events[21]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<Package, Industry>(this, "PackageIndustry", oldValue,
                            PackageIndustry), _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("PackageIndustry");
                }
            }

            #endregion // Package Property Change Events

            #region Package Abstract Properties

            public abstract PackageBuilderContext Context { get; }

            [DataObjectField(false, false, true)]
            public abstract string Name { get; set; }

            [DataObjectField(false, false, true)]
            public abstract string Description { get; set; }

            [DataObjectField(false, false, true)]
            public abstract int? Created { get; set; }

            [DataObjectField(false, false, true)]
            public abstract int? Edited { get; set; }

            [DataObjectField(false, false, true)]
            public abstract int? Version { get; set; }

            [DataObjectField(false, false, true)]
            public abstract bool? Published { get; set; }

            [DataObjectField(false, false, true)]
            public abstract int? RevisionDate { get; set; }

            [DataObjectField(false, false, true)]
            public abstract decimal? CostOfSale { get; set; }

            [DataObjectField(false, false, true)]
            public abstract Owner PackageOwner { get; set; }

            [DataObjectField(false, false, true)]
            public abstract State PackageState { get; set; }

            [DataObjectField(false, false, true)]
            public abstract Industry PackageIndustry { get; set; }

            [DataObjectField(false, false, true)]
            public abstract IEnumerable<DataSource> DataSourceViaPackageCollection { get; }

            #endregion // Package Abstract Properties

            #region Package ToString Methods

            public override string ToString()
            {
                return ToString(null);
            }

            public virtual string ToString(IFormatProvider provider)
            {
                return string.Format(provider,
                    @"Package{0}{{{0}{1}Name = ""{2}"",{0}{1}Description = ""{3}"",{0}{1}Created = ""{4}"",{0}{1}Edited = ""{5}"",{0}{1}Version = ""{6}"",{0}{1}Published = ""{7}"",{0}{1}RevisionDate = ""{8}"",{0}{1}CostOfSale = ""{9}"",{0}{1}PackageOwner = {10},{0}{1}PackageState = {11},{0}{1}PackageIndustry = {12}{0}}}",
                    Environment.NewLine, @"	", Name, Description, Created, Edited, Version, Published, RevisionDate,
                    CostOfSale, "TODO: Recursively call ToString for customTypes...",
                    "TODO: Recursively call ToString for customTypes...",
                    "TODO: Recursively call ToString for customTypes...");
            }

            #endregion // Package ToString Methods
        }

        #endregion // Package

        #region DataSource



        public abstract class DataSource : INotifyPropertyChanged, IHasPackageBuilderContext
        {
            #region DataSource INotifyPropertyChanged Implementation

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

            #endregion // DataSource INotifyPropertyChanged Implementation

            #region DataSource Property Change Events

            private Delegate[] _events;

            private Delegate[] Events
            {
                get
                {
                    Delegate[] localEvents;
                    return (localEvents = _events) ??
                           Interlocked.CompareExchange(ref _events, localEvents = new Delegate[22], null) ?? localEvents;
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

            public event EventHandler<PropertyChangingEventArgs<DataSource, string>> NameChanging
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

            protected bool OnNameChanging(string newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<DataSource, string>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataSource, string>>)events[0]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<DataSource, string>(this, "Name", Name, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<DataSource, string>> NameChanged
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

            protected void OnNameChanged(string oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<DataSource, string>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataSource, string>>)events[1]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<DataSource, string>(this, "Name", oldValue, Name),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("Name");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<DataSource, string>> DescriptionChanging
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[2], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[2], value);
                    }
                }
            }

            protected bool OnDescriptionChanging(string newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<DataSource, string>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataSource, string>>)events[2]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<DataSource, string>(this, "Description", Description, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<DataSource, string>> DescriptionChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[3], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[3], value);
                    }
                }
            }

            protected void OnDescriptionChanged(string oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<DataSource, string>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataSource, string>>)events[3]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<DataSource, string>(this, "Description", oldValue, Description),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("Description");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<DataSource, int?>> CreatedChanging
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[4], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[4], value);
                    }
                }
            }

            protected bool OnCreatedChanging(int? newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<DataSource, int?>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataSource, int?>>)events[4]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<DataSource, int?>(this, "Created", Created, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<DataSource, int?>> CreatedChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[5], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[5], value);
                    }
                }
            }

            protected void OnCreatedChanged(int? oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<DataSource, int?>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataSource, int?>>)events[5]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<DataSource, int?>(this, "Created", oldValue, Created),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("Created");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<DataSource, int?>> EditedChanging
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[6], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[6], value);
                    }
                }
            }

            protected bool OnEditedChanging(int? newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<DataSource, int?>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataSource, int?>>)events[6]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<DataSource, int?>(this, "Edited", Edited, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<DataSource, int?>> EditedChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[7], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[7], value);
                    }
                }
            }

            protected void OnEditedChanged(int? oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<DataSource, int?>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataSource, int?>>)events[7]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<DataSource, int?>(this, "Edited", oldValue, Edited),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("Edited");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<DataSource, int?>> VersionChanging
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[8], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[8], value);
                    }
                }
            }

            protected bool OnVersionChanging(int? newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<DataSource, int?>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataSource, int?>>)events[8]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<DataSource, int?>(this, "Version", Version, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<DataSource, int?>> VersionChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[9], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[9], value);
                    }
                }
            }

            protected void OnVersionChanged(int? oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<DataSource, int?>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataSource, int?>>)events[9]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<DataSource, int?>(this, "Version", oldValue, Version),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("Version");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<DataSource, decimal?>> CostOfSaleChanging
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[10], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[10], value);
                    }
                }
            }

            protected bool OnCostOfSaleChanging(decimal? newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<DataSource, decimal?>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataSource, decimal?>>)events[10]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<DataSource, decimal?>(this, "CostOfSale", CostOfSale, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<DataSource, decimal?>> CostOfSaleChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[11], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[11], value);
                    }
                }
            }

            protected void OnCostOfSaleChanged(decimal? oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<DataSource, decimal?>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataSource, decimal?>>)events[11]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<DataSource, decimal?>(this, "CostOfSale", oldValue, CostOfSale),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("CostOfSale");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<DataSource, int?>> RevisionDateChanging
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[12], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[12], value);
                    }
                }
            }

            protected bool OnRevisionDateChanging(int? newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<DataSource, int?>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataSource, int?>>)events[12]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<DataSource, int?>(this, "RevisionDate", RevisionDate, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<DataSource, int?>> RevisionDateChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[13], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[13], value);
                    }
                }
            }

            protected void OnRevisionDateChanged(int? oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<DataSource, int?>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataSource, int?>>)events[13]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<DataSource, int?>(this, "RevisionDate", oldValue, RevisionDate),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("RevisionDate");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<DataSource, string>> SourceURLChanging
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[14], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[14], value);
                    }
                }
            }

            protected bool OnSourceURLChanging(string newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<DataSource, string>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataSource, string>>)events[14]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<DataSource, string>(this, "SourceURL", SourceURL, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<DataSource, string>> SourceURLChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[15], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[15], value);
                    }
                }
            }

            protected void OnSourceURLChanged(string oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<DataSource, string>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataSource, string>>)events[15]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<DataSource, string>(this, "SourceURL", oldValue, SourceURL),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("SourceURL");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<DataSource, Package>> PackageChanging
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[16], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[16], value);
                    }
                }
            }

            protected bool OnPackageChanging(Package newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<DataSource, Package>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataSource, Package>>)events[16]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<DataSource, Package>(this, "Package", Package, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<DataSource, Package>> PackageChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[17], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[17], value);
                    }
                }
            }

            protected void OnPackageChanged(Package oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<DataSource, Package>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataSource, Package>>)events[17]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<DataSource, Package>(this, "Package", oldValue, Package),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("Package");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<DataSource, Owner>> DataSourceOwnerChanging
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[18], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[18], value);
                    }
                }
            }

            protected bool OnDataSourceOwnerChanging(Owner newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<DataSource, Owner>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataSource, Owner>>)events[18]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<DataSource, Owner>(this, "DataSourceOwner", DataSourceOwner,
                            newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<DataSource, Owner>> DataSourceOwnerChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[19], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[19], value);
                    }
                }
            }

            protected void OnDataSourceOwnerChanged(Owner oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<DataSource, Owner>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataSource, Owner>>)events[19]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<DataSource, Owner>(this, "DataSourceOwner", oldValue,
                            DataSourceOwner), _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("DataSourceOwner");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<DataSource, State>> DataSourceStateChanging
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[20], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[20], value);
                    }
                }
            }

            protected bool OnDataSourceStateChanging(State newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<DataSource, State>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataSource, State>>)events[20]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<DataSource, State>(this, "DataSourceState", DataSourceState,
                            newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<DataSource, State>> DataSourceStateChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[21], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[21], value);
                    }
                }
            }

            protected void OnDataSourceStateChanged(State oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<DataSource, State>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataSource, State>>)events[21]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<DataSource, State>(this, "DataSourceState", oldValue,
                            DataSourceState), _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("DataSourceState");
                }
            }

            #endregion // DataSource Property Change Events

            #region DataSource Abstract Properties

            public abstract PackageBuilderContext Context { get; }

            [DataObjectField(false, false, true)]
            public abstract string Name { get; set; }

            [DataObjectField(false, false, true)]
            public abstract string Description { get; set; }

            [DataObjectField(false, false, true)]
            public abstract int? Created { get; set; }

            [DataObjectField(false, false, true)]
            public abstract int? Edited { get; set; }

            [DataObjectField(false, false, true)]
            public abstract int? Version { get; set; }

            [DataObjectField(false, false, true)]
            public abstract decimal? CostOfSale { get; set; }

            [DataObjectField(false, false, true)]
            public abstract int? RevisionDate { get; set; }

            [DataObjectField(false, false, true)]
            public abstract string SourceURL { get; set; }

            [DataObjectField(false, false, true)]
            public abstract Package Package { get; set; }

            [DataObjectField(false, false, true)]
            public abstract Owner DataSourceOwner { get; set; }

            [DataObjectField(false, false, true)]
            public abstract State DataSourceState { get; set; }

            [DataObjectField(false, false, true)]
            public abstract IEnumerable<DateField> DateFieldViaDataSourceCollection { get; }

            [DataObjectField(false, false, true)]
            public abstract IEnumerable<FileAttachment> FileAttachmentViaDataSourceCollection { get; }

            #endregion // DataSource Abstract Properties

            #region DataSource ToString Methods

            public override string ToString()
            {
                return ToString(null);
            }

            public virtual string ToString(IFormatProvider provider)
            {
                return string.Format(provider,
                    @"DataSource{0}{{{0}{1}Name = ""{2}"",{0}{1}Description = ""{3}"",{0}{1}Created = ""{4}"",{0}{1}Edited = ""{5}"",{0}{1}Version = ""{6}"",{0}{1}CostOfSale = ""{7}"",{0}{1}RevisionDate = ""{8}"",{0}{1}SourceURL = ""{9}"",{0}{1}Package = {10},{0}{1}DataSourceOwner = {11},{0}{1}DataSourceState = {12}{0}}}",
                    Environment.NewLine, @"	", Name, Description, Created, Edited, Version, CostOfSale, RevisionDate,
                    SourceURL, "TODO: Recursively call ToString for customTypes...",
                    "TODO: Recursively call ToString for customTypes...",
                    "TODO: Recursively call ToString for customTypes...");
            }

            #endregion // DataSource ToString Methods
        }

        #endregion // DataSource

        #region DateField



        public abstract class DateField : INotifyPropertyChanged, IHasPackageBuilderContext
        {
            #region DateField INotifyPropertyChanged Implementation

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

            #endregion // DateField INotifyPropertyChanged Implementation

            #region DateField Property Change Events

            private Delegate[] _events;

            private Delegate[] Events
            {
                get
                {
                    Delegate[] localEvents;
                    return (localEvents = _events) ??
                           Interlocked.CompareExchange(ref _events, localEvents = new Delegate[10], null) ?? localEvents;
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

            public event EventHandler<PropertyChangingEventArgs<DateField, string>> LabelChanging
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

            protected bool OnLabelChanging(string newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<DateField, string>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DateField, string>>)events[0]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<DateField, string>(this, "Label", Label, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<DateField, string>> LabelChanged
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

            protected void OnLabelChanged(string oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<DateField, string>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DateField, string>>)events[1]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<DateField, string>(this, "Label", oldValue, Label),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("Label");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<DateField, string>> DefinitionChanging
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[2], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[2], value);
                    }
                }
            }

            protected bool OnDefinitionChanging(string newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<DateField, string>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DateField, string>>)events[2]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<DateField, string>(this, "Definition", Definition, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<DateField, string>> DefinitionChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[3], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[3], value);
                    }
                }
            }

            protected void OnDefinitionChanged(string oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<DateField, string>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DateField, string>>)events[3]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<DateField, string>(this, "Definition", oldValue, Definition),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("Definition");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<DateField, bool?>> SelectedChanging
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[4], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[4], value);
                    }
                }
            }

            protected bool OnSelectedChanging(bool? newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<DateField, bool?>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DateField, bool?>>)events[4]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<DateField, bool?>(this, "Selected", Selected, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<DateField, bool?>> SelectedChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[5], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[5], value);
                    }
                }
            }

            protected void OnSelectedChanged(bool? oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<DateField, bool?>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DateField, bool?>>)events[5]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<DateField, bool?>(this, "Selected", oldValue, Selected),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("Selected");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<DateField, DataSource>> DataSourceChanging
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[6], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[6], value);
                    }
                }
            }

            protected bool OnDataSourceChanging(DataSource newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<DateField, DataSource>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DateField, DataSource>>)events[6]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<DateField, DataSource>(this, "DataSource", DataSource, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<DateField, DataSource>> DataSourceChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[7], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[7], value);
                    }
                }
            }

            protected void OnDataSourceChanged(DataSource oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<DateField, DataSource>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DateField, DataSource>>)events[7]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<DateField, DataSource>(this, "DataSource", oldValue, DataSource),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("DataSource");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<DateField, Industry>> IndustryChanging
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[8], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[8], value);
                    }
                }
            }

            protected bool OnIndustryChanging(Industry newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<DateField, Industry>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DateField, Industry>>)events[8]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<DateField, Industry>(this, "Industry", Industry, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<DateField, Industry>> IndustryChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[9], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[9], value);
                    }
                }
            }

            protected void OnIndustryChanged(Industry oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<DateField, Industry>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DateField, Industry>>)events[9]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<DateField, Industry>(this, "Industry", oldValue, Industry),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("Industry");
                }
            }

            #endregion // DateField Property Change Events

            #region DateField Abstract Properties

            public abstract PackageBuilderContext Context { get; }

            [DataObjectField(false, false, true)]
            public abstract string Label { get; set; }

            [DataObjectField(false, false, true)]
            public abstract string Definition { get; set; }

            [DataObjectField(false, false, true)]
            public abstract bool? Selected { get; set; }

            [DataObjectField(false, false, true)]
            public abstract DataSource DataSource { get; set; }

            [DataObjectField(false, false, true)]
            public abstract Industry Industry { get; set; }

            #endregion // DateField Abstract Properties

            #region DateField ToString Methods

            public override string ToString()
            {
                return ToString(null);
            }

            public virtual string ToString(IFormatProvider provider)
            {
                return string.Format(provider,
                    @"DateField{0}{{{0}{1}Label = ""{2}"",{0}{1}Definition = ""{3}"",{0}{1}Selected = ""{4}"",{0}{1}DataSource = {5},{0}{1}Industry = {6}{0}}}",
                    Environment.NewLine, @"	", Label, Definition, Selected,
                    "TODO: Recursively call ToString for customTypes...",
                    "TODO: Recursively call ToString for customTypes...");
            }

            #endregion // DateField ToString Methods
        }

        #endregion // DateField

        #region FileAttachment



        public abstract class FileAttachment : INotifyPropertyChanged, IHasPackageBuilderContext
        {
            #region FileAttachment INotifyPropertyChanged Implementation

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

            #endregion // FileAttachment INotifyPropertyChanged Implementation

            #region FileAttachment Property Change Events

            private Delegate[] _events;

            private Delegate[] Events
            {
                get
                {
                    Delegate[] localEvents;
                    return (localEvents = _events) ??
                           Interlocked.CompareExchange(ref _events, localEvents = new Delegate[6], null) ?? localEvents;
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

            public event EventHandler<PropertyChangingEventArgs<FileAttachment, string>> FileNameChanging
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

            protected bool OnFileNameChanging(string newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<FileAttachment, string>> eventHandler;
                if ((events = _events) != null &&
                    (object)
                        (eventHandler = (EventHandler<PropertyChangingEventArgs<FileAttachment, string>>)events[0]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<FileAttachment, string>(this, "FileName", FileName, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<FileAttachment, string>> FileNameChanged
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

            protected void OnFileNameChanged(string oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<FileAttachment, string>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<FileAttachment, string>>)events[1]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<FileAttachment, string>(this, "FileName", oldValue, FileName),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("FileName");
                }
            }

            [CLSCompliant(false)]
            public event EventHandler<PropertyChangingEventArgs<FileAttachment, byte[]>> BlobChanging
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[2], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[2], value);
                    }
                }
            }

            [CLSCompliant(false)]
            protected bool OnBlobChanging(byte[] newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<FileAttachment, byte[]>> eventHandler;
                if ((events = _events) != null &&
                    (object)
                        (eventHandler = (EventHandler<PropertyChangingEventArgs<FileAttachment, byte[]>>)events[2]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<FileAttachment, byte[]>(this, "Blob", Blob, newValue));
                }
                return true;
            }

            [CLSCompliant(false)]
            public event EventHandler<PropertyChangedEventArgs<FileAttachment, byte[]>> BlobChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[3], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[3], value);
                    }
                }
            }

            [CLSCompliant(false)]
            protected void OnBlobChanged(byte[] oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<FileAttachment, byte[]>> eventHandler;
                if ((events = _events) != null &&
                    (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<FileAttachment, byte[]>>)events[3]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<FileAttachment, byte[]>(this, "Blob", oldValue, Blob),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("Blob");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<FileAttachment, DataSource>> DataSourceChanging
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[4], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[4], value);
                    }
                }
            }

            protected bool OnDataSourceChanging(DataSource newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<FileAttachment, DataSource>> eventHandler;
                if ((events = _events) != null &&
                    (object)
                        (eventHandler = (EventHandler<PropertyChangingEventArgs<FileAttachment, DataSource>>)events[4]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<FileAttachment, DataSource>(this, "DataSource", DataSource,
                            newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<FileAttachment, DataSource>> DataSourceChanged
            {
                add
                {
                    if ((object)value != null)
                    {
                        InterlockedDelegateCombine(ref Events[5], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object)value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[5], value);
                    }
                }
            }

            protected void OnDataSourceChanged(DataSource oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<FileAttachment, DataSource>> eventHandler;
                if ((events = _events) != null &&
                    (object)
                        (eventHandler = (EventHandler<PropertyChangedEventArgs<FileAttachment, DataSource>>)events[5]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<FileAttachment, DataSource>(this, "DataSource", oldValue,
                            DataSource), _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("DataSource");
                }
            }

            #endregion // FileAttachment Property Change Events

            #region FileAttachment Abstract Properties

            public abstract PackageBuilderContext Context { get; }

            [DataObjectField(false, false, true)]
            public abstract string FileName { get; set; }

            [CLSCompliant(false)]
            [DataObjectField(false, false, true)]
            public abstract byte[] Blob { get; set; }

            [DataObjectField(false, false, true)]
            public abstract DataSource DataSource { get; set; }

            #endregion // FileAttachment Abstract Properties

            #region FileAttachment ToString Methods

            public override string ToString()
            {
                return ToString(null);
            }

            public virtual string ToString(IFormatProvider provider)
            {
                return string.Format(provider,
                    @"FileAttachment{0}{{{0}{1}FileName = ""{2}"",{0}{1}Blob = ""{3}"",{0}{1}DataSource = {4}{0}}}",
                    Environment.NewLine, @"	", FileName, Blob, "TODO: Recursively call ToString for customTypes...");
            }

            #endregion // FileAttachment ToString Methods
        }

        #endregion // FileAttachment
    }
}
