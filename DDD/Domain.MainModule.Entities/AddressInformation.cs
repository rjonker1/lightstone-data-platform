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
    [System.CodeDom.Compiler.GeneratedCode("STE-EF",".NET 4.0")]

    public partial class AddressInformation : INotifyComplexPropertyChanging, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public string Fax
        {
            get { return _fax; }
            set
            {
                if (_fax != value)
                {
                    OnComplexPropertyChanging();
                    _fax = value;
                    OnPropertyChanged("Fax");
                }
            }
        }
        private string _fax;
    
        [DataMember]
        public string Telephone
        {
            get { return _telephone; }
            set
            {
                if (_telephone != value)
                {
                    OnComplexPropertyChanging();
                    _telephone = value;
                    OnPropertyChanged("Telephone");
                }
            }
        }
        private string _telephone;
    
        [DataMember]
        public string PostalCode
        {
            get { return _postalCode; }
            set
            {
                if (_postalCode != value)
                {
                    OnComplexPropertyChanging();
                    _postalCode = value;
                    OnPropertyChanged("PostalCode");
                }
            }
        }
        private string _postalCode;
    
        [DataMember]
        public string City
        {
            get { return _city; }
            set
            {
                if (_city != value)
                {
                    OnComplexPropertyChanging();
                    _city = value;
                    OnPropertyChanged("City");
                }
            }
        }
        private string _city;
    
        [DataMember]
        public string Address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    OnComplexPropertyChanging();
                    _address = value;
                    OnPropertyChanged("Address");
                }
            }
        }
        private string _address;

        #endregion
        #region ChangeTracking
    
        private void OnComplexPropertyChanging()
        {
            if (_complexPropertyChanging != null)
            {
                _complexPropertyChanging(this, new EventArgs());
            }
        }
    
        event EventHandler INotifyComplexPropertyChanging.ComplexPropertyChanging { add { _complexPropertyChanging += value; } remove { _complexPropertyChanging -= value; } }
        private event EventHandler _complexPropertyChanging;
    
        private void OnPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged { add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
    
        public static void RecordComplexOriginalValues(String parentPropertyName, AddressInformation complexObject, ObjectChangeTracker changeTracker)
        {
            if (String.IsNullOrEmpty(parentPropertyName))
            {
                throw new ArgumentException("String parameter cannot be null or empty.", "parentPropertyName");
            }
    
            if (changeTracker == null)
            {
                throw new ArgumentNullException("changeTracker");
            }
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.Fax", parentPropertyName), complexObject == null ? null : (object)complexObject.Fax);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.Telephone", parentPropertyName), complexObject == null ? null : (object)complexObject.Telephone);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.PostalCode", parentPropertyName), complexObject == null ? null : (object)complexObject.PostalCode);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.City", parentPropertyName), complexObject == null ? null : (object)complexObject.City);
            changeTracker.RecordOriginalValue(String.Format(CultureInfo.InvariantCulture, "{0}.Address", parentPropertyName), complexObject == null ? null : (object)complexObject.Address);
        }

        #endregion
    }
}
