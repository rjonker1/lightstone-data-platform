using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using LightstoneApp.Domain.PackageBuilderModule.Entities.PackageBuilder;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.ComponentModel;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities.Abstract
{
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

        protected bool OnCreatedChanging(DateTime? newValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangingEventArgs<DataSource, DateTime?>> eventHandler;
            if ((events = _events) != null &&
                (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataSource, DateTime?>>)events[4]) !=
                null)
            {
                return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                    new PropertyChangingEventArgs<DataSource, DateTime?>(this, "Created", Created, newValue));
            }
            return true;
        }

        public event EventHandler<PropertyChangedEventArgs<DataSource, DateTime?>> CreatedChanged
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
            EventHandler<PropertyChangedEventArgs<DataSource, DateTime?>> eventHandler;
            if ((events = _events) != null &&
                (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataSource, DateTime?>>)events[5]) !=
                null)
            {
                EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                    new PropertyChangedEventArgs<DataSource, DateTime?>(this, "Created", oldValue, Created),
                    _propertyChangedEventHandler);
            }
            else
            {
                OnPropertyChanged("Created");
            }
        }

        public event EventHandler<PropertyChangingEventArgs<DataSource, DateTime?>> EditedChanging
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
            EventHandler<PropertyChangingEventArgs<DataSource, DateTime?>> eventHandler;
            if ((events = _events) != null &&
                (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataSource, DateTime?>>)events[6]) !=
                null)
            {
                return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                    new PropertyChangingEventArgs<DataSource, DateTime?>(this, "Edited", Edited, newValue));
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

        protected void OnEditedChanged(DateTime? oldValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangedEventArgs<DataSource, DateTime?>> eventHandler;
            if ((events = _events) != null &&
                (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataSource, DateTime?>>)events[7]) !=
                null)
            {
                EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                    new PropertyChangedEventArgs<DataSource, DateTime?>(this, "Edited", oldValue, Edited),
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

        protected bool OnVersionChanging(string newValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangingEventArgs<DataSource, string>> eventHandler;
            if ((events = _events) != null &&
                (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataSource, string>>)events[8]) !=
                null)
            {
                return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                    new PropertyChangingEventArgs<DataSource, string>(this, "Version", Version, newValue));
            }
            return true;
        }

        public event EventHandler<PropertyChangedEventArgs<DataSource, string>> VersionChanged
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
            EventHandler<PropertyChangedEventArgs<DataSource, string>> eventHandler;
            if ((events = _events) != null &&
                (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataSource, string>>)events[9]) !=
                null)
            {
                EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                    new PropertyChangedEventArgs<DataSource, string>(this, "Version", oldValue, Version),
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

        protected bool OnRevisionDateChanging(DateTime? newValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangingEventArgs<DataSource, DateTime?>> eventHandler;
            if ((events = _events) != null &&
                (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataSource, DateTime?>>)events[12]) !=
                null)
            {
                return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                    new PropertyChangingEventArgs<DataSource, DateTime?>(this, "RevisionDate", RevisionDate, newValue));
            }
            return true;
        }

        public event EventHandler<PropertyChangedEventArgs<DataSource, DateTime?>> RevisionDateChanged
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
            EventHandler<PropertyChangedEventArgs<DataSource, DateTime?>> eventHandler;
            if ((events = _events) != null &&
                (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataSource, DateTime?>>)events[13]) !=
                null)
            {
                EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                    new PropertyChangedEventArgs<DataSource, DateTime?>(this, "RevisionDate", oldValue, RevisionDate),
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

        public event EventHandler<PropertyChangingEventArgs<DataSource, PackageBuilder.Owner>> DataSourceOwnerChanging
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

        protected bool OnDataSourceOwnerChanging(PackageBuilder.Owner newValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangingEventArgs<DataSource, PackageBuilder.Owner>> eventHandler;
            if ((events = _events) != null &&
                (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataSource, PackageBuilder.Owner>>)events[18]) !=
                null)
            {
                return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                    new PropertyChangingEventArgs<DataSource, PackageBuilder.Owner>(this, "DataSourceOwner", DataSourceOwner,
                        newValue));
            }
            return true;
        }

        public event EventHandler<PropertyChangedEventArgs<DataSource, PackageBuilder.Owner>> DataSourceOwnerChanged
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

        protected void OnDataSourceOwnerChanged(PackageBuilder.Owner oldValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangedEventArgs<DataSource, PackageBuilder.Owner>> eventHandler;
            if ((events = _events) != null &&
                (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataSource, PackageBuilder.Owner>>)events[19]) !=
                null)
            {
                EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                    new PropertyChangedEventArgs<DataSource, PackageBuilder.Owner>(this, "DataSourceOwner", oldValue,
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

        
        public abstract string Name { get; set; }

        
        public abstract string Description { get; set; }

        
        public abstract DateTime? Created { get; set; }


        public abstract DateTime? Edited { get; set; }

        
        public abstract string Version { get; set; }

        
        public abstract decimal? CostOfSale { get; set; }

        
        public abstract DateTime? RevisionDate { get; set; }

        
        public abstract string SourceURL { get; set; }

        
        public abstract Package Package { get; set; }

        
        public abstract PackageBuilder.Owner DataSourceOwner { get; set; }

        
        public abstract State DataSourceState { get; set; }

        
        public abstract IEnumerable<DateField> DateFieldViaDataSourceCollection { get; }

        
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
}