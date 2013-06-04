namespace Simple.Web.EndToEndTests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class HeaderDictionary : IDictionary<string, string[]>
    {
        private readonly IDictionary<string, string[]> _headers = new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase);
        public IEnumerator<KeyValuePair<string, string[]>> GetEnumerator()
        {
            return _headers.GetEnumerator();
        }

        public void Add(KeyValuePair<string, string[]> item)
        {
            _headers.Add(item);
        }

        public void Clear()
        {
            _headers.Clear();
        }

        public bool Contains(KeyValuePair<string, string[]> item)
        {
            return _headers.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, string[]>[] array, int arrayIndex)
        {
            _headers.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<string, string[]> item)
        {
            return _headers.Remove(item);
        }

        public int Count
        {
            get { return _headers.Count; }
        }

        public bool IsReadOnly
        {
            get { return _headers.IsReadOnly; }
        }

        public bool ContainsKey(string key)
        {
            return _headers.ContainsKey(key);
        }

        public void Add(string key, string value)
        {
            Add(key, new[] {value});
        }

        public void Add(string key, string[] value)
        {
            _headers.Add(key, value);
        }

        public bool Remove(string key)
        {
            return _headers.Remove(key);
        }

        public bool TryGetValue(string key, out string[] value)
        {
            return _headers.TryGetValue(key, out value);
        }

        public string[] this[string key]
        {
            get { return _headers[key]; }
            set { _headers[key] = value; }
        }

        public ICollection<string> Keys
        {
            get { return _headers.Keys; }
        }

        public ICollection<string[]> Values
        {
            get { return _headers.Values; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}