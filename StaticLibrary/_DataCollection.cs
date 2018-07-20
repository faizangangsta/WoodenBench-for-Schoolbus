using System;
using System.Collections;
using System.Collections.Generic;

namespace WBPlatform.StaticClasses
{
    public class AutoDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> _dict = new Dictionary<TKey, TValue>();

        public TValue this[TKey key]
        {
            get
            {
                if (((IDictionary<TKey, TValue>)_dict).ContainsKey(key))
                {
                    return ((IDictionary<TKey, TValue>)_dict)[key];
                }
                else
                {
                    return default(TValue);
                }

            }
            set
            {
                if (ContainsKey(key))
                {
                    ((IDictionary<TKey, TValue>)_dict)[key] = value;
                }
                else
                {
                    Add(key, value);
                }
            }
        }

        public ICollection<TKey> Keys => ((IDictionary<TKey, TValue>)_dict).Keys;

        public ICollection<TValue> Values => ((IDictionary<TKey, TValue>)_dict).Values;

        public int Count => ((IDictionary<TKey, TValue>)_dict).Count;

        public bool IsReadOnly => ((IDictionary<TKey, TValue>)_dict).IsReadOnly;

        public void Add(TKey key, TValue value) => ((IDictionary<TKey, TValue>)_dict).Add(key, value);
        public void Add(KeyValuePair<TKey, TValue> item) => ((IDictionary<TKey, TValue>)_dict).Add(item);
        public void Clear() => ((IDictionary<TKey, TValue>)_dict).Clear();
        public bool Contains(KeyValuePair<TKey, TValue> item) => ((IDictionary<TKey, TValue>)_dict).Contains(item);
        public bool ContainsKey(TKey key) => ((IDictionary<TKey, TValue>)_dict).ContainsKey(key);
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => ((IDictionary<TKey, TValue>)_dict).CopyTo(array, arrayIndex);
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => ((IDictionary<TKey, TValue>)_dict).GetEnumerator();
        public bool Remove(TKey key) => ((IDictionary<TKey, TValue>)_dict).Remove(key);
        public bool Remove(KeyValuePair<TKey, TValue> item) => ((IDictionary<TKey, TValue>)_dict).Remove(item);
        public bool TryGetValue(TKey key, out TValue value) => ((IDictionary<TKey, TValue>)_dict).TryGetValue(key, out value);
        IEnumerator IEnumerable.GetEnumerator() => ((IDictionary<TKey, TValue>)_dict).GetEnumerator();

        public static implicit operator AutoDictionary<TKey, TValue>(Dictionary<TKey, TValue> v)
        {
            return new AutoDictionary<TKey, TValue>() { _dict = v };
        }
        public static implicit operator Dictionary<TKey,TValue>(AutoDictionary<TKey,TValue> v)
        {
            return new Dictionary<TKey, TValue>(v._dict);
        }
    }
}
