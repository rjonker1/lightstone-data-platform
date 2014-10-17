using System;
using System.Globalization;
using System.Runtime;
using LightstoneApp.Domain.Core;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework
{
    /// <summary>
    ///     Represents a semantic version number.
    /// </summary>
    /// <filterpriority>1</filterpriority>
    [Serializable]
    public sealed class Version : ValueObject<Version>, ICloneable, IComparable, IComparable<Version>
    {
        private const string Message = "Version must be greater than or equal to zero";

        private int _publish = -1;
        private int _revision = -1;
        private int _major;
        private int _minor;

        /// <summary>
        ///     Gets the value of the major component of the version number for the current
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object.
        /// </summary>
        /// <returns>
        ///     The major version number.
        /// </returns>
        /// <filterpriority>1</filterpriority>

        public int Major
        {
            
            get { return _major; }
        }

        /// <summary>
        ///     Gets the value of the minor component of the version number for the current
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object.
        /// </summary>
        /// <returns>
        ///     The minor version number.
        /// </returns>
        /// <filterpriority>1</filterpriority>

        public int Minor
        {
            
            get { return _minor; }
        }

        /// <summary>
        ///     Gets the value of the Publish component of the version number for the current
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object.
        /// </summary>
        /// <returns>
        ///     The Publish number, or -1 if the Publish number is undefined.
        /// </returns>
        /// <filterpriority>1</filterpriority>

        public int Publish
        {
            
            get { return _publish; }
        }

        /// <summary>
        ///     Gets the value of the revision component of the version number for the current
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object.
        /// </summary>
        /// <returns>
        ///     The revision number, or -1 if the revision number is undefined.
        /// </returns>
        /// <filterpriority>1</filterpriority>

        public int Revision
        {
            // 
            get { return _revision; }
        }

        /// <summary>
        ///     Gets the high 16 bits of the revision number.
        /// </summary>
        /// <returns>
        ///     A 16-bit signed integer.
        /// </returns>

        public short MajorRevision
        {
    
            get { return (short) (_revision >> 16); }
        }

        /// <summary>
        ///     Gets the low 16 bits of the revision number.
        /// </summary>
        /// <returns>
        ///     A 16-bit signed integer.
        /// </returns>

        public short MinorRevision
        {
    
            get { return (short) (_revision & ushort.MaxValue); }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" />
        ///     class with the specified major, minor, Publish, and revision numbers.
        /// </summary>
        /// <param name="major">The major version number. </param>
        /// <param name="minor">The minor version number. </param>
        /// <param name="publish">The Publish number. </param>
        /// <param name="revision">The revision number. </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="major" />, <paramref name="minor" />,
        ///     <paramref name="publish" />, or <paramref name="revision" /> is less than zero.
        /// </exception>

        public Version(int major, int minor, int publish, int revision)
        {
            if (major < 0)
                throw new ArgumentOutOfRangeException("major", Message);
            if (minor < 0)
                throw new ArgumentOutOfRangeException("minor", Message);
            if (publish < 0)
                throw new ArgumentOutOfRangeException("publish", Message);
            if (revision < 0)
                throw new ArgumentOutOfRangeException("revision", Message);
            _major = major;
            _minor = minor;
            _publish = publish;
            _revision = revision;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" />
        ///     class using the specified major, minor, and Publish values.
        /// </summary>
        /// <param name="major">The major version number. </param>
        /// <param name="minor">The minor version number. </param>
        /// <param name="publish">The Publish number. </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="major" />, <paramref name="minor" />, or
        ///     <paramref name="publish" /> is less than zero.
        /// </exception>

        public Version(int major, int minor, int publish)
        {
            if (major < 0)
                throw new ArgumentOutOfRangeException("major", Message);
            if (minor < 0)
                throw new ArgumentOutOfRangeException("minor", Message);
            if (publish < 0)
                throw new ArgumentOutOfRangeException("publish", Message);
            _major = major;
            _minor = minor;
            _publish = publish;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" />
        ///     class using the specified major and minor values.
        /// </summary>
        /// <param name="major">The major version number. </param>
        /// <param name="minor">The minor version number. </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="major" /> or <paramref name="minor" /> is less
        ///     than zero.
        /// </exception>

        public Version(int major, int minor)
        {
            if (major < 0)
                throw new ArgumentOutOfRangeException("major", Message);
            if (minor < 0)
                throw new ArgumentOutOfRangeException("minor", Message);
            _major = major;
            _minor = minor;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" />
        ///     class using the specified string.
        /// </summary>
        /// <param name="version">
        ///     A string containing the major, minor, Publish, and revision numbers, where each number is delimited
        ///     with a period character ('.').
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="version" /> has fewer than two components or more than
        ///     four components.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="version" /> is null. </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">A major, minor, Publish, or revision component is less than zero. </exception>
        /// <exception cref="T:System.FormatException">
        ///     At least one component of <paramref name="version" /> does not parse to an
        ///     integer.
        /// </exception>
        /// <exception cref="T:System.OverflowException">
        ///     At least one component of <paramref name="version" /> represents a number
        ///     greater than <see cref="F:System.Int32.MaxValue" />.
        /// </exception>

        public Version(string version)
        {
            Version version1 = Parse(version);
            _major = version1.Major;
            _minor = version1.Minor;
            _publish = version1.Publish;
            _revision = version1.Revision;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" />
        ///     class.
        /// </summary>
        public Version()
        {
            _major = 0;
            _minor = 0;
        }

        /// <summary>
        ///     Determines whether two specified <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" />
        ///     objects are equal.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="v1" /> equals <paramref name="v2" />; otherwise, false.
        /// </returns>
        /// <param name="v1">The first <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object. </param>
        /// <param name="v2">The second <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object. </param>
        /// <filterpriority>3</filterpriority>

        public static bool operator ==(Version v1, Version v2)
        {
            if (ReferenceEquals(v1, null))
                return ReferenceEquals(v2, null);
            return v1.Equals(v2);
        }

        /// <summary>
        ///     Determines whether two specified <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" />
        ///     objects are not equal.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="v1" /> does not equal <paramref name="v2" />; otherwise, false.
        /// </returns>
        /// <param name="v1">The first <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object. </param>
        /// <param name="v2">The second <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object. </param>
        /// <filterpriority>3</filterpriority>

        public static bool operator !=(Version v1, Version v2)
        {
            return !(v1 == v2);
        }

        /// <summary>
        ///     Determines whether the first specified
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object is less than the second
        ///     specified <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="v1" /> is less than <paramref name="v2" />; otherwise, false.
        /// </returns>
        /// <param name="v1">The first <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object. </param>
        /// <param name="v2">The second <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object. </param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="v1" /> is null. </exception>
        /// <filterpriority>3</filterpriority>

        public static bool operator <(Version v1, Version v2)
        {
            if (v1 == null)
                throw new ArgumentNullException("v1");
            return v1.CompareTo(v2) < 0;
        }

        /// <summary>
        ///     Determines whether the first specified
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object is less than or equal to the
        ///     second <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="v1" /> is less than or equal to <paramref name="v2" />; otherwise, false.
        /// </returns>
        /// <param name="v1">The first <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object. </param>
        /// <param name="v2">The second <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object. </param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="v1" /> is null. </exception>
        /// <filterpriority>3</filterpriority>

        public static bool operator <=(Version v1, Version v2)
        {
            if (v1 == null)
                throw new ArgumentNullException("v1");
            return v1.CompareTo(v2) <= 0;
        }

        /// <summary>
        ///     Determines whether the first specified
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object is greater than the second
        ///     specified <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="v1" /> is greater than <paramref name="v2" />; otherwise, false.
        /// </returns>
        /// <param name="v1">The first <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object. </param>
        /// <param name="v2">The second <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object. </param>
        /// <filterpriority>3</filterpriority>

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public static bool operator >(Version v1, Version v2)
        {
            return v2 < v1;
        }

        /// <summary>
        ///     Determines whether the first specified
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object is greater than or equal to
        ///     the second specified <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="v1" /> is greater than or equal to <paramref name="v2" />; otherwise, false.
        /// </returns>
        /// <param name="v1">The first <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object. </param>
        /// <param name="v2">The second <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object. </param>
        /// <filterpriority>3</filterpriority>

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public static bool operator >=(Version v1, Version v2)
        {
            return v2 <= v1;
        }

        /// <summary>
        ///     Returns a new <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object whose value is
        ///     the same as the current <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object.
        /// </summary>
        /// <returns>
        ///     A new <see cref="T:System.Object" /> whose values are a copy of the current
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public object Clone()
        {
            return new Version
            {
                _major = _major,
                _minor = _minor,
                _publish = _publish,
                _revision = _revision
            };
        }

        /// <summary>
        ///     Compares the current <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object to a
        ///     specified object and returns an indication of their relative values.
        /// </summary>
        /// <returns>
        ///     A signed integer that indicates the relative values of the two objects, as shown in the following table.Return
        ///     value Meaning Less than zero The current
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object is a version before
        ///     <paramref name="version" />. Zero The current
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object is the same version as
        ///     <paramref name="version" />. Greater than zero The current
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object is a version subsequent to
        ///     <paramref name="version" />.-or- <paramref name="version" /> is null.
        /// </returns>
        /// <param name="version">An object to compare, or null. </param>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="version" /> is not of type
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" />.
        /// </exception>
        /// <filterpriority>1</filterpriority>
        public int CompareTo(object version)
        {
            if (version == null)
                return 1;
            var version1 = version as Version;
            if (version1 == null)
                throw new ArgumentException("Argument Must Be a Version");
            if (_major != version1._major)
                return _major > version1._major ? 1 : -1;
            if (_minor != version1._minor)
                return _minor > version1._minor ? 1 : -1;
            if (_publish != version1._publish)
            {
                return _publish > version1._publish ? 1 : -1;
            }
            if (_revision == version1._revision)
                return 0;
            return _revision > version1._revision ? 1 : -1;
        }

        /// <summary>
        ///     Compares the current <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object to a
        ///     specified <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object and returns an
        ///     indication of their relative values.
        /// </summary>
        /// <returns>
        ///     A signed integer that indicates the relative values of the two objects, as shown in the following table.Return
        ///     value Meaning Less than zero The current
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object is a version before
        ///     <paramref name="value" />. Zero The current
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object is the same version as
        ///     <paramref name="value" />. Greater than zero The current
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object is a version subsequent to
        ///     <paramref name="value" />. -or-<paramref name="value" /> is null.
        /// </returns>
        /// <param name="value">
        ///     A <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object to compare
        ///     to the current <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object, or null.
        /// </param>
        /// <filterpriority>1</filterpriority>

        public int CompareTo(Version value)
        {
            if (value == null)
                return 1;
            if (_major != value._major)
                return _major > value._major ? 1 : -1;
            if (_minor != value._minor)
                return _minor > value._minor ? 1 : -1;
            if (_publish != value._publish)
            {
                return _publish > value._publish ? 1 : -1;
            }
            if (_revision == value._revision)
                return 0;
            return _revision > value._revision ? 1 : -1;
        }

        /// <summary>
        ///     Returns a value indicating whether the current
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object is equal to a specified
        ///     object.
        /// </summary>
        /// <returns>
        ///     true if the current <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object and
        ///     <paramref name="obj" /> are both <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" />
        ///     objects, and every component of the current
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object matches the corresponding
        ///     component of <paramref name="obj" />; otherwise, false.
        /// </returns>
        /// <param name="obj">
        ///     An object to compare with the current
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object, or null.
        /// </param>
        /// <filterpriority>1</filterpriority>

        public override bool Equals(object obj)
        {
            var version = obj as Version;
            return !(version == null) && _major == version._major &&
                   (_minor == version._minor && _publish == version._publish) && _revision == version._revision;
        }

        /// <summary>
        ///     Returns a value indicating whether the current
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object and a specified
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object represent the same value.
        /// </summary>
        /// <returns>
        ///     true if every component of the current
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object matches the corresponding
        ///     component of the <paramref name="obj" /> parameter; otherwise, false.
        /// </returns>
        /// <param name="obj">
        ///     A <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object to compare
        ///     to the current <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object, or null.
        /// </param>
        /// <filterpriority>1</filterpriority>
        private new bool Equals(Version obj)
        {
            return !(obj == null) && _major == obj._major && (_minor == obj._minor && _publish == obj._publish) &&
                   _revision == obj._revision;
        }

        /// <summary>
        ///     Returns a hash code for the current <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" />
        ///     object.
        /// </summary>
        /// <returns>
        ///     A 32-bit signed integer hash code.
        /// </returns>
        /// <filterpriority>2</filterpriority>

        public override int GetHashCode()
        {
            return 0 | (_major & 15) << 28 | (_minor & byte.MaxValue) << 20 | (_publish & byte.MaxValue) << 12 |
                   _revision & 4095;
        }

        /// <summary>
        ///     Converts the value of the current <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" />
        ///     object to its equivalent <see cref="T:System.String" /> representation.
        /// </summary>
        /// <returns>
        ///     The <see cref="T:System.String" /> representation of the values of the major, minor, Publish, and revision components
        ///     of the current <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object, as depicted
        ///     in the following format. Each component is separated by a period character ('.'). Square brackets ('[' and ']')
        ///     indicate a component that will not appear in the return value if the component is not defined:
        ///     major.minor[.Publish[.revision]] For example, if you create a
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object using the constructor
        ///     Version(1,1), the returned string is "1.1". If you create a
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object using the constructor
        ///     Version(1,3,4,2), the returned string is "1.3.4.2".
        /// </returns>
        /// <filterpriority>1</filterpriority>

        public override string ToString()
        {
            if (_publish == -1)
                return ToString(2);
            if (_revision == -1)
                return ToString(3);
            return ToString(4);
        }

        /// <summary>
        ///     Converts the value of the current <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" />
        ///     object to its equivalent <see cref="T:System.String" /> representation. A specified count indicates the number of
        ///     components to return.
        /// </summary>
        /// <returns>
        ///     The <see cref="T:System.String" /> representation of the values of the major, minor, Publish, and revision components
        ///     of the current <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object, each
        ///     separated by a period character ('.'). The <paramref name="fieldCount" /> parameter determines how many components
        ///     are returned.fieldCount Return Value 0 An empty string (""). 1 major 2 major.minor 3 major.minor.Publish 4
        ///     major.minor.Publish.revision For example, if you create
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object using the constructor
        ///     Version(1,3,5), ToString(2) returns "1.3" and ToString(4) throws an exception.
        /// </returns>
        /// <param name="fieldCount">The number of components to return. The <paramref name="fieldCount" /> ranges from 0 to 4. </param>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="fieldCount" /> is less than 0, or more than 4.-or-
        ///     <paramref name="fieldCount" /> is more than the number of components defined in the current
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object.
        /// </exception>
        /// <filterpriority>1</filterpriority>

        public string ToString(int fieldCount)
        {
            switch (fieldCount)
            {
                case 0:
                    return string.Empty;
                case 1:
                    return string.Concat(_major);
                case 2:
                    return (string) (object) _major + (object) "." + (string) (object) _minor;
                default:
                    if (_publish == -1)
                        throw new ArgumentException("ArgumentOutOfRange_Bounds_Lower_Upper");
                    if (fieldCount == 3)
                        return (string) (object) _major + (object) "." + (string) (object) _minor + "." +
                               (string) (object) _publish;
                    if (_revision == -1)
                        throw new ArgumentException("ArgumentOutOfRange_Bounds_Lower_Upper");
                    if (fieldCount == 4)
                        return (string) (object) Major + (object) "." + (string) (object) _minor + "." +
                               (string) (object) _publish + "." + (string) (object) _revision;
                    throw new ArgumentException("ArgumentOutOfRange_Bounds_Lower_Upper");
            }
        }

        /// <summary>
        ///     Converts the string representation of a version number to an equivalent
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object.
        /// </summary>
        /// <returns>
        ///     An object that is equivalent to the version number specified in the <paramref name="input" /> parameter.
        /// </returns>
        /// <param name="input">A string that contains a version number to convert.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="input" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="input" /> has fewer than two or more than four version
        ///     components.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     At least one component in <paramref name="input" /> is less than
        ///     zero.
        /// </exception>
        /// <exception cref="T:System.FormatException">At least one component in <paramref name="input" /> is not an integer.</exception>
        /// <exception cref="T:System.OverflowException">
        ///     At least one component in <paramref name="input" /> represents a number
        ///     that is greater than <see cref="F:System.Int32.MaxValue" />.
        /// </exception>

        public static Version Parse(string input)
        {
            if (input == null)
                throw new ArgumentNullException("input");
            var result = new VersionResult();
            result.Init("input", true);
            if (!TryParseVersion(input, ref result))
                throw result.GetVersionParseException();
            return result.MParsedVersion;
        }

        /// <summary>
        ///     Tries to convert the string representation of a version number to an equivalent
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object, and returns a value that
        ///     indicates whether the conversion succeeded.
        /// </summary>
        /// <returns>
        ///     true if the <paramref name="input" /> parameter was converted successfully; otherwise, false.
        /// </returns>
        /// <param name="input">A string that contains a version number to convert.</param>
        /// <param name="result">
        ///     When this method returns, contains the
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> equivalent of the number that is
        ///     contained in <paramref name="input" />, if the conversion succeeded, or a
        ///     <see cref="T:LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version" /> object whose major and minor
        ///     version numbers are 0 if the conversion failed.
        /// </param>

        public static bool TryParse(string input, out Version result)
        {
            var result1 = new VersionResult();
            result1.Init("input", false);
            bool flag = TryParseVersion(input, ref result1);
            result = result1.MParsedVersion;
            return flag;
        }

        private static bool TryParseVersion(string version, ref VersionResult result)
        {
            if (version == null)
            {
                result.SetFailure(ParseFailureKind.ArgumentNullException);
                return false;
            }
            string[] strArray = version.Split('.');
            int length = strArray.Length;
            if (length < 2 || length > 4)
            {
                result.SetFailure(ParseFailureKind.ArgumentException);
                return false;
            }
            int parsedComponent1;
            int parsedComponent2;
            if (!TryParseComponent(strArray[0], "version", ref result, out parsedComponent1) ||
                !TryParseComponent(strArray[1], "version", ref result, out parsedComponent2))
                return false;
            int num = length - 2;
            if (num > 0)
            {
                int parsedComponent3;
                if (!TryParseComponent(strArray[2], "Publish", ref result, out parsedComponent3))
                    return false;
                if (num - 1 > 0)
                {
                    int parsedComponent4;
                    if (!TryParseComponent(strArray[3], "revision", ref result, out parsedComponent4))
                        return false;
                    result.MParsedVersion = new Version(parsedComponent1, parsedComponent2, parsedComponent3,
                        parsedComponent4);
                }
                else
                    result.MParsedVersion = new Version(parsedComponent1, parsedComponent2, parsedComponent3);
            }
            else
                result.MParsedVersion = new Version(parsedComponent1, parsedComponent2);
            return true;
        }

        private static bool TryParseComponent(string component, string componentName, ref VersionResult result,
            out int parsedComponent)
        {
            if (!int.TryParse(component, NumberStyles.Integer, CultureInfo.InvariantCulture, out parsedComponent))
            {
                result.SetFailure(ParseFailureKind.FormatException, component);
                return false;
            }
            if (parsedComponent >= 0)
                return true;
            result.SetFailure(ParseFailureKind.ArgumentOutOfRangeException, componentName);
            return false;
        }

        private enum ParseFailureKind
        {
            ArgumentNullException,
            ArgumentException,
            ArgumentOutOfRangeException,
            FormatException,
        }

        private struct VersionResult
        {
            internal Version MParsedVersion;
            private ParseFailureKind _mFailure;
            private string _mExceptionArgument;
            private string _mArgumentName;
            private bool _mCanThrow;

            internal void Init(string argumentName, bool canThrow)
            {
                _mCanThrow = canThrow;
                _mArgumentName = argumentName;
            }

            internal void SetFailure(ParseFailureKind failure)
            {
                SetFailure(failure, string.Empty);
            }

            internal void SetFailure(ParseFailureKind failure, string argument)
            {
                _mFailure = failure;
                _mExceptionArgument = argument;
                if (_mCanThrow)
                    throw GetVersionParseException();
            }

            internal Exception GetVersionParseException()
            {
                switch (_mFailure)
                {
                    case ParseFailureKind.ArgumentNullException:
                        return new ArgumentNullException(_mArgumentName);
                    case ParseFailureKind.ArgumentException:
                        return new ArgumentException("Arg_VersionString");
                    case ParseFailureKind.ArgumentOutOfRangeException:
                        return new ArgumentOutOfRangeException(_mExceptionArgument, Message);
                    case ParseFailureKind.FormatException:
                        try
                        {
                            int.Parse(_mExceptionArgument, CultureInfo.InvariantCulture);
                        }
                        catch (FormatException ex)
                        {
                            return ex;
                        }
                        catch (OverflowException ex)
                        {
                            return ex;
                        }
                        return new FormatException("Format_InvalidString");
                    default:
                        return new ArgumentException("Arg_VersionString");
                }
            }
        }
    }
}
