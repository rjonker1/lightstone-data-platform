using System;
using System.ComponentModel;
using System.Threading;
using LightstoneApp.Domain.PackageBuilderModule.Entities.PackageBuilder;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.ComponentModel;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities.Abstract
{
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

        
        public abstract string Label { get; set; }

        
        public abstract string Definition { get; set; }

        
        public abstract bool? Selected { get; set; }

        
        public abstract DataSource DataSource { get; set; }

        
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
}