using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework
{
    /// <summary>
    ///   Base class for entities
    /// </summary>
    [DataContract(IsReference = true)]
    public abstract class Entity : Aggregate, INotifyPropertyChanged
    {
        #region Fields

        private int? _requestedHashCode;

        #endregion

        #region Properties

        /// <summary>
        /// Get the persisten object identifier
        /// </summary>
        [DataMember]
        public virtual Guid Id { get; protected set; }

        [DataMember]
        public TrackState? EntityState { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Check if this entity is transient, ie, without identity at this moment
        /// </summary>
        /// <returns> True if entity is transient, else false </returns>
        public bool IsTransient()
        {
            return Id == Guid.Empty;
        }

        /// <summary>
        /// Generate identity for this entity
        /// </summary>
        public  void GenerateNewIdentity()
        {
            if (IsTransient())
                Id = IdentityGenerator.NewSequentialGuid();
        }


        /// <summary>
        /// Change current identity for a new non transient identity
        /// </summary>
        /// <param name="identity"> the new identity </param>
        public void ChangeCurrentIdentity(Guid identity)
        {
            if (identity != Guid.Empty)
                Id = identity;
        }

        /// <summary>
        /// Clone Entity
        /// </summary>
        public T Clone<T>()
        {
            T copia;
            var serializer = new DataContractSerializer(typeof(T));

            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, this);
                ms.Position = 0;
                copia = (T)serializer.ReadObject(ms);
            }

            return copia;
        }

        #endregion

        #region Overrides Methods

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            var item = (Entity) obj;

            if (item.IsTransient() || IsTransient())
                return false;
            else
                return item.Id == Id;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = Id.GetHashCode() ^ 31;
 
                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Equals(left, null))
                return (Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    #region Tracking

    public enum TrackState
    {
        Added,
        Deleted,
        Detached,
        Modified,
        Unchanged
    } 

    #endregion
}