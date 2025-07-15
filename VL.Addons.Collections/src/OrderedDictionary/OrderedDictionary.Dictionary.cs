using System;
using System.Collections.Generic;
using System.Text;

namespace Collections.Generic
{
	partial class OrderedDictionary<TKey,TValue> : IDictionary<TKey,TValue>
	{
		/// <summary>
		/// Adds an item to the end of the dictionary
		/// </summary>
		/// <param name="key">The key to add</param>
		/// <param name="value">The value to add</param>
		public void Add(TKey key, TValue value)
			=> (this as ICollection<KeyValuePair<TKey, TValue>>).Add(new KeyValuePair<TKey, TValue>(key,value));
		/// <summary>
		/// Indicates whether the specified key is contained in the dictionary
		/// </summary>
		/// <param name="key">The key to look for</param>
		/// <returns>True if the key is present in the dictionary, otherwise false</returns>
		public bool ContainsKey(TKey key)
			=> _innerDictionary.ContainsKey(key);
		/// <summary>
		/// Removes an item from the dictionary
		/// </summary>
		/// <param name="key">The key of the item to remove</param>
		/// <returns>True if the item was removed, or false if not found</returns>
		public bool Remove(TKey key)
		{
			TValue value;
			if(_innerDictionary.TryGetValue(key, out value))
			{
				_innerDictionary.Remove(key);
				_innerList.Remove(new KeyValuePair<TKey, TValue>(key,value));
				return true;
			}
			return false;
		}
		/// <summary>
		/// Attempts to retrieve the value for the specified key
		/// </summary>
		/// <param name="key">The key to look up</param>
		/// <param name="value">The value to return</param>
		/// <returns>True if the key is present, otherwise false</returns>
		public bool TryGetValue(TKey key, out TValue value)
			=> _innerDictionary.TryGetValue(key, out value);
		/// <summary>
		/// Gets or sets the value at the specified key
		/// </summary>
		/// <param name="key">The key to look up</param>
		/// <returns>The value</returns>
		public TValue this[TKey key] {
			get =>_innerDictionary[key];
			set {
				TValue v;
				if (_innerDictionary.TryGetValue(key, out v))
				{
					// change an existing key
					_innerDictionary[key] = value;
					_innerList[_innerList.IndexOf(new KeyValuePair<TKey, TValue>(key,v))] = new KeyValuePair<TKey, TValue>(key, value);
				} else
				{
					_innerDictionary.Add(key, value);
					_innerList.Add(new KeyValuePair<TKey,TValue>(key,value));
				}
			}
		}
		/// <summary>
		/// Indicates the keys in this dictionary
		/// </summary>
		public ICollection<TKey> Keys
			=> new KeysCollection(this);
		/// <summary>
		/// Indicates the value in this dictionary
		/// </summary>
		public ICollection<TValue> Values
			=> new ValuesCollection(this);
	}
}
