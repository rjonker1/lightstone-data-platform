using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using LightstoneApp.Domain.PackageBuilderModule.Entities.PackageBuilder;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.ComponentModel;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities.Abstract
{
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

        protected bool OnCreatedChanging(DateTime? newValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangingEventArgs<Package, DateTime?>> eventHandler;
            if ((events = _events) != null &&
                (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, DateTime?>>)events[4]) != null)
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

        protected void OnCreatedChanged(DateTime? oldValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangedEventArgs<Package, DateTime?>> eventHandler;
            if ((events = _events) != null &&
                (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, DateTime?>>)events[5]) != null)
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

        protected bool OnEditedChanging(DateTime? newValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangingEventArgs<Package, DateTime?>> eventHandler;
            if ((events = _events) != null &&
                (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, DateTime?>>)events[6]) != null)
            {
                return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                    new PropertyChangingEventArgs<Package, DateTime?>(this, "Edited", Edited, newValue));
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

        protected void OnEditedChanged(DateTime? oldValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangedEventArgs<Package, DateTime?>> eventHandler;
            if ((events = _events) != null &&
                (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, DateTime?>>)events[7]) != null)
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

        protected bool OnVersionChanging(string newValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangingEventArgs<Package, string>> eventHandler;
            if ((events = _events) != null &&
                (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, string>>)events[8]) != null)
            {
                return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                    new PropertyChangingEventArgs<Package, string>(this, "Version", Version, newValue));
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

        protected void OnVersionChanged(string oldValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangedEventArgs<Package, string>> eventHandler;
            if ((events = _events) != null &&
                (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, string>>)events[9]) != null)
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

        protected bool OnRevisionDateChanging(DateTime? newValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangingEventArgs<Package, DateTime?>> eventHandler;
            if ((events = _events) != null &&
                (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, DateTime?>>)events[12]) !=
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

        protected void OnRevisionDateChanged(DateTime? oldValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangedEventArgs<Package, DateTime?>> eventHandler;
            if ((events = _events) != null &&
                (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, DateTime?>>)events[13]) != null)
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

        public event EventHandler<PropertyChangingEventArgs<Package, PackageBuilder.Owner>> PackageOwnerChanging
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

        protected bool OnPackageOwnerChanging(PackageBuilder.Owner newValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangingEventArgs<Package, PackageBuilder.Owner>> eventHandler;
            if ((events = _events) != null &&
                (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, PackageBuilder.Owner>>)events[16]) !=
                null)
            {
                return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                    new PropertyChangingEventArgs<Package, PackageBuilder.Owner>(this, "PackageOwner", PackageOwner, newValue));
            }
            return true;
        }

        public event EventHandler<PropertyChangedEventArgs<Package, PackageBuilder.Owner>> PackageOwnerChanged
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

        protected void OnPackageOwnerChanged(PackageBuilder.Owner oldValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangedEventArgs<Package, PackageBuilder.Owner>> eventHandler;
            if ((events = _events) != null &&
                (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, PackageBuilder.Owner>>)events[17]) !=
                null)
            {
                EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                    new PropertyChangedEventArgs<Package, PackageBuilder.Owner>(this, "PackageOwner", oldValue, PackageOwner),
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

        
        public abstract string Name { get; set; }

        
        public abstract string Description { get; set; }

        
        public abstract DateTime? Created { get; set; }


        public abstract DateTime? Edited { get; set; }

        
        public abstract string Version { get; set; }

        
        public abstract bool? Published { get; set; }


        public abstract DateTime? RevisionDate { get; set; }

        
        public abstract decimal? CostOfSale { get; set; }

        
        public abstract PackageBuilder.Owner PackageOwner { get; set; }

        
        public abstract State PackageState { get; set; }

        
        public abstract Industry PackageIndustry { get; set; }

        
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
}