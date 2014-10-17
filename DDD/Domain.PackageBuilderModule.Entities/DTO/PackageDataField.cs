using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading;
using LightstoneApp.Domain.Core;
using LightstoneApp.Domain.PackageBuilderModule.Entities.Context.PackageBuilder;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.ComponentModel;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities.DTO
{
    [DataObject]
    [DataContract]
    [StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
    public abstract class PackageDataField : ValueObject<PackageDataField>, INotifyPropertyChanged, IHasPackageBuilderContext
    {
        #region PackageDataField INotifyPropertyChanged Implementation

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

        #endregion // PackageDataField INotifyPropertyChanged Implementation

        #region PackageDataField Property Change Events

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

        public event EventHandler<PropertyChangingEventArgs<PackageDataField, int>> PriorityChanging
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

        protected bool OnPriorityChanging(int newValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangingEventArgs<PackageDataField, int>> eventHandler;
            if ((events = _events) != null &&
                (object) (eventHandler = (EventHandler<PropertyChangingEventArgs<PackageDataField, int>>) events[0]) !=
                null)
            {
                return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                    new PropertyChangingEventArgs<PackageDataField, int>(this, "Priority", Priority, newValue));
            }
            return true;
        }

        public event EventHandler<PropertyChangedEventArgs<PackageDataField, int>> PriorityChanged
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

        protected void OnPriorityChanged(int oldValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangedEventArgs<PackageDataField, int>> eventHandler;
            if ((events = _events) != null &&
                (object) (eventHandler = (EventHandler<PropertyChangedEventArgs<PackageDataField, int>>) events[1]) !=
                null)
            {
                EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                    new PropertyChangedEventArgs<PackageDataField, int>(this, "Priority", oldValue, Priority),
                    _propertyChangedEventHandler);
            }
            else
            {
                OnPropertyChanged("Priority");
            }
        }

        public event EventHandler<PropertyChangingEventArgs<PackageDataField, string>> UnifiedNameChanging
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

        protected bool OnUnifiedNameChanging(string newValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangingEventArgs<PackageDataField, string>> eventHandler;
            if ((events = _events) != null &&
                (object)
                    (eventHandler = (EventHandler<PropertyChangingEventArgs<PackageDataField, string>>) events[2]) !=
                null)
            {
                return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                    new PropertyChangingEventArgs<PackageDataField, string>(this, "UnifiedName", UnifiedName,
                        newValue));
            }
            return true;
        }

        public event EventHandler<PropertyChangedEventArgs<PackageDataField, string>> UnifiedNameChanged
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

        protected void OnUnifiedNameChanged(string oldValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangedEventArgs<PackageDataField, string>> eventHandler;
            if ((events = _events) != null &&
                (object)
                    (eventHandler = (EventHandler<PropertyChangedEventArgs<PackageDataField, string>>) events[3]) !=
                null)
            {
                EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                    new PropertyChangedEventArgs<PackageDataField, string>(this, "UnifiedName", oldValue,
                        UnifiedName), _propertyChangedEventHandler);
            }
            else
            {
                OnPropertyChanged("UnifiedName");
            }
        }

        public event EventHandler<PropertyChangingEventArgs<PackageDataField, bool>> SelectedChanging
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

        protected bool OnSelectedChanging(bool newValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangingEventArgs<PackageDataField, bool>> eventHandler;
            if ((events = _events) != null &&
                (object)
                    (eventHandler = (EventHandler<PropertyChangingEventArgs<PackageDataField, bool>>) events[4]) !=
                null)
            {
                return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                    new PropertyChangingEventArgs<PackageDataField, bool>(this, "Selected", Selected, newValue));
            }
            return true;
        }

        public event EventHandler<PropertyChangedEventArgs<PackageDataField, bool>> SelectedChanged
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

        protected void OnSelectedChanged(bool oldValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangedEventArgs<PackageDataField, bool>> eventHandler;
            if ((events = _events) != null &&
                (object) (eventHandler = (EventHandler<PropertyChangedEventArgs<PackageDataField, bool>>) events[5]) !=
                null)
            {
                EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                    new PropertyChangedEventArgs<PackageDataField, bool>(this, "Selected", oldValue, Selected),
                    _propertyChangedEventHandler);
            }
            else
            {
                OnPropertyChanged("Selected");
            }
        }

        public event EventHandler<PropertyChangingEventArgs<PackageDataField, PackageBuilder.Package>> PackageChanging
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

        protected bool OnPackageChanging(PackageBuilder.Package newValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangingEventArgs<PackageDataField, PackageBuilder.Package>> eventHandler;
            if ((events = _events) != null &&
                (object)
                    (eventHandler = (EventHandler<PropertyChangingEventArgs<PackageDataField, PackageBuilder.Package>>) events[6]) !=
                null)
            {
                return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                    new PropertyChangingEventArgs<PackageDataField, PackageBuilder.Package>(this, "Package", Package, newValue));
            }
            return true;
        }

        public event EventHandler<PropertyChangedEventArgs<PackageDataField, PackageBuilder.Package>> PackageChanged
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

        protected void OnPackageChanged(PackageBuilder.Package oldValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangedEventArgs<PackageDataField, PackageBuilder.Package>> eventHandler;
            if ((events = _events) != null &&
                (object)
                    (eventHandler = (EventHandler<PropertyChangedEventArgs<PackageDataField, PackageBuilder.Package>>) events[7]) !=
                null)
            {
                EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                    new PropertyChangedEventArgs<PackageDataField, PackageBuilder.Package>(this, "Package", oldValue, Package),
                    _propertyChangedEventHandler);
            }
            else
            {
                OnPropertyChanged("Package");
            }
        }

        public event EventHandler<PropertyChangingEventArgs<PackageDataField, DataField>> DataFieldChanging
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

        protected bool OnDataFieldChanging(DataField newValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangingEventArgs<PackageDataField, DataField>> eventHandler;
            if ((events = _events) != null &&
                (object)
                    (eventHandler = (EventHandler<PropertyChangingEventArgs<PackageDataField, DataField>>) events[8]) !=
                null)
            {
                return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                    new PropertyChangingEventArgs<PackageDataField, DataField>(this, "DataField", DataField,
                        newValue));
            }
            return true;
        }

        public event EventHandler<PropertyChangedEventArgs<PackageDataField, DataField>> DataFieldChanged
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

        protected void OnDataFieldChanged(DataField oldValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangedEventArgs<PackageDataField, DataField>> eventHandler;
            if ((events = _events) != null &&
                (object)
                    (eventHandler = (EventHandler<PropertyChangedEventArgs<PackageDataField, DataField>>) events[9]) !=
                null)
            {
                EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                    new PropertyChangedEventArgs<PackageDataField, DataField>(this, "DataField", oldValue, DataField),
                    _propertyChangedEventHandler);
            }
            else
            {
                OnPropertyChanged("DataField");
            }
        }

        #endregion // PackageDataField Property Change Events

        #region PackageDataField Abstract Properties

        public abstract PackageBuilderContext Context { get; }

        [DataObjectField(false, false, false)]
        [DataMember]
        public abstract int Priority { get; set; }

        [DataObjectField(false, false, false)]
        [DataMember]
        public abstract string UnifiedName { get; set; }

        [DataObjectField(false, false, false)]
        [DataMember]
        public abstract bool Selected { get; set; }

        [DataObjectField(false, false, false)]
        [DataMember]
        public abstract PackageBuilder.Package Package { get; set; }

        [DataObjectField(false, false, false)]
        [DataMember]
        public abstract DataField DataField { get; set; }

        #endregion // PackageDataField Abstract Properties

        #region PackageDataField ToString Methods

        public override string ToString()
        {
            return ToString(null);
        }

        public virtual string ToString(IFormatProvider provider)
        {
            return string.Format(provider,
                @"PackageDataField{0}{{{0}{1}Priority = ""{2}"",{0}{1}UnifiedName = ""{3}"",{0}{1}Selected = ""{4}"",{0}{1}Package = {5},{0}{1}DataField = {6}{0}}}",
                Environment.NewLine, @"	", Priority, UnifiedName, Selected,
                "TODO: Recursively call ToString for customTypes...",
                "TODO: Recursively call ToString for customTypes...");
        }

        #endregion // PackageDataField ToString Methods
    }
}