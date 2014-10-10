using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

#region Global Support Classes

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework
{

    #region Tuples

    #region Tuple Support

    [Serializable]
    [ImmutableObject(true)]
    [StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
    public abstract partial class Tuple : IEquatable<Tuple>
    {
        [SuppressMessage("Microsoft.Usage", "CA2233:OperationsShouldNotOverflow")]
        protected static int RotateRight(int value, int places)
        {
            return (int) ((uint) value >> places | (uint) value << 32 - places);
        }

        public abstract override bool Equals(object obj);
        public abstract bool Equals(Tuple other);
        public abstract override int GetHashCode();
        public abstract override string ToString();
        public abstract string ToString(IFormatProvider provider);
    }

    #endregion // Tuple Support

    #region Binary (2-ary) Tuple

    public abstract partial class Tuple
    {
        public static Tuple<T1, T2> CreateTuple<T1, T2>(T1 item1, T2 item2)
        {
            if (item1 == null || item2 == null)
            {
                return null;
            }
            return new Tuple<T1, T2>(item1, item2);
        }
    }

    [Serializable]
    [StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
    public sealed class Tuple<T1, T2> : Tuple, IEquatable<Tuple<T1, T2>>
    {
        private readonly T1 _item1;

        public T1 Item1
        {
            get { return _item1; }
        }

        private readonly T2 _item2;

        public T2 Item2
        {
            get { return _item2; }
        }

        public Tuple(T1 item1, T2 item2)
        {
            if (item1 == null || item2 == null)
            {
                throw new ArgumentNullException();
            }
            _item1 = item1;
            _item2 = item2;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Tuple<T1, T2>);
        }

        public override bool Equals(Tuple other)
        {
            return Equals(other as Tuple<T1, T2>);
        }

        public bool Equals(Tuple<T1, T2> other)
        {
            return this == (object) other ||
                   (object) other != null && (_item1.Equals(other._item1) || _item2.Equals(other._item2));
        }

        public override int GetHashCode()
        {
            return _item1.GetHashCode() ^ RotateRight(_item2.GetHashCode(), 1);
        }

        public override string ToString()
        {
            return ToString(null);
        }

        public override string ToString(IFormatProvider provider)
        {
            return string.Format(provider, "({1}, {2})", _item1, _item2);
        }

        public static bool operator ==(Tuple<T1, T2> tuple1, Tuple<T1, T2> tuple2)
        {
            return tuple1 == (object) tuple2 || (object) tuple1 == null && tuple1.Equals(tuple2);
        }

        public static bool operator !=(Tuple<T1, T2> tuple1, Tuple<T1, T2> tuple2)
        {
            return !(tuple1 == tuple2);
        }

        public static implicit operator KeyValuePair<T1, T2>(Tuple<T1, T2> tuple)
        {
            if ((object) tuple == null)
            {
                return default(KeyValuePair<T1, T2>);
            }
            return new KeyValuePair<T1, T2>(tuple._item1, tuple._item2);
        }

        public static explicit operator Tuple<T1, T2>(KeyValuePair<T1, T2> keyValuePair)
        {
            if (keyValuePair.Key == null || keyValuePair.Value == null)
            {
                throw new InvalidCastException();
            }
            return new Tuple<T1, T2>(keyValuePair.Key, keyValuePair.Value);
        }

        public static implicit operator DictionaryEntry(Tuple<T1, T2> tuple)
        {
            if ((object) tuple == null)
            {
                return default(DictionaryEntry);
            }
            return new DictionaryEntry(tuple._item1, tuple._item2);
        }

        public static explicit operator Tuple<T1, T2>(DictionaryEntry dictionaryEntry)
        {
            object key = dictionaryEntry.Key;
            object value = dictionaryEntry.Value;
            if (key == null || value == null || !(key is T1 && value is T2))
            {
                throw new InvalidCastException();
            }
            return new Tuple<T1, T2>((T1) key, (T2) value);
        }
    }

    #endregion // Binary (2-ary) Tuple

    #region Ternary (3-ary) Tuple

    public abstract partial class Tuple
    {
        public static Tuple<T1, T2, T3> CreateTuple<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
        {
            if (item1 == null || item2 == null || item3 == null)
            {
                return null;
            }
            return new Tuple<T1, T2, T3>(item1, item2, item3);
        }
    }

    [Serializable]
    [SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")]
    [StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
    public sealed class Tuple<T1, T2, T3> : Tuple, IEquatable<Tuple<T1, T2, T3>>
    {
        private readonly T1 _item1;

        public T1 Item1
        {
            get { return _item1; }
        }

        private readonly T2 _item2;

        public T2 Item2
        {
            get { return _item2; }
        }

        private readonly T3 _item3;

        public T3 Item3
        {
            get { return _item3; }
        }

        public Tuple(T1 item1, T2 item2, T3 item3)
        {
            if (item1 == null || item2 == null || item3 == null)
            {
                throw new ArgumentNullException();
            }
            _item1 = item1;
            _item2 = item2;
            _item3 = item3;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Tuple<T1, T2, T3>);
        }

        public override bool Equals(Tuple other)
        {
            return Equals(other as Tuple<T1, T2, T3>);
        }

        public bool Equals(Tuple<T1, T2, T3> other)
        {
            return this == (object) other ||
                   (object) other != null &&
                   (_item1.Equals(other._item1) || _item2.Equals(other._item2) || _item3.Equals(other._item3));
        }

        public override int GetHashCode()
        {
            return _item1.GetHashCode() ^ RotateRight(_item2.GetHashCode(), 1) ^ RotateRight(_item3.GetHashCode(), 2);
        }

        public override string ToString()
        {
            return ToString(null);
        }

        public override string ToString(IFormatProvider provider)
        {
            return string.Format(provider, "({1}, {2}, {3})", _item1, _item2, _item3);
        }

        public static bool operator ==(Tuple<T1, T2, T3> tuple1, Tuple<T1, T2, T3> tuple2)
        {
            return tuple1 == (object) tuple2 || (object) tuple1 == null && tuple1.Equals(tuple2);
        }

        public static bool operator !=(Tuple<T1, T2, T3> tuple1, Tuple<T1, T2, T3> tuple2)
        {
            return !(tuple1 == tuple2);
        }
    }

    #endregion // Ternary (3-ary) Tuple

    #region Quaternary (4-ary) Tuple

    public abstract partial class Tuple
    {
        public static Tuple<T1, T2, T3, T4> CreateTuple<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            if (item1 == null || item2 == null || item3 == null || item4 == null)
            {
                return null;
            }
            return new Tuple<T1, T2, T3, T4>(item1, item2, item3, item4);
        }
    }

    [Serializable]
    [SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")]
    [StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
    public sealed class Tuple<T1, T2, T3, T4> : Tuple, IEquatable<Tuple<T1, T2, T3, T4>>
    {
        private readonly T1 _item1;

        public T1 Item1
        {
            get { return _item1; }
        }

        private readonly T2 _item2;

        public T2 Item2
        {
            get { return _item2; }
        }

        private readonly T3 _item3;

        public T3 Item3
        {
            get { return _item3; }
        }

        private readonly T4 _item4;

        public T4 Item4
        {
            get { return _item4; }
        }

        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            if (item1 == null || item2 == null || item3 == null || item4 == null)
            {
                throw new ArgumentNullException();
            }
            _item1 = item1;
            _item2 = item2;
            _item3 = item3;
            _item4 = item4;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Tuple<T1, T2, T3, T4>);
        }

        public override bool Equals(Tuple other)
        {
            return Equals(other as Tuple<T1, T2, T3, T4>);
        }

        public bool Equals(Tuple<T1, T2, T3, T4> other)
        {
            return this == (object) other ||
                   (object) other != null &&
                   (_item1.Equals(other._item1) || _item2.Equals(other._item2) || _item3.Equals(other._item3) ||
                    _item4.Equals(other._item4));
        }

        public override int GetHashCode()
        {
            return _item1.GetHashCode() ^ RotateRight(_item2.GetHashCode(), 1) ^ RotateRight(_item3.GetHashCode(), 2) ^
                   RotateRight(_item4.GetHashCode(), 3);
        }

        public override string ToString()
        {
            return ToString(null);
        }

        public override string ToString(IFormatProvider provider)
        {
            return string.Format(provider, "({1}, {2}, {3}, {4})", _item1, _item2, _item3, _item4);
        }

        public static bool operator ==(Tuple<T1, T2, T3, T4> tuple1, Tuple<T1, T2, T3, T4> tuple2)
        {
            return tuple1 == (object) tuple2 || (object) tuple1 == null && tuple1.Equals(tuple2);
        }

        public static bool operator !=(Tuple<T1, T2, T3, T4> tuple1, Tuple<T1, T2, T3, T4> tuple2)
        {
            return !(tuple1 == tuple2);
        }
    }

    #endregion // Quaternary (4-ary) Tuple

    #region Quinary (5-ary) Tuple

    public abstract partial class Tuple
    {
        public static Tuple<T1, T2, T3, T4, T5> CreateTuple<T1, T2, T3, T4, T5>(T1 item1, T2 item2, T3 item3, T4 item4,
            T5 item5)
        {
            if (item1 == null || item2 == null || item3 == null || item4 == null || item5 == null)
            {
                return null;
            }
            return new Tuple<T1, T2, T3, T4, T5>(item1, item2, item3, item4, item5);
        }
    }

    [Serializable]
    [SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")]
    [StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
    public sealed class Tuple<T1, T2, T3, T4, T5> : Tuple, IEquatable<Tuple<T1, T2, T3, T4, T5>>
    {
        private readonly T1 _item1;

        public T1 Item1
        {
            get { return _item1; }
        }

        private readonly T2 _item2;

        public T2 Item2
        {
            get { return _item2; }
        }

        private readonly T3 _item3;

        public T3 Item3
        {
            get { return _item3; }
        }

        private readonly T4 _item4;

        public T4 Item4
        {
            get { return _item4; }
        }

        private readonly T5 _item5;

        public T5 Item5
        {
            get { return _item5; }
        }

        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
        {
            if (item1 == null || item2 == null || item3 == null || item4 == null || item5 == null)
            {
                throw new ArgumentNullException();
            }
            _item1 = item1;
            _item2 = item2;
            _item3 = item3;
            _item4 = item4;
            _item5 = item5;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Tuple<T1, T2, T3, T4, T5>);
        }

        public override bool Equals(Tuple other)
        {
            return Equals(other as Tuple<T1, T2, T3, T4, T5>);
        }

        public bool Equals(Tuple<T1, T2, T3, T4, T5> other)
        {
            return this == (object) other ||
                   (object) other != null &&
                   (_item1.Equals(other._item1) || _item2.Equals(other._item2) || _item3.Equals(other._item3) ||
                    _item4.Equals(other._item4) || _item5.Equals(other._item5));
        }

        public override int GetHashCode()
        {
            return _item1.GetHashCode() ^ RotateRight(_item2.GetHashCode(), 1) ^ RotateRight(_item3.GetHashCode(), 2) ^
                   RotateRight(_item4.GetHashCode(), 3) ^ RotateRight(_item5.GetHashCode(), 4);
        }

        public override string ToString()
        {
            return ToString(null);
        }

        public override string ToString(IFormatProvider provider)
        {
            return string.Format(provider, "({1}, {2}, {3}, {4}, {5})", _item1, _item2, _item3, _item4, _item5);
        }

        public static bool operator ==(Tuple<T1, T2, T3, T4, T5> tuple1, Tuple<T1, T2, T3, T4, T5> tuple2)
        {
            return tuple1 == (object) tuple2 || (object) tuple1 == null && tuple1.Equals(tuple2);
        }

        public static bool operator !=(Tuple<T1, T2, T3, T4, T5> tuple1, Tuple<T1, T2, T3, T4, T5> tuple2)
        {
            return !(tuple1 == tuple2);
        }
    }

    #endregion // Quinary (5-ary) Tuple

    #region Senary (6-ary) Tuple

    public abstract partial class Tuple
    {
        public static Tuple<T1, T2, T3, T4, T5, T6> CreateTuple<T1, T2, T3, T4, T5, T6>(T1 item1, T2 item2, T3 item3,
            T4 item4, T5 item5, T6 item6)
        {
            if (item1 == null || item2 == null || item3 == null || item4 == null || item5 == null || item6 == null)
            {
                return null;
            }
            return new Tuple<T1, T2, T3, T4, T5, T6>(item1, item2, item3, item4, item5, item6);
        }
    }

    [Serializable]
    [SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")]
    [StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
    public sealed class Tuple<T1, T2, T3, T4, T5, T6> : Tuple, IEquatable<Tuple<T1, T2, T3, T4, T5, T6>>
    {
        private readonly T1 _item1;

        public T1 Item1
        {
            get { return _item1; }
        }

        private readonly T2 _item2;

        public T2 Item2
        {
            get { return _item2; }
        }

        private readonly T3 _item3;

        public T3 Item3
        {
            get { return _item3; }
        }

        private readonly T4 _item4;

        public T4 Item4
        {
            get { return _item4; }
        }

        private readonly T5 _item5;

        public T5 Item5
        {
            get { return _item5; }
        }

        private readonly T6 _item6;

        public T6 Item6
        {
            get { return _item6; }
        }

        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
        {
            if (item1 == null || item2 == null || item3 == null || item4 == null || item5 == null || item6 == null)
            {
                throw new ArgumentNullException();
            }
            _item1 = item1;
            _item2 = item2;
            _item3 = item3;
            _item4 = item4;
            _item5 = item5;
            _item6 = item6;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Tuple<T1, T2, T3, T4, T5, T6>);
        }

        public override bool Equals(Tuple other)
        {
            return Equals(other as Tuple<T1, T2, T3, T4, T5, T6>);
        }

        public bool Equals(Tuple<T1, T2, T3, T4, T5, T6> other)
        {
            return this == (object) other ||
                   (object) other != null &&
                   (_item1.Equals(other._item1) || _item2.Equals(other._item2) || _item3.Equals(other._item3) ||
                    _item4.Equals(other._item4) || _item5.Equals(other._item5) || _item6.Equals(other._item6));
        }

        public override int GetHashCode()
        {
            return _item1.GetHashCode() ^ RotateRight(_item2.GetHashCode(), 1) ^ RotateRight(_item3.GetHashCode(), 2) ^
                   RotateRight(_item4.GetHashCode(), 3) ^ RotateRight(_item5.GetHashCode(), 4) ^
                   RotateRight(_item6.GetHashCode(), 5);
        }

        public override string ToString()
        {
            return ToString(null);
        }

        public override string ToString(IFormatProvider provider)
        {
            return string.Format(provider, "({1}, {2}, {3}, {4}, {5}, {6})", _item1, _item2, _item3, _item4, _item5,
                _item6);
        }

        public static bool operator ==(Tuple<T1, T2, T3, T4, T5, T6> tuple1, Tuple<T1, T2, T3, T4, T5, T6> tuple2)
        {
            return tuple1 == (object) tuple2 || (object) tuple1 == null && tuple1.Equals(tuple2);
        }

        public static bool operator !=(Tuple<T1, T2, T3, T4, T5, T6> tuple1, Tuple<T1, T2, T3, T4, T5, T6> tuple2)
        {
            return !(tuple1 == tuple2);
        }
    }

    #endregion // Senary (6-ary) Tuple

    #region Septenary (7-ary) Tuple

    public abstract partial class Tuple
    {
        public static Tuple<T1, T2, T3, T4, T5, T6, T7> CreateTuple<T1, T2, T3, T4, T5, T6, T7>(T1 item1, T2 item2,
            T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
        {
            if (item1 == null || item2 == null || item3 == null || item4 == null || item5 == null || item6 == null ||
                item7 == null)
            {
                return null;
            }
            return new Tuple<T1, T2, T3, T4, T5, T6, T7>(item1, item2, item3, item4, item5, item6, item7);
        }
    }

    [Serializable]
    [SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")]
    [StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
    public sealed class Tuple<T1, T2, T3, T4, T5, T6, T7> : Tuple, IEquatable<Tuple<T1, T2, T3, T4, T5, T6, T7>>
    {
        private readonly T1 _item1;

        public T1 Item1
        {
            get { return _item1; }
        }

        private readonly T2 _item2;

        public T2 Item2
        {
            get { return _item2; }
        }

        private readonly T3 _item3;

        public T3 Item3
        {
            get { return _item3; }
        }

        private readonly T4 _item4;

        public T4 Item4
        {
            get { return _item4; }
        }

        private readonly T5 _item5;

        public T5 Item5
        {
            get { return _item5; }
        }

        private readonly T6 _item6;

        public T6 Item6
        {
            get { return _item6; }
        }

        private readonly T7 _item7;

        public T7 Item7
        {
            get { return _item7; }
        }

        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
        {
            if (item1 == null || item2 == null || item3 == null || item4 == null || item5 == null || item6 == null ||
                item7 == null)
            {
                throw new ArgumentNullException();
            }
            _item1 = item1;
            _item2 = item2;
            _item3 = item3;
            _item4 = item4;
            _item5 = item5;
            _item6 = item6;
            _item7 = item7;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Tuple<T1, T2, T3, T4, T5, T6, T7>);
        }

        public override bool Equals(Tuple other)
        {
            return Equals(other as Tuple<T1, T2, T3, T4, T5, T6, T7>);
        }

        public bool Equals(Tuple<T1, T2, T3, T4, T5, T6, T7> other)
        {
            return this == (object) other ||
                   (object) other != null &&
                   (_item1.Equals(other._item1) || _item2.Equals(other._item2) || _item3.Equals(other._item3) ||
                    _item4.Equals(other._item4) || _item5.Equals(other._item5) || _item6.Equals(other._item6) ||
                    _item7.Equals(other._item7));
        }

        public override int GetHashCode()
        {
            return _item1.GetHashCode() ^ RotateRight(_item2.GetHashCode(), 1) ^ RotateRight(_item3.GetHashCode(), 2) ^
                   RotateRight(_item4.GetHashCode(), 3) ^ RotateRight(_item5.GetHashCode(), 4) ^
                   RotateRight(_item6.GetHashCode(), 5) ^ RotateRight(_item7.GetHashCode(), 6);
        }

        public override string ToString()
        {
            return ToString(null);
        }

        public override string ToString(IFormatProvider provider)
        {
            return string.Format(provider, "({1}, {2}, {3}, {4}, {5}, {6}, {7})", _item1, _item2, _item3, _item4, _item5,
                _item6, _item7);
        }

        public static bool operator ==(
            Tuple<T1, T2, T3, T4, T5, T6, T7> tuple1, Tuple<T1, T2, T3, T4, T5, T6, T7> tuple2)
        {
            return tuple1 == (object) tuple2 || (object) tuple1 == null && tuple1.Equals(tuple2);
        }

        public static bool operator !=(
            Tuple<T1, T2, T3, T4, T5, T6, T7> tuple1, Tuple<T1, T2, T3, T4, T5, T6, T7> tuple2)
        {
            return !(tuple1 == tuple2);
        }
    }

    #endregion // Septenary (7-ary) Tuple

    #region Octonary (8-ary) Tuple

    public abstract partial class Tuple
    {
        public static Tuple<T1, T2, T3, T4, T5, T6, T7, T8> CreateTuple<T1, T2, T3, T4, T5, T6, T7, T8>(T1 item1,
            T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8)
        {
            if (item1 == null || item2 == null || item3 == null || item4 == null || item5 == null || item6 == null ||
                item7 == null || item8 == null)
            {
                return null;
            }
            return new Tuple<T1, T2, T3, T4, T5, T6, T7, T8>(item1, item2, item3, item4, item5, item6, item7, item8);
        }
    }

    [Serializable]
    [SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")]
    [StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
    public sealed class Tuple<T1, T2, T3, T4, T5, T6, T7, T8> : Tuple, IEquatable<Tuple<T1, T2, T3, T4, T5, T6, T7, T8>>
    {
        private readonly T1 _item1;

        public T1 Item1
        {
            get { return _item1; }
        }

        private readonly T2 _item2;

        public T2 Item2
        {
            get { return _item2; }
        }

        private readonly T3 _item3;

        public T3 Item3
        {
            get { return _item3; }
        }

        private readonly T4 _item4;

        public T4 Item4
        {
            get { return _item4; }
        }

        private readonly T5 _item5;

        public T5 Item5
        {
            get { return _item5; }
        }

        private readonly T6 _item6;

        public T6 Item6
        {
            get { return _item6; }
        }

        private readonly T7 _item7;

        public T7 Item7
        {
            get { return _item7; }
        }

        private readonly T8 _item8;

        public T8 Item8
        {
            get { return _item8; }
        }

        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8)
        {
            if (item1 == null || item2 == null || item3 == null || item4 == null || item5 == null || item6 == null ||
                item7 == null || item8 == null)
            {
                throw new ArgumentNullException();
            }
            _item1 = item1;
            _item2 = item2;
            _item3 = item3;
            _item4 = item4;
            _item5 = item5;
            _item6 = item6;
            _item7 = item7;
            _item8 = item8;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Tuple<T1, T2, T3, T4, T5, T6, T7, T8>);
        }

        public override bool Equals(Tuple other)
        {
            return Equals(other as Tuple<T1, T2, T3, T4, T5, T6, T7, T8>);
        }

        public bool Equals(Tuple<T1, T2, T3, T4, T5, T6, T7, T8> other)
        {
            return this == (object) other ||
                   (object) other != null &&
                   (_item1.Equals(other._item1) || _item2.Equals(other._item2) || _item3.Equals(other._item3) ||
                    _item4.Equals(other._item4) || _item5.Equals(other._item5) || _item6.Equals(other._item6) ||
                    _item7.Equals(other._item7) || _item8.Equals(other._item8));
        }

        public override int GetHashCode()
        {
            return _item1.GetHashCode() ^ RotateRight(_item2.GetHashCode(), 1) ^ RotateRight(_item3.GetHashCode(), 2) ^
                   RotateRight(_item4.GetHashCode(), 3) ^ RotateRight(_item5.GetHashCode(), 4) ^
                   RotateRight(_item6.GetHashCode(), 5) ^ RotateRight(_item7.GetHashCode(), 6) ^
                   RotateRight(_item8.GetHashCode(), 7);
        }

        public override string ToString()
        {
            return ToString(null);
        }

        public override string ToString(IFormatProvider provider)
        {
            return string.Format(provider, "({1}, {2}, {3}, {4}, {5}, {6}, {7}, {8})", _item1, _item2, _item3, _item4,
                _item5, _item6, _item7, _item8);
        }

        public static bool operator ==(
            Tuple<T1, T2, T3, T4, T5, T6, T7, T8> tuple1, Tuple<T1, T2, T3, T4, T5, T6, T7, T8> tuple2)
        {
            return tuple1 == (object) tuple2 || (object) tuple1 == null && tuple1.Equals(tuple2);
        }

        public static bool operator !=(
            Tuple<T1, T2, T3, T4, T5, T6, T7, T8> tuple1, Tuple<T1, T2, T3, T4, T5, T6, T7, T8> tuple2)
        {
            return !(tuple1 == tuple2);
        }
    }

    #endregion // Octonary (8-ary) Tuple

    #region Nonary (9-ary) Tuple

    public abstract partial class Tuple
    {
        public static Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9)
        {
            if (item1 == null || item2 == null || item3 == null || item4 == null || item5 == null || item6 == null ||
                item7 == null || item8 == null || item9 == null)
            {
                return null;
            }
            return new Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>(item1, item2, item3, item4, item5, item6, item7, item8,
                item9);
        }
    }

    [Serializable]
    [SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")]
    [StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
    public sealed class Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> : Tuple,
        IEquatable<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>>
    {
        private readonly T1 _item1;

        public T1 Item1
        {
            get { return _item1; }
        }

        private readonly T2 _item2;

        public T2 Item2
        {
            get { return _item2; }
        }

        private readonly T3 _item3;

        public T3 Item3
        {
            get { return _item3; }
        }

        private readonly T4 _item4;

        public T4 Item4
        {
            get { return _item4; }
        }

        private readonly T5 _item5;

        public T5 Item5
        {
            get { return _item5; }
        }

        private readonly T6 _item6;

        public T6 Item6
        {
            get { return _item6; }
        }

        private readonly T7 _item7;

        public T7 Item7
        {
            get { return _item7; }
        }

        private readonly T8 _item8;

        public T8 Item8
        {
            get { return _item8; }
        }

        private readonly T9 _item9;

        public T9 Item9
        {
            get { return _item9; }
        }

        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9)
        {
            if (item1 == null || item2 == null || item3 == null || item4 == null || item5 == null || item6 == null ||
                item7 == null || item8 == null || item9 == null)
            {
                throw new ArgumentNullException();
            }
            _item1 = item1;
            _item2 = item2;
            _item3 = item3;
            _item4 = item4;
            _item5 = item5;
            _item6 = item6;
            _item7 = item7;
            _item8 = item8;
            _item9 = item9;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>);
        }

        public override bool Equals(Tuple other)
        {
            return Equals(other as Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>);
        }

        public bool Equals(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> other)
        {
            return this == (object) other ||
                   (object) other != null &&
                   (_item1.Equals(other._item1) || _item2.Equals(other._item2) || _item3.Equals(other._item3) ||
                    _item4.Equals(other._item4) || _item5.Equals(other._item5) || _item6.Equals(other._item6) ||
                    _item7.Equals(other._item7) || _item8.Equals(other._item8) || _item9.Equals(other._item9));
        }

        public override int GetHashCode()
        {
            return _item1.GetHashCode() ^ RotateRight(_item2.GetHashCode(), 1) ^ RotateRight(_item3.GetHashCode(), 2) ^
                   RotateRight(_item4.GetHashCode(), 3) ^ RotateRight(_item5.GetHashCode(), 4) ^
                   RotateRight(_item6.GetHashCode(), 5) ^ RotateRight(_item7.GetHashCode(), 6) ^
                   RotateRight(_item8.GetHashCode(), 7) ^ RotateRight(_item9.GetHashCode(), 8);
        }

        public override string ToString()
        {
            return ToString(null);
        }

        public override string ToString(IFormatProvider provider)
        {
            return string.Format(provider, "({1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9})", _item1, _item2, _item3,
                _item4, _item5, _item6, _item7, _item8, _item9);
        }

        public static bool operator ==(
            Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> tuple1, Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> tuple2)
        {
            return tuple1 == (object) tuple2 || (object) tuple1 == null && tuple1.Equals(tuple2);
        }

        public static bool operator !=(
            Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> tuple1, Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> tuple2)
        {
            return !(tuple1 == tuple2);
        }
    }

    #endregion // Nonary (9-ary) Tuple

    #region Denary (10-ary) Tuple

    public abstract partial class Tuple
    {
        public static Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> CreateTuple
            <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6,
                T7 item7, T8 item8, T9 item9, T10 item10)
        {
            if (item1 == null || item2 == null || item3 == null || item4 == null || item5 == null || item6 == null ||
                item7 == null || item8 == null || item9 == null || item10 == null)
            {
                return null;
            }
            return new Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(item1, item2, item3, item4, item5, item6, item7,
                item8, item9, item10);
        }
    }

    [Serializable]
    [SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")]
    [StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
    public sealed class Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : Tuple,
        IEquatable<Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>
    {
        private readonly T1 _item1;

        public T1 Item1
        {
            get { return _item1; }
        }

        private readonly T2 _item2;

        public T2 Item2
        {
            get { return _item2; }
        }

        private readonly T3 _item3;

        public T3 Item3
        {
            get { return _item3; }
        }

        private readonly T4 _item4;

        public T4 Item4
        {
            get { return _item4; }
        }

        private readonly T5 _item5;

        public T5 Item5
        {
            get { return _item5; }
        }

        private readonly T6 _item6;

        public T6 Item6
        {
            get { return _item6; }
        }

        private readonly T7 _item7;

        public T7 Item7
        {
            get { return _item7; }
        }

        private readonly T8 _item8;

        public T8 Item8
        {
            get { return _item8; }
        }

        private readonly T9 _item9;

        public T9 Item9
        {
            get { return _item9; }
        }

        private readonly T10 _item10;

        public T10 Item10
        {
            get { return _item10; }
        }

        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9,
            T10 item10)
        {
            if (item1 == null || item2 == null || item3 == null || item4 == null || item5 == null || item6 == null ||
                item7 == null || item8 == null || item9 == null || item10 == null)
            {
                throw new ArgumentNullException();
            }
            _item1 = item1;
            _item2 = item2;
            _item3 = item3;
            _item4 = item4;
            _item5 = item5;
            _item6 = item6;
            _item7 = item7;
            _item8 = item8;
            _item9 = item9;
            _item10 = item10;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>);
        }

        public override bool Equals(Tuple other)
        {
            return Equals(other as Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>);
        }

        public bool Equals(Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> other)
        {
            return this == (object) other ||
                   (object) other != null &&
                   (_item1.Equals(other._item1) || _item2.Equals(other._item2) || _item3.Equals(other._item3) ||
                    _item4.Equals(other._item4) || _item5.Equals(other._item5) || _item6.Equals(other._item6) ||
                    _item7.Equals(other._item7) || _item8.Equals(other._item8) || _item9.Equals(other._item9) ||
                    _item10.Equals(other._item10));
        }

        public override int GetHashCode()
        {
            return _item1.GetHashCode() ^ RotateRight(_item2.GetHashCode(), 1) ^ RotateRight(_item3.GetHashCode(), 2) ^
                   RotateRight(_item4.GetHashCode(), 3) ^ RotateRight(_item5.GetHashCode(), 4) ^
                   RotateRight(_item6.GetHashCode(), 5) ^ RotateRight(_item7.GetHashCode(), 6) ^
                   RotateRight(_item8.GetHashCode(), 7) ^ RotateRight(_item9.GetHashCode(), 8) ^
                   RotateRight(_item10.GetHashCode(), 9);
        }

        public override string ToString()
        {
            return ToString(null);
        }

        public override string ToString(IFormatProvider provider)
        {
            return string.Format(provider, "({1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10})", _item1, _item2, _item3,
                _item4, _item5, _item6, _item7, _item8, _item9, _item10);
        }

        public static bool operator ==(
            Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> tuple1, Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> tuple2
            )
        {
            return tuple1 == (object) tuple2 || (object) tuple1 == null && tuple1.Equals(tuple2);
        }

        public static bool operator !=(
            Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> tuple1, Tuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> tuple2
            )
        {
            return !(tuple1 == tuple2);
        }
    }

    #endregion // Denary (10-ary) Tuple

    #endregion // Tuples

    #region Property Change Event Support

    namespace ComponentModel
    {
        //[HostProtection(SecurityAction.LinkDemand, SharedState = true)]
        public static class EventHandlerUtility
        {
            public static bool InvokeCancelableEventHandler<TEventArgs>(EventHandler<TEventArgs> cancelableEventHandler,
                object sender, TEventArgs e)
                where TEventArgs : CancelEventArgs
            {
                if ((object) cancelableEventHandler == null)
                {
                    throw new ArgumentNullException("cancelableEventHandler");
                }
                if (e == null)
                {
                    throw new ArgumentNullException("e");
                }
                Delegate[] invocationList = cancelableEventHandler.GetInvocationList();
                for (int i = 0; i < invocationList.Length && !e.Cancel; i++)
                {
                    ((EventHandler<TEventArgs>) invocationList[i]).Invoke(sender, e);
                }
                return !e.Cancel;
            }

            public static void InvokeEventHandlerAsync<TEventArgs>(EventHandler<TEventArgs> eventHandler, object sender,
                TEventArgs e)
                where TEventArgs : EventArgs
            {
                if ((object) eventHandler == null)
                {
                    throw new ArgumentNullException("eventHandler");
                }
                Delegate[] invocationList = eventHandler.GetInvocationList();
                for (int i = 0; i < invocationList.Length; i++)
                {
                    var currentEventHandler = (EventHandler<TEventArgs>) invocationList[i];
                    currentEventHandler.BeginInvoke(sender, e, currentEventHandler.EndInvoke, null);
                }
            }

            public static void InvokeEventHandlerAsync<TEventArgs>(EventHandler<TEventArgs> eventHandler, object sender,
                TEventArgs e, PropertyChangedEventHandler secondaryHandler)
                where TEventArgs : PropertyChangedEventArgs
            {
                InvokeEventHandlerAsync(eventHandler, sender, e);
                if ((object) secondaryHandler != null)
                {
                    InvokeEventHandlerAsync(secondaryHandler, sender, e);
                }
            }

            public static void InvokeEventHandlerAsync(PropertyChangedEventHandler eventHandler, object sender,
                PropertyChangedEventArgs e)
            {
                if ((object) eventHandler == null)
                {
                    throw new ArgumentNullException("eventHandler");
                }
                Delegate[] invocationList = eventHandler.GetInvocationList();
                for (int i = 0; i < invocationList.Length; i++)
                {
                    var currentEventHandler = (PropertyChangedEventHandler) invocationList[i];
                    currentEventHandler.BeginInvoke(sender, e, currentEventHandler.EndInvoke, null);
                }
            }
        }

        [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
        public interface IPropertyChangeEventArgs<TClass, TProperty>
        {
            TClass Instance { get; }
            string PropertyName { get; }
            TProperty OldValue { get; }
            TProperty NewValue { get; }
        }

        [Serializable]
        //[HostProtection(SecurityAction.LinkDemand, SharedState = true)]
        [StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
        public class PropertyChangingEventArgs<TClass, TProperty> : CancelEventArgs,
            IPropertyChangeEventArgs<TClass, TProperty>
        {
            private readonly TClass _instance;
            private readonly string _propertyName;
            private readonly TProperty _oldValue;
            private readonly TProperty _newValue;

            public PropertyChangingEventArgs(TClass instance, string propertyName, TProperty oldValue,
                TProperty newValue)
            {
                if (instance == null)
                {
                    throw new ArgumentNullException("instance");
                }
                if (string.IsNullOrEmpty(propertyName))
                {
                    throw new ArgumentNullException("propertyName");
                }
                _instance = instance;
                _propertyName = propertyName;
                _oldValue = oldValue;
                _newValue = newValue;
            }

            public TClass Instance
            {
                get { return _instance; }
            }

            public string PropertyName
            {
                get { return _propertyName; }
            }

            public TProperty OldValue
            {
                get { return _oldValue; }
            }

            public TProperty NewValue
            {
                get { return _newValue; }
            }
        }

        [Serializable]
        //[HostProtection(SecurityAction.LinkDemand, SharedState = true)]
        [StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
        public class PropertyChangedEventArgs<TClass, TProperty> : PropertyChangedEventArgs,
            IPropertyChangeEventArgs<TClass, TProperty>
        {
            private readonly TClass _instance;
            private readonly TProperty _oldValue;
            private readonly TProperty _newValue;

            public PropertyChangedEventArgs(TClass instance, string propertyName, TProperty oldValue, TProperty newValue)
                : base(propertyName)
            {
                if (instance == null)
                {
                    throw new ArgumentNullException("instance");
                }
                if (string.IsNullOrEmpty(propertyName))
                {
                    throw new ArgumentNullException("propertyName");
                }
                _instance = instance;
                _oldValue = oldValue;
                _newValue = newValue;
            }

            public TClass Instance
            {
                get { return _instance; }
            }

            public override sealed string PropertyName
            {
                get { return base.PropertyName; }
            }

            public TProperty OldValue
            {
                get { return _oldValue; }
            }

            public TProperty NewValue
            {
                get { return _newValue; }
            }
        }
    }

    #endregion // Property Change Event Support
}

#endregion // Global Support Classes

