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
    [KnownType(typeof(Book))]
    [KnownType(typeof(Software))]
    [KnownType(typeof(OrderDetail))]
    [System.CodeDom.Compiler.GeneratedCode("STE-EF",".NET 4.0")]

    public partial class Product: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int ProductId
        {
            get { return _productId; }
            set
            {
                if (_productId != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'ProductId' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _productId = value;
                    OnPropertyChanged("ProductId");
                }
            }
        }
        private int _productId;
    
        [DataMember]
        public string ProductDescription
        {
            get { return _productDescription; }
            set
            {
                if (_productDescription != value)
                {
                    _productDescription = value;
                    OnPropertyChanged("ProductDescription");
                }
            }
        }
        private string _productDescription;
    
        [DataMember]
        public Nullable<decimal> UnitPrice
        {
            get { return _unitPrice; }
            set
            {
                if (_unitPrice != value)
                {
                    _unitPrice = value;
                    OnPropertyChanged("UnitPrice");
                }
            }
        }
        private Nullable<decimal> _unitPrice;
    
        [DataMember]
        public string UnitAmount
        {
            get { return _unitAmount; }
            set
            {
                if (_unitAmount != value)
                {
                    _unitAmount = value;
                    OnPropertyChanged("UnitAmount");
                }
            }
        }
        private string _unitAmount;
    
        [DataMember]
        public string Publisher
        {
            get { return _publisher; }
            set
            {
                if (_publisher != value)
                {
                    _publisher = value;
                    OnPropertyChanged("Publisher");
                }
            }
        }
        private string _publisher;
    
        [DataMember]
        public Nullable<short> AmountInStock
        {
            get { return _amountInStock; }
            set
            {
                if (_amountInStock != value)
                {
                    _amountInStock = value;
                    OnPropertyChanged("AmountInStock");
                }
            }
        }
        private Nullable<short> _amountInStock;

        #endregion
        #region Navigation Properties
    
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
            OrderDetails.Clear();
        }

        #endregion
        #region Association Fixup
    
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
                    item.Product = this;
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
                    if (ReferenceEquals(item.Product, this))
                    {
                        item.Product = null;
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
