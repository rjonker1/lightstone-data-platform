using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

#pragma warning disable 1591 // this is for supress no xml comments in public members warnings 

using LightstoneApp.Domain.Core.Entities;

namespace LightstoneApp.Domain.MainModule.Entities
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(Customer))]
    [KnownType(typeof(OrderDetail))]
    [System.CodeDom.Compiler.GeneratedCode("STE-EF",".NET 4.0")]

    public partial class Order: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int OrderId
        {
            get { return _orderId; }
            set
            {
                if (_orderId != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'OrderId' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _orderId = value;
                    OnPropertyChanged("OrderId");
                }
            }
        }
        private int _orderId;
    
        [DataMember]
        public Nullable<int> CustomerId
        {
            get { return _customerId; }
            set
            {
                if (_customerId != value)
                {
                    ChangeTracker.RecordOriginalValue("CustomerId", _customerId);
                    if (!IsDeserializing)
                    {
                        if (Customer != null && Customer.CustomerId != value)
                        {
                            Customer = null;
                        }
                    }
                    _customerId = value;
                    OnPropertyChanged("CustomerId");
                }
            }
        }
        private Nullable<int> _customerId;
    
        [DataMember]
        public Nullable<System.DateTime> OrderDate
        {
            get { return _orderDate; }
            set
            {
                if (_orderDate != value)
                {
                    _orderDate = value;
                    OnPropertyChanged("OrderDate");
                }
            }
        }
        private Nullable<System.DateTime> _orderDate;
    
        [DataMember]
        public Nullable<System.DateTime> DeliveryDate
        {
            get { return _deliveryDate; }
            set
            {
                if (_deliveryDate != value)
                {
                    _deliveryDate = value;
                    OnPropertyChanged("DeliveryDate");
                }
            }
        }
        private Nullable<System.DateTime> _deliveryDate;
    
        [DataMember]
        public string ShippingName
        {
            get { return _shippingName; }
            set
            {
                if (_shippingName != value)
                {
                    _shippingName = value;
                    OnPropertyChanged("ShippingName");
                }
            }
        }
        private string _shippingName;
    
        [DataMember]
        public string ShippingAddress
        {
            get { return _shippingAddress; }
            set
            {
                if (_shippingAddress != value)
                {
                    _shippingAddress = value;
                    OnPropertyChanged("ShippingAddress");
                }
            }
        }
        private string _shippingAddress;
    
        [DataMember]
        public string ShippingCity
        {
            get { return _shippingCity; }
            set
            {
                if (_shippingCity != value)
                {
                    _shippingCity = value;
                    OnPropertyChanged("ShippingCity");
                }
            }
        }
        private string _shippingCity;
    
        [DataMember]
        public string ShippingZip
        {
            get { return _shippingZip; }
            set
            {
                if (_shippingZip != value)
                {
                    _shippingZip = value;
                    OnPropertyChanged("ShippingZip");
                }
            }
        }
        private string _shippingZip;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public Customer Customer
        {
            get { return _customer; }
            set
            {
                if (!ReferenceEquals(_customer, value))
                {
                    var previousValue = _customer;
                    _customer = value;
                    FixupCustomer(previousValue);
                    OnNavigationPropertyChanged("Customer");
                }
            }
        }
        private Customer _customer;
    
        [DataMember]
        public TrackableCollection<OrderDetail> OrderDetails
        {
            get
            {
                if (_orderDetails == null)
                {
                    _orderDetails = new TrackableCollection<OrderDetail>();
                    _orderDetails.CollectionChanged += FixupOrderDetails;
                }
                return _orderDetails;
            }
            set
            {
                if (!ReferenceEquals(_orderDetails, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_orderDetails != null)
                    {
                        _orderDetails.CollectionChanged -= FixupOrderDetails;
                    }
                    _orderDetails = value;
                    if (_orderDetails != null)
                    {
                        _orderDetails.CollectionChanged += FixupOrderDetails;
                    }
                    OnNavigationPropertyChanged("OrderDetails");
                }
            }
        }
        private TrackableCollection<OrderDetail> _orderDetails;

        #endregion
        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        protected virtual void ClearNavigationProperties()
        {
            Customer = null;
            OrderDetails.Clear();
        }

        #endregion
        #region Association Fixup
    
        private void FixupCustomer(Customer previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Orders.Contains(this))
            {
                previousValue.Orders.Remove(this);
            }
    
            if (Customer != null)
            {
                if (!Customer.Orders.Contains(this))
                {
                    Customer.Orders.Add(this);
                }
    
                CustomerId = Customer.CustomerId;
            }
            else if (!skipKeys)
            {
                CustomerId = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Customer")
                    && (ChangeTracker.OriginalValues["Customer"] == Customer))
                {
                    ChangeTracker.OriginalValues.Remove("Customer");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Customer", previousValue);
                }
                if (Customer != null && !Customer.ChangeTracker.ChangeTrackingEnabled)
                {
                    Customer.StartTracking();
                }
            }
        }
    
        private void FixupOrderDetails(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (OrderDetail item in e.NewItems)
                {
                    item.Order = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("OrderDetails", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (OrderDetail item in e.OldItems)
                {
                    if (ReferenceEquals(item.Order, this))
                    {
                        item.Order = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("OrderDetails", item);
                    }
                }
            }
        }

        #endregion
    }
}
