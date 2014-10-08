using System;
using System.Linq;
using System.Reflection;

namespace LightstoneApp.Domain.Core
{
    /// <summary>
    /// The base class for DDD ValueObject 
    /// </summary>
    /// <typeparam name="TValueObject"></typeparam>
    public abstract class ValueObject<TValueObject> : IEquatable<TValueObject> where TValueObject : ValueObject<TValueObject>
    {
        #region IEquatable and Override Equals operators

        public bool Equals(TValueObject other)
        {
            if ((object) other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            //compare all public properties
            PropertyInfo[] publicProperties = GetType().GetProperties();

            if (publicProperties.Any())
            {
                return publicProperties.All(p =>
                {
                    object left = p.GetValue(this, null);
                    object right = p.GetValue(other, null);


                    if (left is TValueObject)
                        return ReferenceEquals(left, right);
                    return left.Equals(right);
                });
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            var item = obj as ValueObject<TValueObject>;

            return (object) item != null && Equals((TValueObject) item);
        }

        public override int GetHashCode()
        {
            int hashCode = 31;
            bool changeMultiplier = false;
            const int index = 1;

            //compare all public properties
            PropertyInfo[] publicProperties = GetType().GetProperties();

            if (publicProperties.Any())
            {
                foreach (object value in publicProperties.Select(item => item.GetValue(this, null)))
                {
                    if (value != null)
                    {
                        hashCode = hashCode*((changeMultiplier) ? 59 : 114) + value.GetHashCode();
                        changeMultiplier = !changeMultiplier;
                    }
                    else
                        hashCode = hashCode ^ (index*13); //only for support {"a",null,null,"a"} <> {null,"a","a",null}
                }
            }

            return hashCode;
        }

        public static bool operator ==(ValueObject<TValueObject> left, ValueObject<TValueObject> right)
        {
            return Equals(left, null) ? (Equals(right, null)) : left.Equals(right);
        }

        public static bool operator !=(ValueObject<TValueObject> left, ValueObject<TValueObject> right)
        {
            return !(left == right);
        }

        #endregion
    }
}