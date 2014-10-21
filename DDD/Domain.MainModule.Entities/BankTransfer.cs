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
    [KnownType(typeof(BankAccount))]
    [System.CodeDom.Compiler.GeneratedCode("STE-EF",".NET 4.0")]

    public partial class BankTransfer: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int BankTransferId
        {
            get { return _bankTransferId; }
            set
            {
                if (_bankTransferId != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'BankTransferId' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _bankTransferId = value;
                    OnPropertyChanged("BankTransferId");
                }
            }
        }
        private int _bankTransferId;
    
        [DataMember]
        public int FromBankAccountId
        {
            get { return _fromBankAccountId; }
            set
            {
                if (_fromBankAccountId != value)
                {
                    ChangeTracker.RecordOriginalValue("FromBankAccountId", _fromBankAccountId);
                    if (!IsDeserializing)
                    {
                        if (BankAccount != null && BankAccount.BankAccountId != value)
                        {
                            BankAccount = null;
                        }
                    }
                    _fromBankAccountId = value;
                    OnPropertyChanged("FromBankAccountId");
                }
            }
        }
        private int _fromBankAccountId;
    
        [DataMember]
        public int ToBankAccountId
        {
            get { return _toBankAccountId; }
            set
            {
                if (_toBankAccountId != value)
                {
                    ChangeTracker.RecordOriginalValue("ToBankAccountId", _toBankAccountId);
                    if (!IsDeserializing)
                    {
                        if (BankAccount1 != null && BankAccount1.BankAccountId != value)
                        {
                            BankAccount1 = null;
                        }
                    }
                    _toBankAccountId = value;
                    OnPropertyChanged("ToBankAccountId");
                }
            }
        }
        private int _toBankAccountId;
    
        [DataMember]
        public decimal Amount
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
        private decimal _amount;
    
        [DataMember]
        public System.DateTime TransferDate
        {
            get { return _transferDate; }
            set
            {
                if (_transferDate != value)
                {
                    _transferDate = value;
                    OnPropertyChanged("TransferDate");
                }
            }
        }
        private System.DateTime _transferDate;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public BankAccount BankAccount
        {
            get { return _bankAccount; }
            set
            {
                if (!ReferenceEquals(_bankAccount, value))
                {
                    var previousValue = _bankAccount;
                    _bankAccount = value;
                    FixupBankAccount(previousValue);
                    OnNavigationPropertyChanged("BankAccount");
                }
            }
        }
        private BankAccount _bankAccount;
    
        [DataMember]
        public BankAccount BankAccount1
        {
            get { return _bankAccount1; }
            set
            {
                if (!ReferenceEquals(_bankAccount1, value))
                {
                    var previousValue = _bankAccount1;
                    _bankAccount1 = value;
                    FixupBankAccount1(previousValue);
                    OnNavigationPropertyChanged("BankAccount1");
                }
            }
        }
        private BankAccount _bankAccount1;

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
            BankAccount = null;
            BankAccount1 = null;
        }

        #endregion
        #region Association Fixup
    
        private void FixupBankAccount(BankAccount previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.BankTransfersFromThis.Contains(this))
            {
                previousValue.BankTransfersFromThis.Remove(this);
            }
    
            if (BankAccount != null)
            {
                if (!BankAccount.BankTransfersFromThis.Contains(this))
                {
                    BankAccount.BankTransfersFromThis.Add(this);
                }
    
                FromBankAccountId = BankAccount.BankAccountId;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("BankAccount")
                    && (ChangeTracker.OriginalValues["BankAccount"] == BankAccount))
                {
                    ChangeTracker.OriginalValues.Remove("BankAccount");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("BankAccount", previousValue);
                }
                if (BankAccount != null && !BankAccount.ChangeTracker.ChangeTrackingEnabled)
                {
                    BankAccount.StartTracking();
                }
            }
        }
    
        private void FixupBankAccount1(BankAccount previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.BankTransfersToThis.Contains(this))
            {
                previousValue.BankTransfersToThis.Remove(this);
            }
    
            if (BankAccount1 != null)
            {
                if (!BankAccount1.BankTransfersToThis.Contains(this))
                {
                    BankAccount1.BankTransfersToThis.Add(this);
                }
    
                ToBankAccountId = BankAccount1.BankAccountId;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("BankAccount1")
                    && (ChangeTracker.OriginalValues["BankAccount1"] == BankAccount1))
                {
                    ChangeTracker.OriginalValues.Remove("BankAccount1");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("BankAccount1", previousValue);
                }
                if (BankAccount1 != null && !BankAccount1.ChangeTracker.ChangeTrackingEnabled)
                {
                    BankAccount1.StartTracking();
                }
            }
        }

        #endregion
    }
}