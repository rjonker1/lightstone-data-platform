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
    [KnownType(typeof(BankTransfer))]
    [System.CodeDom.Compiler.GeneratedCode("STE-EF",".NET 4.0")]

    public partial class BankAccount: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int BankAccountId
        {
            get { return _bankAccountId; }
            set
            {
                if (_bankAccountId != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'BankAccountId' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _bankAccountId = value;
                    OnPropertyChanged("BankAccountId");
                }
            }
        }
        private int _bankAccountId;
    
        [DataMember]
        public string BankAccountNumber
        {
            get { return _bankAccountNumber; }
            set
            {
                if (_bankAccountNumber != value)
                {
                    _bankAccountNumber = value;
                    OnPropertyChanged("BankAccountNumber");
                }
            }
        }
        private string _bankAccountNumber;
    
        [DataMember]
        public decimal Balance
        {
            get { return _balance; }
            set
            {
                if (_balance != value)
                {
                    ChangeTracker.RecordOriginalValue("Balance", _balance);
                    _balance = value;
                    OnPropertyChanged("Balance");
                }
            }
        }
        private decimal _balance;
    
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
        public bool Locked
        {
            get { return _locked; }
            set
            {
                if (_locked != value)
                {
                    _locked = value;
                    OnPropertyChanged("Locked");
                }
            }
        }
        private bool _locked;

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
        public TrackableCollection<BankTransfer> BankTransfersFromThis
        {
            get
            {
                if (_bankTransfersFromThis == null)
                {
                    _bankTransfersFromThis = new TrackableCollection<BankTransfer>();
                    _bankTransfersFromThis.CollectionChanged += FixupBankTransfersFromThis;
                }
                return _bankTransfersFromThis;
            }
            set
            {
                if (!ReferenceEquals(_bankTransfersFromThis, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_bankTransfersFromThis != null)
                    {
                        _bankTransfersFromThis.CollectionChanged -= FixupBankTransfersFromThis;
                    }
                    _bankTransfersFromThis = value;
                    if (_bankTransfersFromThis != null)
                    {
                        _bankTransfersFromThis.CollectionChanged += FixupBankTransfersFromThis;
                    }
                    OnNavigationPropertyChanged("BankTransfersFromThis");
                }
            }
        }
        private TrackableCollection<BankTransfer> _bankTransfersFromThis;
    
        [DataMember]
        public TrackableCollection<BankTransfer> BankTransfersToThis
        {
            get
            {
                if (_bankTransfersToThis == null)
                {
                    _bankTransfersToThis = new TrackableCollection<BankTransfer>();
                    _bankTransfersToThis.CollectionChanged += FixupBankTransfersToThis;
                }
                return _bankTransfersToThis;
            }
            set
            {
                if (!ReferenceEquals(_bankTransfersToThis, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_bankTransfersToThis != null)
                    {
                        _bankTransfersToThis.CollectionChanged -= FixupBankTransfersToThis;
                    }
                    _bankTransfersToThis = value;
                    if (_bankTransfersToThis != null)
                    {
                        _bankTransfersToThis.CollectionChanged += FixupBankTransfersToThis;
                    }
                    OnNavigationPropertyChanged("BankTransfersToThis");
                }
            }
        }
        private TrackableCollection<BankTransfer> _bankTransfersToThis;

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
            BankTransfersFromThis.Clear();
            BankTransfersToThis.Clear();
        }

        #endregion
        #region Association Fixup
    
        private void FixupCustomer(Customer previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.BankAccounts.Contains(this))
            {
                previousValue.BankAccounts.Remove(this);
            }
    
            if (Customer != null)
            {
                if (!Customer.BankAccounts.Contains(this))
                {
                    Customer.BankAccounts.Add(this);
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
    
        private void FixupBankTransfersFromThis(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (BankTransfer item in e.NewItems)
                {
                    item.BankAccount = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("BankTransfersFromThis", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (BankTransfer item in e.OldItems)
                {
                    if (ReferenceEquals(item.BankAccount, this))
                    {
                        item.BankAccount = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("BankTransfersFromThis", item);
                    }
                }
            }
        }
    
        private void FixupBankTransfersToThis(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (BankTransfer item in e.NewItems)
                {
                    item.BankAccount1 = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("BankTransfersToThis", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (BankTransfer item in e.OldItems)
                {
                    if (ReferenceEquals(item.BankAccount1, this))
                    {
                        item.BankAccount1 = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("BankTransfersToThis", item);
                    }
                }
            }
        }

        #endregion
    }
}
