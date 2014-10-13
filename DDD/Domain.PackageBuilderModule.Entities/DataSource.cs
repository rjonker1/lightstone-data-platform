using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.Serialization;

#pragma warning disable 1591 // this is for supress no xml comments in public members warnings 

using LightstoneApp.Domain.Core.Entities;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(Package))]
    [KnownType(typeof(Owner))]
    [KnownType(typeof(State))]
    [KnownType(typeof(DateField))]
    [KnownType(typeof(FileAttachment))]
    

    public partial class DataSource: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int DataSourceId
        {
            get { return _dataSourceId; }
            set
            {
                if (_dataSourceId != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'DataSourceId' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _dataSourceId = value;
                    OnPropertyChanged("DataSourceId");
                }
            }
        }
        private int _dataSourceId;
    
        [DataMember]
        public Nullable<decimal> CostOfSale
        {
            get { return _costOfSale; }
            set
            {
                if (_costOfSale != value)
                {
                    ChangeTracker.RecordOriginalValue("CostOfSale", _costOfSale);
                    _costOfSale = value;
                    OnPropertyChanged("CostOfSale");
                }
            }
        }
        private Nullable<decimal> _costOfSale;
    
        [DataMember]
        public Nullable<System.DateTime> Created
        {
            get { return _created; }
            set
            {
                if (_created != value)
                {
                    ChangeTracker.RecordOriginalValue("Created", _created);
                    _created = value;
                    OnPropertyChanged("Created");
                }
            }
        }
        private Nullable<System.DateTime> _created;
    
        [DataMember]
        public string DataSourceOwner
        {
            get { return _dataSourceOwner; }
            set
            {
                if (_dataSourceOwner != value)
                {
                    ChangeTracker.RecordOriginalValue("DataSourceOwner", _dataSourceOwner);
                    if (!IsDeserializing)
                    {
                        if (Owner != null && Owner.Value != value)
                        {
                            Owner = null;
                        }
                    }
                    _dataSourceOwner = value;
                    OnPropertyChanged("DataSourceOwner");
                }
            }
        }
        private string _dataSourceOwner;
    
        [DataMember]
        public string DataSourceState
        {
            get { return _dataSourceState; }
            set
            {
                if (_dataSourceState != value)
                {
                    ChangeTracker.RecordOriginalValue("DataSourceState", _dataSourceState);
                    if (!IsDeserializing)
                    {
                        if (State != null && State.Value != value)
                        {
                            State = null;
                        }
                    }
                    _dataSourceState = value;
                    OnPropertyChanged("DataSourceState");
                }
            }
        }
        private string _dataSourceState;
    
        [DataMember]
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    ChangeTracker.RecordOriginalValue("Description", _description);
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        private string _description;
    
        [DataMember]
        public Nullable<System.DateTime> Edited
        {
            get { return _edited; }
            set
            {
                if (_edited != value)
                {
                    ChangeTracker.RecordOriginalValue("Edited", _edited);
                    _edited = value;
                    OnPropertyChanged("Edited");
                }
            }
        }
        private Nullable<System.DateTime> _edited;
    
        [DataMember]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    ChangeTracker.RecordOriginalValue("Name", _name);
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private string _name;
    
        [DataMember]
        public Nullable<int> PackageId
        {
            get { return _packageId; }
            set
            {
                if (_packageId != value)
                {
                    ChangeTracker.RecordOriginalValue("PackageId", _packageId);
                    if (!IsDeserializing)
                    {
                        if (Package != null && Package.PackageId != value)
                        {
                            Package = null;
                        }
                    }
                    _packageId = value;
                    OnPropertyChanged("PackageId");
                }
            }
        }
        private Nullable<int> _packageId;
    
        [DataMember]
        public Nullable<System.DateTime> RevisionDate
        {
            get { return _revisionDate; }
            set
            {
                if (_revisionDate != value)
                {
                    ChangeTracker.RecordOriginalValue("RevisionDate", _revisionDate);
                    _revisionDate = value;
                    OnPropertyChanged("RevisionDate");
                }
            }
        }
        private Nullable<System.DateTime> _revisionDate;
    
        [DataMember]
        public string SourceURL
        {
            get { return _sourceURL; }
            set
            {
                if (_sourceURL != value)
                {
                    ChangeTracker.RecordOriginalValue("SourceURL", _sourceURL);
                    _sourceURL = value;
                    OnPropertyChanged("SourceURL");
                }
            }
        }
        private string _sourceURL;
    
        [DataMember]
        public string Version
        {
            get { return _version; }
            set
            {
                if (_version != value)
                {
                    ChangeTracker.RecordOriginalValue("Version", _version);
                    _version = value;
                    OnPropertyChanged("Version");
                }
            }
        }
        private string _version;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public Package Package
        {
            get { return _package; }
            set
            {
                if (!ReferenceEquals(_package, value))
                {
                    var previousValue = _package;
                    _package = value;
                    FixupPackage(previousValue);
                    OnNavigationPropertyChanged("Package");
                }
            }
        }
        private Package _package;
    
        [DataMember]
        public Owner Owner
        {
            get { return _owner; }
            set
            {
                if (!ReferenceEquals(_owner, value))
                {
                    var previousValue = _owner;
                    _owner = value;
                    FixupOwner(previousValue);
                    OnNavigationPropertyChanged("Owner");
                }
            }
        }
        private Owner _owner;
    
        [DataMember]
        public State State
        {
            get { return _state; }
            set
            {
                if (!ReferenceEquals(_state, value))
                {
                    var previousValue = _state;
                    _state = value;
                    FixupState(previousValue);
                    OnNavigationPropertyChanged("State");
                }
            }
        }
        private State _state;
    
        [DataMember]
        public TrackableCollection<DateField> DateFields
        {
            get
            {
                if (_dateFields == null)
                {
                    _dateFields = new TrackableCollection<DateField>();
                    _dateFields.CollectionChanged += FixupDateFields;
                }
                return _dateFields;
            }
            set
            {
                if (!ReferenceEquals(_dateFields, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_dateFields != null)
                    {
                        _dateFields.CollectionChanged -= FixupDateFields;
                    }
                    _dateFields = value;
                    if (_dateFields != null)
                    {
                        _dateFields.CollectionChanged += FixupDateFields;
                    }
                    OnNavigationPropertyChanged("DateFields");
                }
            }
        }
        private TrackableCollection<DateField> _dateFields;
    
        [DataMember]
        public TrackableCollection<FileAttachment> FileAttachments
        {
            get
            {
                if (_fileAttachments == null)
                {
                    _fileAttachments = new TrackableCollection<FileAttachment>();
                    _fileAttachments.CollectionChanged += FixupFileAttachments;
                }
                return _fileAttachments;
            }
            set
            {
                if (!ReferenceEquals(_fileAttachments, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_fileAttachments != null)
                    {
                        _fileAttachments.CollectionChanged -= FixupFileAttachments;
                    }
                    _fileAttachments = value;
                    if (_fileAttachments != null)
                    {
                        _fileAttachments.CollectionChanged += FixupFileAttachments;
                    }
                    OnNavigationPropertyChanged("FileAttachments");
                }
            }
        }
        private TrackableCollection<FileAttachment> _fileAttachments;

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
            Package = null;
            Owner = null;
            State = null;
            DateFields.Clear();
            FileAttachments.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void FixupPackage(Package previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.DataSources.Contains(this))
            {
                previousValue.DataSources.Remove(this);
            }
    
            if (Package != null)
            {
                if (!Package.DataSources.Contains(this))
                {
                    Package.DataSources.Add(this);
                }
    
                PackageId = Package.PackageId;
            }
            else if (!skipKeys)
            {
                PackageId = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Package")
                    && (ChangeTracker.OriginalValues["Package"] == Package))
                {
                    ChangeTracker.OriginalValues.Remove("Package");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Package", previousValue);
                }
                if (Package != null && !Package.ChangeTracker.ChangeTrackingEnabled)
                {
                    Package.StartTracking();
                }
            }
        }
    
        private void FixupOwner(Owner previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.DataSources.Contains(this))
            {
                previousValue.DataSources.Remove(this);
            }
    
            if (Owner != null)
            {
                if (!Owner.DataSources.Contains(this))
                {
                    Owner.DataSources.Add(this);
                }
    
                DataSourceOwner = Owner.Value;
            }
            else if (!skipKeys)
            {
                DataSourceOwner = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Owner")
                    && (ChangeTracker.OriginalValues["Owner"] == Owner))
                {
                    ChangeTracker.OriginalValues.Remove("Owner");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Owner", previousValue);
                }
                if (Owner != null && !Owner.ChangeTracker.ChangeTrackingEnabled)
                {
                    Owner.StartTracking();
                }
            }
        }
    
        private void FixupState(State previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.DataSources.Contains(this))
            {
                previousValue.DataSources.Remove(this);
            }
    
            if (State != null)
            {
                if (!State.DataSources.Contains(this))
                {
                    State.DataSources.Add(this);
                }
    
                DataSourceState = State.Value;
            }
            else if (!skipKeys)
            {
                DataSourceState = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("State")
                    && (ChangeTracker.OriginalValues["State"] == State))
                {
                    ChangeTracker.OriginalValues.Remove("State");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("State", previousValue);
                }
                if (State != null && !State.ChangeTracker.ChangeTrackingEnabled)
                {
                    State.StartTracking();
                }
            }
        }
    
        private void FixupDateFields(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (DateField item in e.NewItems)
                {
                    item.DataSource = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("DateFields", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (DateField item in e.OldItems)
                {
                    if (ReferenceEquals(item.DataSource, this))
                    {
                        item.DataSource = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("DateFields", item);
                    }
                }
            }
        }
    
        private void FixupFileAttachments(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (FileAttachment item in e.NewItems)
                {
                    item.DataSource = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("FileAttachments", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (FileAttachment item in e.OldItems)
                {
                    if (ReferenceEquals(item.DataSource, this))
                    {
                        item.DataSource = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("FileAttachments", item);
                    }
                }
            }
        }

        #endregion

    }
}
