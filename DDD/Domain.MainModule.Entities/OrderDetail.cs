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
    [KnownType(typeof(Order))]
    [KnownType(typeof(Product))]
    [System.CodeDom.Compiler.GeneratedCode("STE-EF",".NET 4.0")]

    public partial class OrderDetail: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int OrderDetailsId
        {
            get { return _orderDetailsId; }
            set
            {
                if (_orderDetailsId != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'OrderDetailsId' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _orderDetailsId = value;
                    OnPropertyChanged("OrderDetailsId");
                }
            }
        }
        private int _orderDetailsId;
    
        [DataMember]
        public int OrderId
        {
            get { return _orderId; }
            set
            {
                if (_orderId != value)
                {
                    ChangeTracker.RecordOriginalValue("OrderId", _orderId);
                    if (!IsDeserializing)
                    {
                        if (Order != null && Order.OrderId != value)
                        {
                            Order = null;
                        }
                    }
                    _orderId = value;
                    OnPropertyChanged("OrderId");
                }
            }
        }
        private int _orderId;
    
        [DataMember]
        public int ProductId
        {
            get { return _productId; }
            set
            {
                if (_productId != value)
                {
                    ChangeTracker.RecordOriginalValue("ProductId", _productId);
                    if (!IsDeserializing)
                    {
                        if (Product != null && Product.ProductId != value)
                        {
                            Product = null;
                        }
                    }
                    _productId = value;
                    OnPropertyChanged("ProductId");
                }
            }
        }
        private int _productId;
    
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
        public Nullable<short> Amount
        {
            get { return _amount; }
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    OnPropertyChanged("Amount");
                }
            }
        }
        private Nullable<short> _amount;
    
        [DataMember]
        public Nullable<float> Discount
        {
            get { return _discount; }
            set
            {
                if (_discount != value)
                {
                    _discount = value;
                    OnPropertyChanged("Discount");
                }
            }
        }
        private Nullable<float> _discount;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public Order Order
        {
            get { return _order; }
            set
            {
                if (!ReferenceEquals(_order, value))
                {
                    var previousValue = _order;
                    _order = value;
                    FixupOrder(previousValue);
                    OnNavigationPropertyChanged("Order");
                }
            }
        }
        private Order _order;
    
        [DataMember]
        public Product Product
        {
            get { return _product; }
            set
            {
                if (!ReferenceEquals(_product, value))
                {
                    var previousValue = _product;
                    _product = value;
                    FixupProduct(previousValue);
                    OnNavigationPropertyChanged("Product");
                }
            }
        }
        private Product _product;

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
            Order = null;
            Product = null;
        }

        #endregion
        #region Association Fixup
    
        private void FixupOrder(Order previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.OrderDetails.Contains(this))
            {
                previousValue.OrderDetails.Remove(this);
            }
    
            if (Order != null)
            {
                if (!Order.OrderDetails.Contains(this))
                {
                    Order.OrderDetails.Add(this);
                }
    
                OrderId = Order.OrderId;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Order")
                    && (ChangeTracker.OriginalValues["Order"] == Order))
                {
                    ChangeTracker.OriginalValues.Remove("Order");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Order", previousValue);
                }
                if (Order != null && !Order.ChangeTracker.ChangeTrackingEnabled)
                {
                    Order.StartTracking();
                }
            }
        }
    
        private void FixupProduct(Product previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.OrderDetails.Contains(this))
            {
                previousValue.OrderDetails.Remove(this);
            }
    
            if (Product != null)
            {
                if (!Product.OrderDetails.Contains(this))
                {
                    Product.OrderDetails.Add(this);
                }
    
                ProductId = Product.ProductId;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Product")
                    && (ChangeTracker.OriginalValues["Product"] == Product))
                {
                    ChangeTracker.OriginalValues.Remove("Product");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Product", previousValue);
                }
                if (Product != null && !Product.ChangeTracker.ChangeTrackingEnabled)
                {
                    Product.StartTracking();
                }
            }
        }

        #endregion
    }
}
