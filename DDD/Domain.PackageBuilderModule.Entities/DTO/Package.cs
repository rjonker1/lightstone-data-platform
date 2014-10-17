using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading;
using LightstoneApp.Domain.PackageBuilderModule.Entities.Context.PackageBuilder;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.ComponentModel;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities.DTO
{
    namespace PackageBuilder
    {

        #region Package

        [DataObject]
        [DataContract]
        [StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
        public abstract class Package : Aggregate, INotifyPropertyChanged, IHasPackageBuilderContext
        {
            #region Package INotifyPropertyChanged Implementation

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

            #endregion // Package INotifyPropertyChanged Implementation

            #region Package Property Change Events

            private Delegate[] _events;

            private Delegate[] Events
            {
                get
                {
                    Delegate[] localEvents;
                    return (localEvents = _events) ??
                           Interlocked.CompareExchange(ref _events, localEvents = new Delegate[24], null) ?? localEvents;
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

            public event EventHandler<PropertyChangingEventArgs<Package, string>> NameChanging
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

            protected bool OnNameChanging(string newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<Package, string>> eventHandler;
                if ((events = _events) != null &&
                    (object) (eventHandler = (EventHandler<PropertyChangingEventArgs<Package, string>>) events[0]) !=
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

            protected void OnNameChanged(string oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<Package, string>> eventHandler;
                if ((events = _events) != null &&
                    (object) (eventHandler = (EventHandler<PropertyChangedEventArgs<Package, string>>) events[1]) !=
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
                    if ((object) value != null)
                    {
                        InterlockedDelegateCombine(ref Events[2], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object) value != null && (events = _events) != null)
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
                    (object) (eventHandler = (EventHandler<PropertyChangingEventArgs<Package, string>>) events[2]) !=
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
                    if ((object) value != null)
                    {
                        InterlockedDelegateCombine(ref Events[3], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object) value != null && (events = _events) != null)
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
                    (object) (eventHandler = (EventHandler<PropertyChangedEventArgs<Package, string>>) events[3]) !=
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

            public event EventHandler<PropertyChangingEventArgs<Package, string>> OwnerChanging
            {
                add
                {
                    if ((object) value != null)
                    {
                        InterlockedDelegateCombine(ref Events[4], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object) value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[4], value);
                    }
                }
            }

            protected bool OnOwnerChanging(string newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<Package, string>> eventHandler;
                if ((events = _events) != null &&
                    (object) (eventHandler = (EventHandler<PropertyChangingEventArgs<Package, string>>) events[4]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<Package, string>(this, "Owner", Owner, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<Package, string>> OwnerChanged
            {
                add
                {
                    if ((object) value != null)
                    {
                        InterlockedDelegateCombine(ref Events[5], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object) value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[5], value);
                    }
                }
            }

            protected void OnOwnerChanged(string oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<Package, string>> eventHandler;
                if ((events = _events) != null &&
                    (object) (eventHandler = (EventHandler<PropertyChangedEventArgs<Package, string>>) events[5]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<Package, string>(this, "Owner", oldValue, Owner),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("Owner");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<Package, DateTime?>> CreatedChanging
            {
                add
                {
                    if ((object) value != null)
                    {
                        InterlockedDelegateCombine(ref Events[6], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object) value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[6], value);
                    }
                }
            }

            protected bool OnCreatedChanging(DateTime? newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<Package, DateTime?>> eventHandler;
                if ((events = _events) != null &&
                    (object) (eventHandler = (EventHandler<PropertyChangingEventArgs<Package, DateTime?>>) events[6]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<Package, DateTime?>(this, "Created", Created, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<Package, DateTime?>> CreatedChanged
            {
                add
                {
                    if ((object) value != null)
                    {
                        InterlockedDelegateCombine(ref Events[7], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object) value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[7], value);
                    }
                }
            }

            protected void OnCreatedChanged(DateTime? oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<Package, DateTime?>> eventHandler;
                if ((events = _events) != null &&
                    (object) (eventHandler = (EventHandler<PropertyChangedEventArgs<Package, DateTime?>>) events[7]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<Package, DateTime?>(this, "Created", oldValue, Created),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("Created");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<Package, DateTime?>> EditedChanging
            {
                add
                {
                    if ((object) value != null)
                    {
                        InterlockedDelegateCombine(ref Events[8], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object) value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[8], value);
                    }
                }
            }

            protected bool OnEditedChanging(DateTime? newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<Package, DateTime?>> eventHandler;
                if ((events = _events) != null &&
                    (object) (eventHandler = (EventHandler<PropertyChangingEventArgs<Package, DateTime?>>) events[8]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<Package, DateTime?>(this, "Edited", Edited, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<Package, DateTime?>> EditedChanged
            {
                add
                {
                    if ((object) value != null)
                    {
                        InterlockedDelegateCombine(ref Events[9], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object) value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[9], value);
                    }
                }
            }

            protected void OnEditedChanged(DateTime? oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<Package, DateTime?>> eventHandler;
                if ((events = _events) != null &&
                    (object) (eventHandler = (EventHandler<PropertyChangedEventArgs<Package, DateTime?>>) events[9]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<Package, DateTime?>(this, "Edited", oldValue, Edited),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("Edited");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<Package, string>> VersionChanging
            {
                add
                {
                    if ((object) value != null)
                    {
                        InterlockedDelegateCombine(ref Events[10], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object) value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[10], value);
                    }
                }
            }

            protected bool OnVersionChanging(string newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<Package, string>> eventHandler;
                if ((events = _events) != null &&
                    (object) (eventHandler = (EventHandler<PropertyChangingEventArgs<Package, string>>) events[10]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<Package, string>(this, "Version", Version, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<Package, string>> VersionChanged
            {
                add
                {
                    if ((object) value != null)
                    {
                        InterlockedDelegateCombine(ref Events[11], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object) value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[11], value);
                    }
                }
            }

            protected void OnVersionChanged(string oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<Package, string>> eventHandler;
                if ((events = _events) != null &&
                    (object) (eventHandler = (EventHandler<PropertyChangedEventArgs<Package, string>>) events[11]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<Package, string>(this, "Version", oldValue, Version),
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
                    if ((object) value != null)
                    {
                        InterlockedDelegateCombine(ref Events[12], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object) value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[12], value);
                    }
                }
            }

            protected bool OnPublishedChanging(bool? newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<Package, bool?>> eventHandler;
                if ((events = _events) != null &&
                    (object) (eventHandler = (EventHandler<PropertyChangingEventArgs<Package, bool?>>) events[12]) !=
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
                    if ((object) value != null)
                    {
                        InterlockedDelegateCombine(ref Events[13], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object) value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[13], value);
                    }
                }
            }

            protected void OnPublishedChanged(bool? oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<Package, bool?>> eventHandler;
                if ((events = _events) != null &&
                    (object) (eventHandler = (EventHandler<PropertyChangedEventArgs<Package, bool?>>) events[13]) !=
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

            public event EventHandler<PropertyChangingEventArgs<Package, DateTime?>> RevisionDateChanging
            {
                add
                {
                    if ((object) value != null)
                    {
                        InterlockedDelegateCombine(ref Events[14], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object) value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[14], value);
                    }
                }
            }

            protected bool OnRevisionDateChanging(DateTime? newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<Package, DateTime?>> eventHandler;
                if ((events = _events) != null &&
                    (object) (eventHandler = (EventHandler<PropertyChangingEventArgs<Package, DateTime?>>) events[14]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<Package, DateTime?>(this, "RevisionDate", RevisionDate, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<Package, DateTime?>> RevisionDateChanged
            {
                add
                {
                    if ((object) value != null)
                    {
                        InterlockedDelegateCombine(ref Events[15], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object) value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[15], value);
                    }
                }
            }

            protected void OnRevisionDateChanged(DateTime? oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<Package, DateTime?>> eventHandler;
                if ((events = _events) != null &&
                    (object) (eventHandler = (EventHandler<PropertyChangedEventArgs<Package, DateTime?>>) events[15]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<Package, DateTime?>(this, "RevisionDate", oldValue, RevisionDate),
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
                    if ((object) value != null)
                    {
                        InterlockedDelegateCombine(ref Events[16], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object) value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[16], value);
                    }
                }
            }

            protected bool OnCostOfSaleChanging(decimal? newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<Package, decimal?>> eventHandler;
                if ((events = _events) != null &&
                    (object) (eventHandler = (EventHandler<PropertyChangingEventArgs<Package, decimal?>>) events[16]) !=
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
                    if ((object) value != null)
                    {
                        InterlockedDelegateCombine(ref Events[17], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object) value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[17], value);
                    }
                }
            }

            protected void OnCostOfSaleChanged(decimal? oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<Package, decimal?>> eventHandler;
                if ((events = _events) != null &&
                    (object) (eventHandler = (EventHandler<PropertyChangedEventArgs<Package, decimal?>>) events[17]) !=
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

            public event EventHandler<PropertyChangingEventArgs<Package, decimal?>> RecomendedRetailPriceChanging
            {
                add
                {
                    if ((object) value != null)
                    {
                        InterlockedDelegateCombine(ref Events[18], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object) value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[18], value);
                    }
                }
            }

            protected bool OnRecomendedRetailPriceChanging(decimal? newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<Package, decimal?>> eventHandler;
                if ((events = _events) != null &&
                    (object) (eventHandler = (EventHandler<PropertyChangingEventArgs<Package, decimal?>>) events[18]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<Package, decimal?>(this, "RecomendedRetailPrice",
                            RecomendedRetailPrice, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<Package, decimal?>> RecomendedRetailPriceChanged
            {
                add
                {
                    if ((object) value != null)
                    {
                        InterlockedDelegateCombine(ref Events[19], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object) value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[19], value);
                    }
                }
            }

            protected void OnRecomendedRetailPriceChanged(decimal? oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<Package, decimal?>> eventHandler;
                if ((events = _events) != null &&
                    (object) (eventHandler = (EventHandler<PropertyChangedEventArgs<Package, decimal?>>) events[19]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<Package, decimal?>(this, "RecomendedRetailPrice", oldValue,
                            RecomendedRetailPrice), _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("RecomendedRetailPrice");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<Package, State>> StateChanging
            {
                add
                {
                    if ((object) value != null)
                    {
                        InterlockedDelegateCombine(ref Events[20], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object) value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[20], value);
                    }
                }
            }

            protected bool OnStateChanging(State newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<Package, State>> eventHandler;
                if ((events = _events) != null &&
                    (object) (eventHandler = (EventHandler<PropertyChangingEventArgs<Package, State>>) events[20]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<Package, State>(this, "State", State, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<Package, State>> StateChanged
            {
                add
                {
                    if ((object) value != null)
                    {
                        InterlockedDelegateCombine(ref Events[21], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object) value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[21], value);
                    }
                }
            }

            protected void OnStateChanged(State oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<Package, State>> eventHandler;
                if ((events = _events) != null &&
                    (object) (eventHandler = (EventHandler<PropertyChangedEventArgs<Package, State>>) events[21]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<Package, State>(this, "State", oldValue, State),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("State");
                }
            }

            public event EventHandler<PropertyChangingEventArgs<Package, Industry>> IndustryChanging
            {
                add
                {
                    if ((object) value != null)
                    {
                        InterlockedDelegateCombine(ref Events[22], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object) value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[22], value);
                    }
                }
            }

            protected bool OnIndustryChanging(Industry newValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangingEventArgs<Package, Industry>> eventHandler;
                if ((events = _events) != null &&
                    (object) (eventHandler = (EventHandler<PropertyChangingEventArgs<Package, Industry>>) events[22]) !=
                    null)
                {
                    return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                        new PropertyChangingEventArgs<Package, Industry>(this, "Industry", Industry, newValue));
                }
                return true;
            }

            public event EventHandler<PropertyChangedEventArgs<Package, Industry>> IndustryChanged
            {
                add
                {
                    if ((object) value != null)
                    {
                        InterlockedDelegateCombine(ref Events[23], value);
                    }
                }
                remove
                {
                    Delegate[] events;
                    if ((object) value != null && (events = _events) != null)
                    {
                        InterlockedDelegateRemove(ref events[23], value);
                    }
                }
            }

            protected void OnIndustryChanged(Industry oldValue)
            {
                Delegate[] events;
                EventHandler<PropertyChangedEventArgs<Package, Industry>> eventHandler;
                if ((events = _events) != null &&
                    (object) (eventHandler = (EventHandler<PropertyChangedEventArgs<Package, Industry>>) events[23]) !=
                    null)
                {
                    EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                        new PropertyChangedEventArgs<Package, Industry>(this, "Industry", oldValue, Industry),
                        _propertyChangedEventHandler);
                }
                else
                {
                    OnPropertyChanged("Industry");
                }
            }

            #endregion // Package Property Change Events

            #region Package Abstract Properties

            public abstract PackageBuilderContext Context { get; }


            [DataObjectField(false, false, false)]
            [DataMember]
            public abstract string Name { get; set; }

            [DataObjectField(false, false, false)]
            [DataMember]
            public abstract string Description { get; set; }

            [DataObjectField(false, false, true)]
            [DataMember]
            public abstract string Owner { get; set; }

            [DataObjectField(false, false, true)]
            [DataMember]
            public abstract DateTime? Created { get; set; }

            [DataObjectField(false, false, true)]
            [DataMember]
            public abstract DateTime? Edited { get; set; }

            [DataObjectField(false, false, false)]
            [DataMember]
            public abstract string Version { get; set; }

            [DataObjectField(false, false, true)]
            [DataMember]
            public abstract bool? Published { get; set; }

            [DataObjectField(false, false, true)]
            [DataMember]
            public abstract DateTime? RevisionDate { get; set; }

            [DataObjectField(false, false, true)]
            [DataMember]
            public abstract decimal? CostOfSale { get; set; }

            [DataObjectField(false, false, true)]
            [DataMember]
            public abstract decimal? RecomendedRetailPrice { get; set; }

            [DataObjectField(false, false, false)]
            [DataMember]
            public abstract State State { get; set; }

            [DataObjectField(false, false, true)]
            [DataMember]
            public abstract Industry Industry { get; set; }

            [DataObjectField(false, false, true)]
            [DataMember]
            public abstract IEnumerable<PackageDataField> PackageDataFieldViaPackageCollection { get; }

            #endregion // Package Abstract Properties

            #region Package ToString Methods

            public override string ToString()
            {
                return ToString(null);
            }

            public virtual string ToString(IFormatProvider provider)
            {
                return string.Format(provider,
                    @"Package{0}{{{0}{1}Name = ""{2}"",{0}{1}Description = ""{3}"",{0}{1}Owner = ""{4}"",{0}{1}Created = ""{5}"",{0}{1}Edited = ""{6}"",{0}{1}Version = ""{7}"",{0}{1}Published = ""{8}"",{0}{1}RevisionDate = ""{9}"",{0}{1}CostOfSale = ""{10}"",{0}{1}RecomendedRetailPrice = ""{11}"",{0}{1}State = {12},{0}{1}Industry = {13}{0}}}",
                    Environment.NewLine, @"	", Name, Description, Owner, Created, Edited, Version, Published,
                    RevisionDate, CostOfSale, RecomendedRetailPrice,
                    "TODO: Recursively call ToString for customTypes...",
                    "TODO: Recursively call ToString for customTypes...");
            }

            #endregion // Package ToString Methods
        }

        #endregion // Package

        #region State

        #endregion // State

        #region DataProvider

        #endregion // DataProvider

        #region DataField

        #endregion // DataField

        #region PackageDataField

        #endregion // PackageDataField

        #region Industry

        #endregion // Industry

        #region IHasPackageBuilderContext

        #endregion // IHasPackageBuilderContext

        #region IPackageBuilderContext

        #endregion // IPackageBuilderContext
    }
}
