namespace Simple.Web.Cors
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class AccessControlCollection
    {
        private readonly IDictionary<string, IAccessControlEntry> _entries = new Dictionary<string, IAccessControlEntry>(StringComparer.OrdinalIgnoreCase);

        public void Add(IAccessControlEntry entry)
        {
            _entries.Add(entry.Origin, entry);
        }

        public bool TryGetEntry(string origin, out IAccessControlEntry entry)
        {
            return _entries.TryGetValue(origin, out entry);
        }
    }
}