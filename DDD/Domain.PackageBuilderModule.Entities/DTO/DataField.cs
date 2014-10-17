using System;
using System.Collections.Generic;
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
    public abstract class DataField : ValueObject<DataField>, INotifyPropertyChanged, IHasPackageBuilderContext
    {
        #region DataField INotifyPropertyChanged Implementation

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

        #endregion // DataField INotifyPropertyChanged Implementation

        #region DataField Property Change Events

        private Delegate[] _events;

        private Delegate[] Events
        {
            get
            {
                Delegate[] localEvents;
                return (localEvents = _events) ??
                       Interlocked.CompareExchange(ref _events, localEvents = new Delegate[14], null) ?? localEvents;
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

        public event EventHandler<PropertyChangingEventArgs<DataField, string>> LabelChanging
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

        protected bool OnLabelChanging(string newValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangingEventArgs<DataField, string>> eventHandler;
            if ((events = _events) != null &&
                (object) (eventHandler = (EventHandler<PropertyChangingEventArgs<DataField, string>>) events[0]) !=
                null)
            {
                return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                    new PropertyChangingEventArgs<DataField, string>(this, "Label", Label, newValue));
            }
            return true;
        }

        public event EventHandler<PropertyChangedEventArgs<DataField, string>> LabelChanged
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

        protected void OnLabelChanged(string oldValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangedEventArgs<DataField, string>> eventHandler;
            if ((events = _events) != null &&
                (object) (eventHandler = (EventHandler<PropertyChangedEventArgs<DataField, string>>) events[1]) !=
                null)
            {
                EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                    new PropertyChangedEventArgs<DataField, string>(this, "Label", oldValue, Label),
                    _propertyChangedEventHandler);
            }
            else
            {
                OnPropertyChanged("Label");
            }
        }

        public event EventHandler<PropertyChangingEventArgs<DataField, string>> TypeDefinitionChanging
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

        protected bool OnTypeDefinitionChanging(string newValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangingEventArgs<DataField, string>> eventHandler;
            if ((events = _events) != null &&
                (object) (eventHandler = (EventHandler<PropertyChangingEventArgs<DataField, string>>) events[2]) !=
                null)
            {
                return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                    new PropertyChangingEventArgs<DataField, string>(this, "TypeDefinition", TypeDefinition,
                        newValue));
            }
            return true;
        }

        public event EventHandler<PropertyChangedEventArgs<DataField, string>> TypeDefinitionChanged
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

        protected void OnTypeDefinitionChanged(string oldValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangedEventArgs<DataField, string>> eventHandler;
            if ((events = _events) != null &&
                (object) (eventHandler = (EventHandler<PropertyChangedEventArgs<DataField, string>>) events[3]) !=
                null)
            {
                EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                    new PropertyChangedEventArgs<DataField, string>(this, "TypeDefinition", oldValue, TypeDefinition),
                    _propertyChangedEventHandler);
            }
            else
            {
                OnPropertyChanged("TypeDefinition");
            }
        }

        public event EventHandler<PropertyChangingEventArgs<DataField, bool>> SelectedChanging
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
            EventHandler<PropertyChangingEventArgs<DataField, bool>> eventHandler;
            if ((events = _events) != null &&
                (object) (eventHandler = (EventHandler<PropertyChangingEventArgs<DataField, bool>>) events[4]) !=
                null)
            {
                return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                    new PropertyChangingEventArgs<DataField, bool>(this, "Selected", Selected, newValue));
            }
            return true;
        }

        public event EventHandler<PropertyChangedEventArgs<DataField, bool>> SelectedChanged
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
            EventHandler<PropertyChangedEventArgs<DataField, bool>> eventHandler;
            if ((events = _events) != null &&
                (object) (eventHandler = (EventHandler<PropertyChangedEventArgs<DataField, bool>>) events[5]) !=
                null)
            {
                EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                    new PropertyChangedEventArgs<DataField, bool>(this, "Selected", oldValue, Selected),
                    _propertyChangedEventHandler);
            }
            else
            {
                OnPropertyChanged("Selected");
            }
        }

        public event EventHandler<PropertyChangingEventArgs<DataField, decimal>> CostOfSaleChanging
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

        protected bool OnCostOfSaleChanging(decimal newValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangingEventArgs<DataField, decimal>> eventHandler;
            if ((events = _events) != null &&
                (object) (eventHandler = (EventHandler<PropertyChangingEventArgs<DataField, decimal>>) events[6]) !=
                null)
            {
                return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                    new PropertyChangingEventArgs<DataField, decimal>(this, "CostOfSale", CostOfSale, newValue));
            }
            return true;
        }

        public event EventHandler<PropertyChangedEventArgs<DataField, decimal>> CostOfSaleChanged
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

        protected void OnCostOfSaleChanged(decimal oldValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangedEventArgs<DataField, decimal>> eventHandler;
            if ((events = _events) != null &&
                (object) (eventHandler = (EventHandler<PropertyChangedEventArgs<DataField, decimal>>) events[7]) !=
                null)
            {
                EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                    new PropertyChangedEventArgs<DataField, decimal>(this, "CostOfSale", oldValue, CostOfSale),
                    _propertyChangedEventHandler);
            }
            else
            {
                OnPropertyChanged("CostOfSale");
            }
        }

        public event EventHandler<PropertyChangingEventArgs<DataField, string>> NameChanging
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

        protected bool OnNameChanging(string newValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangingEventArgs<DataField, string>> eventHandler;
            if ((events = _events) != null &&
                (object) (eventHandler = (EventHandler<PropertyChangingEventArgs<DataField, string>>) events[8]) !=
                null)
            {
                return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                    new PropertyChangingEventArgs<DataField, string>(this, "Name", Name, newValue));
            }
            return true;
        }

        public event EventHandler<PropertyChangedEventArgs<DataField, string>> NameChanged
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

        protected void OnNameChanged(string oldValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangedEventArgs<DataField, string>> eventHandler;
            if ((events = _events) != null &&
                (object) (eventHandler = (EventHandler<PropertyChangedEventArgs<DataField, string>>) events[9]) !=
                null)
            {
                EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                    new PropertyChangedEventArgs<DataField, string>(this, "Name", oldValue, Name),
                    _propertyChangedEventHandler);
            }
            else
            {
                OnPropertyChanged("Name");
            }
        }

        public event EventHandler<PropertyChangingEventArgs<DataField, DataProvider>> DataProviderChanging
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

        protected bool OnDataProviderChanging(DataProvider newValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangingEventArgs<DataField, DataProvider>> eventHandler;
            if ((events = _events) != null &&
                (object)
                    (eventHandler = (EventHandler<PropertyChangingEventArgs<DataField, DataProvider>>) events[10]) !=
                null)
            {
                return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                    new PropertyChangingEventArgs<DataField, DataProvider>(this, "DataProvider", DataProvider,
                        newValue));
            }
            return true;
        }

        public event EventHandler<PropertyChangedEventArgs<DataField, DataProvider>> DataProviderChanged
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

        protected void OnDataProviderChanged(DataProvider oldValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangedEventArgs<DataField, DataProvider>> eventHandler;
            if ((events = _events) != null &&
                (object)
                    (eventHandler = (EventHandler<PropertyChangedEventArgs<DataField, DataProvider>>) events[11]) !=
                null)
            {
                EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                    new PropertyChangedEventArgs<DataField, DataProvider>(this, "DataProvider", oldValue,
                        DataProvider), _propertyChangedEventHandler);
            }
            else
            {
                OnPropertyChanged("DataProvider");
            }
        }

        public event EventHandler<PropertyChangingEventArgs<DataField, Industry>> IndustryChanging
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

        protected bool OnIndustryChanging(Industry newValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangingEventArgs<DataField, Industry>> eventHandler;
            if ((events = _events) != null &&
                (object) (eventHandler = (EventHandler<PropertyChangingEventArgs<DataField, Industry>>) events[12]) !=
                null)
            {
                return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                    new PropertyChangingEventArgs<DataField, Industry>(this, "Industry", Industry, newValue));
            }
            return true;
        }

        public event EventHandler<PropertyChangedEventArgs<DataField, Industry>> IndustryChanged
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

        protected void OnIndustryChanged(Industry oldValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangedEventArgs<DataField, Industry>> eventHandler;
            if ((events = _events) != null &&
                (object) (eventHandler = (EventHandler<PropertyChangedEventArgs<DataField, Industry>>) events[13]) !=
                null)
            {
                EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                    new PropertyChangedEventArgs<DataField, Industry>(this, "Industry", oldValue, Industry),
                    _propertyChangedEventHandler);
            }
            else
            {
                OnPropertyChanged("Industry");
            }
        }

        #endregion // DataField Property Change Events

        #region DataField Abstract Properties

        public abstract PackageBuilderContext Context { get; }

        [DataObjectField(false, false, true)]
        [DataMember]
        public abstract string Label { get; set; }

        [DataObjectField(false, false, true)]
        [DataMember]
        public abstract string TypeDefinition { get; set; }

        [DataObjectField(false, false, false)]
        [DataMember]
        public abstract bool Selected { get; set; }

        [DataObjectField(false, false, false)]
        [DataMember]
        public abstract decimal CostOfSale { get; set; }

        [DataObjectField(false, false, false)]
        [DataMember]
        public abstract string Name { get; set; }

        [DataObjectField(false, false, false)]
        [DataMember]
        public abstract DataProvider DataProvider { get; set; }

        [DataObjectField(false, false, false)]
        [DataMember]
        public abstract Industry Industry { get; set; }

        [DataObjectField(false, false, true)]
        [DataMember]
        public abstract IEnumerable<PackageDataField> PackageDataFieldViaDataFieldCollection { get; }

        #endregion // DataField Abstract Properties

        #region DataField ToString Methods

        public override string ToString()
        {
            return ToString(null);
        }

        public virtual string ToString(IFormatProvider provider)
        {
            return string.Format(provider,
                @"DataField{0}{{{0}{1}Label = ""{2}"",{0}{1}TypeDefinition = ""{3}"",{0}{1}Selected = ""{4}"",{0}{1}CostOfSale = ""{5}"",{0}{1}Name = ""{6}"",{0}{1}DataProvider = {7},{0}{1}Industry = {8}{0}}}",
                Environment.NewLine, @"	", Label, TypeDefinition, Selected, CostOfSale, Name,
                "TODO: Recursively call ToString for customTypes...",
                "TODO: Recursively call ToString for customTypes...");
        }

        #endregion // DataField ToString Methods
    }
}