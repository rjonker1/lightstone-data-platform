using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.Serialization;

#pragma warning disable 1591 // this is for supress no xml comments in public members warnings 

using LightstoneApp.Domain.Core.Entities;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(DataSource))]
    [KnownType(typeof(Package))]
    

    public partial class State: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public string Value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'Value' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _value = value;
                    OnPropertyChanged("Value");
                }
            }
        }
        private string _value;

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
        public TrackableCollection<Package> Packages
        {
            get
            {
                if (_packages == null)
                {
                    _packages = new TrackableCollection<Package>();
                    _packages.CollectionChanged += FixupPackages;
                }
                return _packages;
            }
            set
            {
                if (!ReferenceEquals(_packages, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_packages != null)
                    {
                        _packages.CollectionChanged -= FixupPackages;
                    }
                    _packages = value;
                    if (_packages != null)
                    {
                        _packages.CollectionChanged += FixupPackages;
                    }
                    OnNavigationPropertyChanged("Packages");
                }
            }
        }
        private TrackableCollection<Package> _packages;

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
            Packages.Clear();
        }

        #endregion

        #region Association Fixup
    
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
                    item.State = this;
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
                    if (ReferenceEquals(item.State, this))
                    {
                        item.State = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("DataSources", item);
                    }
                }
            }
        }
    
        private void FixupPackages(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Package item in e.NewItems)
                {
                    item.State = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Packages", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Package item in e.OldItems)
                {
                    if (ReferenceEquals(item.State, this))
                    {
                        item.State = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Packages", item);
                    }
                }
            }
        }

        #endregion

    }
}
