using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace MySessionProvider
{
    public class SessionItemCollection : NameObjectCollectionBase, ISessionStateItemCollection, ICollection, IEnumerable
    {
        /// <inheritdoc />
        public void Remove(string name)
        {
            Debug.WriteLine(nameof(SessionItemCollection) + " " + nameof(Remove) + " " + name);

            if (session.ContainsKey(name))
            {
                session.Remove(name);
            }
        }

        /// <inheritdoc />
        public void RemoveAt(int index)
        {
            Debug.WriteLine(nameof(SessionItemCollection) + " " + nameof(RemoveAt) + " " + index);

            var key = session.Keys.ToArray()[index];

            if (session.ContainsKey(key))
            {
                session.Remove(key);
            }
        }

        /// <inheritdoc />
        public void Clear()
        {
            Debug.WriteLine(nameof(SessionItemCollection) + " " + nameof(Clear));
            session.Clear();
        }

        private Dictionary<string, object> session = new Dictionary<string, object>();

        /// <inheritdoc />
        public object this[string name]
        {
            get
            {
                Debug.WriteLine(nameof(SessionItemCollection) + $"Get this[{name}]");
                return !session.ContainsKey(name)
                    ? null
                    : session[name];
            }
            set
            {
                Debug.WriteLine(nameof(SessionItemCollection) + $"Set this[{name}]");
                session[name] = value;
            }
        }

        /// <inheritdoc />
        public object this[int index]
        {
            get
            {
                Debug.WriteLine(nameof(SessionItemCollection) + $"Get this[{index}]");
                var key = session.Keys.ToArray()[index];
                return session[key];
            }
            set
            {
                Debug.WriteLine(nameof(SessionItemCollection) + $"Set this[{index}]");
                var key = session.Keys.ToArray()[index];
                session[key] = value;
            }
        }

        private bool _dirty;

        /// <inheritdoc />
        public bool Dirty { get
            {
                Debug.WriteLine(nameof(SessionItemCollection) + " Dirty Get " + _dirty);
                return _dirty;
            }
            set
            {
                Debug.WriteLine(nameof(SessionItemCollection) + " Dirty Set " + _dirty);
                _dirty = value;
            }
        }
    }
}