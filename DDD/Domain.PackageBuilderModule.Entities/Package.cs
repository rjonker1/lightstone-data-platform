using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.Serialization;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
#pragma warning disable 1591 // this is for supress no xml comments in public members warnings 

using LightstoneApp.Domain.Core.Entities;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(DataSource))]
    [KnownType(typeof(Industry))]
    [KnownType(typeof(Owner))]
    [KnownType(typeof(State))]
    

    public partial class Package: Entity,  IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int PackageId
        {
            get { return _packageId; }
            set
            {
                if (_packageId != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'PackageId' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _packageId = value;
                    OnPropertyChanged("PackageId");
                }
            }
        }
        private int _packageId;
    
        [DataMember]
        public decimal? CostOfSale
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
        private decimal? _costOfSale;
    
        [DataMember]
        public DateTime? Created
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
        private DateTime? _created;
    
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
        public DateTime? Edited
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
        private DateTime? _edited;
    
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
        public string PackageIndustry
        {
            get { return _packageIndustry; }
            set
            {
                if (_packageIndustry != value)
                {
                    ChangeTracker.RecordOriginalValue("PackageIndustry", _packageIndustry);
                    if (!IsDeserializing)
                    {
                        if (Industry != null && Industry.Value != value)
                        {
                            Industry = null;
                        }
                    }
                    _packageIndustry = value;
                    OnPropertyChanged("PackageIndustry");
                }
            }
        }
        private string _packageIndustry;
    
        [DataMember]
        public string PackageOwner
        {
            get { return _packageOwner; }
            set
            {
                if (_packageOwner != value)
                {
                    ChangeTracker.RecordOriginalValue("PackageOwner", _packageOwner);
                    if (!IsDeserializing)
                    {
                        if (Owner != null && Owner.Value != value)
                        {
                            Owner = null;
                        }
                    }
                    _packageOwner = value;
                    OnPropertyChanged("PackageOwner");
                }
            }
        }
        private string _packageOwner;
    
        [DataMember]
        public string PackageState
        {
            get { return _packageState; }
            set
            {
                if (_packageState != value)
                {
                    ChangeTracker.RecordOriginalValue("PackageState", _packageState);
                    if (!IsDeserializing)
                    {
                        if (State != null && State.Value != value)
                        {
                            State = null;
                        }
                    }
                    _packageState = value;
                    OnPropertyChanged("PackageState");
                }
            }
        }
        private string _packageState;
    
        [DataMember]
        public bool? Published
        {
            get { return _published; }
            set
            {
                if (_published != value)
                {
                    ChangeTracker.RecordOriginalValue("Published", _published);
                    _published = value;
                    OnPropertyChanged("Published");
                }
            }
        }
        private bool? _published;
    
        [DataMember]
        public DateTime? RevisionDate
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
        private DateTime? _revisionDate;
    
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
        public TrackableCollection<DataSource> DataSources
        {
            get
            {
                if (_dataSources == null)
                {
                    _dataSources = new TrackableCollection<DataSource>();
                    _dataSources.CollectionChanged += FixupDataSources;
                }
                return _dataSources;
            }
            set
            {
                if (!ReferenceEquals(_dataSources, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_dataSources != null)
                    {
                        _dataSources.CollectionChanged -= FixupDataSources;
                    }
                    _dataSources = value;
                    if (_dataSources != null)
                    {
                        _dataSources.CollectionChanged += FixupDataSources;
                    }
                    OnNavigationPropertyChanged("DataSources");
                }
            }
        }
        private TrackableCollection<DataSource> _dataSources;
    
        [DataMember]
        public Industry Industry
        {
            get { return _industry; }
            set
            {
                if (!ReferenceEquals(_industry, value))
                {
                    var previousValue = _industry;
                    _industry = value;
                    FixupIndustry(previousValue);
                    OnNavigationPropertyChanged("Industry");
                }
            }
        }
        private Industry _industry;
    
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
            DataSources.Clear();
            Industry = null;
            Owner = null;
            State = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupIndustry(Industry previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Packages.Contains(this))
            {
                previousValue.Packages.Remove(this);
            }
    
            if (Industry != null)
            {
                if (!Industry.Packages.Contains(this))
                {
                    Industry.Packages.Add(this);
                }
    
                PackageIndustry = Industry.Value;
            }
            else if (!skipKeys)
            {
                PackageIndustry = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Industry")
                    && (ChangeTracker.OriginalValues["Industry"] == Industry))
                {
                    ChangeTracker.OriginalValues.Remove("Industry");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Industry", previousValue);
                }
                if (Industry != null && !Industry.ChangeTracker.ChangeTrackingEnabled)
                {
                    Industry.StartTracking();
                }
            }
        }
    
        private void FixupOwner(Owner previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Packages.Contains(this))
            {
                previousValue.Packages.Remove(this);
            }
    
            if (Owner != null)
            {
                if (!Owner.Packages.Contains(this))
                {
                    Owner.Packages.Add(this);
                }
    
                PackageOwner = Owner.Value;
            }
            else if (!skipKeys)
            {
                PackageOwner = null;
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
    
            if (previousValue != null && previousValue.Packages.Contains(this))
            {
                previousValue.Packages.Remove(this);
            }
    
            if (State != null)
            {
                if (!State.Packages.Contains(this))
                {
                    State.Packages.Add(this);
                }
    
                PackageState = State.Value;
            }
            else if (!skipKeys)
            {
                PackageState = null;
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
    
        private void FixupDataSources(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (DataSource item in e.NewItems)
                {
                    item.Package = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("DataSources", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (DataSource item in e.OldItems)
                {
                    if (ReferenceEquals(item.Package, this))
                    {
                        item.Package = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("DataSources", item);
                    }
                }
            }
        }

        #endregion


    }

}
