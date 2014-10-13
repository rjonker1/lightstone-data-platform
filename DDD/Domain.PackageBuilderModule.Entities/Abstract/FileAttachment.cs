using System;
using System.ComponentModel;
using System.Threading;
using LightstoneApp.Domain.PackageBuilderModule.Entities.PackageBuilder;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.ComponentModel;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities.Abstract
{
    public abstract class FileAttachment : INotifyPropertyChanged, IHasPackageBuilderContext
    {
        #region FileAttachment INotifyPropertyChanged Implementation

        private PropertyChangedEventHandler _propertyChangedEventHandler;

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                if ((object)value != null)
                {
                    PropertyChangedEventHandler currentHandler;
                    while (
                        Interlocked.CompareExchange(ref _propertyChangedEventHandler,
                            (PropertyChangedEventHandler)
                                Delegate.Combine(currentHandler = _propertyChangedEventHandler, value),
                            currentHandler) != (object)currentHandler)
                    {
                    }
                }
            }
            remove
            {
                if ((object)value != null)
                {
                    PropertyChangedEventHandler currentHandler;
                    while (
                        Interlocked.CompareExchange(ref _propertyChangedEventHandler,
                            (PropertyChangedEventHandler)
                                Delegate.Remove(currentHandler = _propertyChangedEventHandler, value),
                            currentHandler) != (object)currentHandler)
                    {
                    }
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler eventHandler;
            if ((object)(eventHandler = _propertyChangedEventHandler) != null)
            {
                EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion // FileAttachment INotifyPropertyChanged Implementation

        #region FileAttachment Property Change Events

        private Delegate[] _events;

        private Delegate[] Events
        {
            get
            {
                Delegate[] localEvents;
                return (localEvents = _events) ??
                       Interlocked.CompareExchange(ref _events, localEvents = new Delegate[6], null) ?? localEvents;
            }
        }

        private static void InterlockedDelegateCombine(ref Delegate location, Delegate value)
        {
            Delegate currentHandler;
            while (
                Interlocked.CompareExchange(ref location, Delegate.Combine(currentHandler = location, value),
                    currentHandler) != (object)currentHandler)
            {
            }
        }

        private static void InterlockedDelegateRemove(ref Delegate location, Delegate value)
        {
            Delegate currentHandler;
            while (
                Interlocked.CompareExchange(ref location, Delegate.Remove(currentHandler = location, value),
                    currentHandler) != (object)currentHandler)
            {
            }
        }

        public event EventHandler<PropertyChangingEventArgs<FileAttachment, string>> FileNameChanging
        {
            add
            {
                if ((object)value != null)
                {
                    InterlockedDelegateCombine(ref Events[0], value);
                }
            }
            remove
            {
                Delegate[] events;
                if ((object)value != null && (events = _events) != null)
                {
                    InterlockedDelegateRemove(ref events[0], value);
                }
            }
        }

        protected bool OnFileNameChanging(string newValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangingEventArgs<FileAttachment, string>> eventHandler;
            if ((events = _events) != null &&
                (object)
                    (eventHandler = (EventHandler<PropertyChangingEventArgs<FileAttachment, string>>)events[0]) !=
                null)
            {
                return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                    new PropertyChangingEventArgs<FileAttachment, string>(this, "FileName", FileName, newValue));
            }
            return true;
        }

        public event EventHandler<PropertyChangedEventArgs<FileAttachment, string>> FileNameChanged
        {
            add
            {
                if ((object)value != null)
                {
                    InterlockedDelegateCombine(ref Events[1], value);
                }
            }
            remove
            {
                Delegate[] events;
                if ((object)value != null && (events = _events) != null)
                {
                    InterlockedDelegateRemove(ref events[1], value);
                }
            }
        }

        protected void OnFileNameChanged(string oldValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangedEventArgs<FileAttachment, string>> eventHandler;
            if ((events = _events) != null &&
                (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<FileAttachment, string>>)events[1]) !=
                null)
            {
                EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                    new PropertyChangedEventArgs<FileAttachment, string>(this, "FileName", oldValue, FileName),
                    _propertyChangedEventHandler);
            }
            else
            {
                OnPropertyChanged("FileName");
            }
        }

        [CLSCompliant(false)]
        public event EventHandler<PropertyChangingEventArgs<FileAttachment, byte[]>> BlobChanging
        {
            add
            {
                if ((object)value != null)
                {
                    InterlockedDelegateCombine(ref Events[2], value);
                }
            }
            remove
            {
                Delegate[] events;
                if ((object)value != null && (events = _events) != null)
                {
                    InterlockedDelegateRemove(ref events[2], value);
                }
            }
        }

        [CLSCompliant(false)]
        protected bool OnBlobChanging(byte[] newValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangingEventArgs<FileAttachment, byte[]>> eventHandler;
            if ((events = _events) != null &&
                (object)
                    (eventHandler = (EventHandler<PropertyChangingEventArgs<FileAttachment, byte[]>>)events[2]) !=
                null)
            {
                return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                    new PropertyChangingEventArgs<FileAttachment, byte[]>(this, "Blob", Blob, newValue));
            }
            return true;
        }

        [CLSCompliant(false)]
        public event EventHandler<PropertyChangedEventArgs<FileAttachment, byte[]>> BlobChanged
        {
            add
            {
                if ((object)value != null)
                {
                    InterlockedDelegateCombine(ref Events[3], value);
                }
            }
            remove
            {
                Delegate[] events;
                if ((object)value != null && (events = _events) != null)
                {
                    InterlockedDelegateRemove(ref events[3], value);
                }
            }
        }

        [CLSCompliant(false)]
        protected void OnBlobChanged(byte[] oldValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangedEventArgs<FileAttachment, byte[]>> eventHandler;
            if ((events = _events) != null &&
                (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<FileAttachment, byte[]>>)events[3]) !=
                null)
            {
                EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                    new PropertyChangedEventArgs<FileAttachment, byte[]>(this, "Blob", oldValue, Blob),
                    _propertyChangedEventHandler);
            }
            else
            {
                OnPropertyChanged("Blob");
            }
        }

        public event EventHandler<PropertyChangingEventArgs<FileAttachment, DataSource>> DataSourceChanging
        {
            add
            {
                if ((object)value != null)
                {
                    InterlockedDelegateCombine(ref Events[4], value);
                }
            }
            remove
            {
                Delegate[] events;
                if ((object)value != null && (events = _events) != null)
                {
                    InterlockedDelegateRemove(ref events[4], value);
                }
            }
        }

        protected bool OnDataSourceChanging(DataSource newValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangingEventArgs<FileAttachment, DataSource>> eventHandler;
            if ((events = _events) != null &&
                (object)
                    (eventHandler = (EventHandler<PropertyChangingEventArgs<FileAttachment, DataSource>>)events[4]) !=
                null)
            {
                return EventHandlerUtility.InvokeCancelableEventHandler(eventHandler, this,
                    new PropertyChangingEventArgs<FileAttachment, DataSource>(this, "DataSource", DataSource,
                        newValue));
            }
            return true;
        }

        public event EventHandler<PropertyChangedEventArgs<FileAttachment, DataSource>> DataSourceChanged
        {
            add
            {
                if ((object)value != null)
                {
                    InterlockedDelegateCombine(ref Events[5], value);
                }
            }
            remove
            {
                Delegate[] events;
                if ((object)value != null && (events = _events) != null)
                {
                    InterlockedDelegateRemove(ref events[5], value);
                }
            }
        }

        protected void OnDataSourceChanged(DataSource oldValue)
        {
            Delegate[] events;
            EventHandler<PropertyChangedEventArgs<FileAttachment, DataSource>> eventHandler;
            if ((events = _events) != null &&
                (object)
                    (eventHandler = (EventHandler<PropertyChangedEventArgs<FileAttachment, DataSource>>)events[5]) !=
                null)
            {
                EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this,
                    new PropertyChangedEventArgs<FileAttachment, DataSource>(this, "DataSource", oldValue,
                        DataSource), _propertyChangedEventHandler);
            }
            else
            {
                OnPropertyChanged("DataSource");
            }
        }

        #endregion // FileAttachment Property Change Events

        #region FileAttachment Abstract Properties

        public abstract PackageBuilderContext Context { get; }

        
        public abstract string FileName { get; set; }

        [CLSCompliant(false)]
        
        public abstract byte[] Blob { get; set; }

        
        public abstract DataSource DataSource { get; set; }

        #endregion // FileAttachment Abstract Properties

        #region FileAttachment ToString Methods

        public override string ToString()
        {
            return ToString(null);
        }

        public virtual string ToString(IFormatProvider provider)
        {
            return string.Format(provider,
                @"FileAttachment{0}{{{0}{1}FileName = ""{2}"",{0}{1}Blob = ""{3}"",{0}{1}DataSource = {4}{0}}}",
                Environment.NewLine, @"	", FileName, Blob, "TODO: Recursively call ToString for customTypes...");
        }

        #endregion // FileAttachment ToString Methods
    }
}