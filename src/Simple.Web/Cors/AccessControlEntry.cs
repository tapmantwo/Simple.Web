namespace Simple.Web.Cors
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class AccessControlEntry : IAccessControlEntry
    {
        private static readonly IEqualityComparer<IAccessControlEntry> OriginComparerInstance =
            new OriginEqualityComparer();

        private readonly bool? _credentials;
        private readonly string _exposeHeaders;
        private readonly string _allowHeaders;
        private readonly long? _maxAge;
        private readonly string _methods;
        private readonly string _origin;

        public AccessControlEntry(string origin, string methods = null, long? maxAge = null, string allowHeaders = null, bool? credentials = null, string exposeHeaders = null)
        {
            _origin = origin;
            _methods = methods;
            _maxAge = maxAge;
            _allowHeaders = allowHeaders;
            _credentials = credentials;
            _exposeHeaders = exposeHeaders;
        }

        public static IEqualityComparer<IAccessControlEntry> OriginComparer
        {
            get { return OriginComparerInstance; }
        }

        public string Origin
        {
            get { return _origin; }
        }

        public bool? Credentials
        {
            get { return _credentials; }
        }

        public string Methods
        {
            get { return _methods; }
        }

        public string AllowHeaders
        {
            get { return _allowHeaders; }
        }

        public long? MaxAge
        {
            get { return _maxAge; }
        }

        public string ExposeHeaders
        {
            get { return _exposeHeaders; }
        }

        private sealed class OriginEqualityComparer : IEqualityComparer<IAccessControlEntry>
        {
            public bool Equals(IAccessControlEntry x, IAccessControlEntry y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x.Origin, y.Origin);
            }

            public int GetHashCode(IAccessControlEntry obj)
            {
                return obj.Origin.GetHashCode();
            }
        }
    }

    public class AccessControlCollection : IDictionary<string, IAccessControlEntry>
    {
        private readonly IDictionary<string, IAccessControlEntry> _entries = new Dictionary<string, IAccessControlEntry>(StringComparer.OrdinalIgnoreCase);
        public IEnumerator<KeyValuePair<string, IAccessControlEntry>> GetEnumerator()
        {
            return _entries.GetEnumerator();
        }

        public void Add(KeyValuePair<string, IAccessControlEntry> item)
        {
            _entries.Add(item);
        }

        public void Clear()
        {
            _entries.Clear();
        }

        public bool Contains(KeyValuePair<string, IAccessControlEntry> item)
        {
            return _entries.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, IAccessControlEntry>[] array, int arrayIndex)
        {
            _entries.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<string, IAccessControlEntry> item)
        {
            return _entries.Remove(item);
        }

        public int Count
        {
            get { return _entries.Count; }
        }

        public bool IsReadOnly
        {
            get { return _entries.IsReadOnly; }
        }

        public bool ContainsKey(string key)
        {
            return _entries.ContainsKey(key);
        }

        public void Add(string key, IAccessControlEntry value)
        {
            _entries.Add(key, value);
        }

        public bool Remove(string key)
        {
            return _entries.Remove(key);
        }

        public bool TryGetValue(string key, out IAccessControlEntry value)
        {
            return _entries.TryGetValue(key, out value);
        }

        public IAccessControlEntry this[string key]
        {
            get { return _entries[key]; }
            set { _entries[key] = value; }
        }

        public ICollection<string> Keys
        {
            get { return _entries.Keys; }
        }

        public ICollection<IAccessControlEntry> Values
        {
            get { return _entries.Values; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}