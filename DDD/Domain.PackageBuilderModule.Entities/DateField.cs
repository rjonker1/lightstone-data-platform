//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Runtime.Serialization;

#pragma warning disable 1591 // this is for supress no xml comments in public members warnings 

using LightstoneApp.Domain.Core.Entities;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(DataSource))]
    [KnownType(typeof(Industry))]
    [System.CodeDom.Compiler.GeneratedCode("STE-EF",".NET 4.0")]
    #if !SILVERLIGHT
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage()]
    #endif
    public partial class DateField: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int DateFieldId
        {
            get { return _dateFieldId; }
            set
            {
                if (_dateFieldId != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'DateFieldId' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _dateFieldId = value;
                    OnPropertyChanged("DateFieldId");
                }
            }
        }
        private int _dateFieldId;
    
        [DataMember]
        public Nullable<int> DataSourceId
        {
            get { return _dataSourceId; }
            set
            {
                if (_dataSourceId != value)
                {
                    ChangeTracker.RecordOriginalValue("DataSourceId", _dataSourceId);
                    if (!IsDeserializing)
                    {
                        if (DataSource != null && DataSource.DataSourceId != value)
                        {
                            DataSource = null;
                        }
                    }
                    _dataSourceId = value;
                    OnPropertyChanged("DataSourceId");
                }
            }
        }
        private Nullable<int> _dataSourceId;
    
        [DataMember]
        public string Definition
        {
            get { return _definition; }
            set
            {
                if (_definition != value)
                {
                    ChangeTracker.RecordOriginalValue("Definition", _definition);
                    _definition = value;
                    OnPropertyChanged("Definition");
                }
            }
        }
        private string _definition;
    
        [DataMember]
        public string Industry
        {
            get { return _industry; }
            set
            {
                if (_industry != value)
                {
                    ChangeTracker.RecordOriginalValue("Industry", _industry);
                    if (!IsDeserializing)
                    {
                        if (Industry1 != null && Industry1.Value != value)
                        {
                            Industry1 = null;
                        }
                    }
                    _industry = value;
                    OnPropertyChanged("Industry");
                }
            }
        }
        private string _industry;
    
        [DataMember]
        public string Label
        {
            get { return _label; }
            set
            {
                if (_label != value)
                {
                    ChangeTracker.RecordOriginalValue("Label", _label);
                    _label = value;
                    OnPropertyChanged("Label");
                }
            }
        }
        private string _label;
    
        [DataMember]
        public Nullable<bool> Selected
        {
            get { return _selected; }
            set
            {
                if (_selected != value)
                {
                    ChangeTracker.RecordOriginalValue("Selected", _selected);
                    _selected = value;
                    OnPropertyChanged("Selected");
                }
            }
        }
        private Nullable<bool> _selected;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public DataSource DataSource
        {
            get { return _dataSource; }
            set
            {
                if (!ReferenceEquals(_dataSource, value))
                {
                    var previousValue = _dataSource;
                    _dataSource = value;
                    FixupDataSource(previousValue);
                    OnNavigationPropertyChanged("DataSource");
                }
            }
        }
        private DataSource _dataSource;
    
        [DataMember]
        public Industry Industry1
        {
            get { return _industry1; }
            set
            {
                if (!ReferenceEquals(_industry1, value))
                {
                    var previousValue = _industry1;
                    _industry1 = value;
                    FixupIndustry1(previousValue);
                    OnNavigationPropertyChanged("Industry1");
                }
            }
        }
        private Industry _industry1;

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
            DataSource = null;
            Industry1 = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupDataSource(DataSource previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.DateFields.Contains(this))
            {
                previousValue.DateFields.Remove(this);
            }
    
            if (DataSource != null)
            {
                if (!DataSource.DateFields.Contains(this))
                {
                    DataSource.DateFields.Add(this);
                }
    
                DataSourceId = DataSource.DataSourceId;
            }
            else if (!skipKeys)
            {
                DataSourceId = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("DataSource")
                    && (ChangeTracker.OriginalValues["DataSource"] == DataSource))
                {
                    ChangeTracker.OriginalValues.Remove("DataSource");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("DataSource", previousValue);
                }
                if (DataSource != null && !DataSource.ChangeTracker.ChangeTrackingEnabled)
                {
                    DataSource.StartTracking();
                }
            }
        }
    
        private void FixupIndustry1(Industry previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.DateFields.Contains(this))
            {
                previousValue.DateFields.Remove(this);
            }
    
            if (Industry1 != null)
            {
                if (!Industry1.DateFields.Contains(this))
                {
                    Industry1.DateFields.Add(this);
                }
    
                Industry = Industry1.Value;
            }
            else if (!skipKeys)
            {
                Industry = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Industry1")
                    && (ChangeTracker.OriginalValues["Industry1"] == Industry1))
                {
                    ChangeTracker.OriginalValues.Remove("Industry1");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Industry1", previousValue);
                }
                if (Industry1 != null && !Industry1.ChangeTracker.ChangeTrackingEnabled)
                {
                    Industry1.StartTracking();
                }
            }
        }

        #endregion

    }
}
