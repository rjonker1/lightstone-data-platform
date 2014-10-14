using System;
using System.ComponentModel;
using System.Runtime.Serialization;

#pragma warning disable 1591 // this is for supress no xml comments in public members warnings 

using LightstoneApp.Domain.Core.Entities;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(DataSource))]
    

    public partial class FileAttachment: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int FileAttachmentId
        {
            get { return _fileAttachmentId; }
            set
            {
                if (_fileAttachmentId != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'FileAttachmentId' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _fileAttachmentId = value;
                    OnPropertyChanged("FileAttachmentId");
                }
            }
        }
        private int _fileAttachmentId;
    
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
        public string FileName
        {
            get { return _fileName; }
            set
            {
                if (_fileName != value)
                {
                    ChangeTracker.RecordOriginalValue("FileName", _fileName);
                    _fileName = value;
                    OnPropertyChanged("FileName");
                }
            }
        }
        private string _fileName;

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
        }

        #endregion

        #region Association Fixup
    
        private void FixupDataSource(DataSource previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.FileAttachments.Contains(this))
            {
                previousValue.FileAttachments.Remove(this);
            }
    
            if (DataSource != null)
            {
                if (!DataSource.FileAttachments.Contains(this))
                {
                    DataSource.FileAttachments.Add(this);
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

        #endregion

    }
}
