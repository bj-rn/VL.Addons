using System.Collections;
using System.Collections.Generic;

namespace Collections.Generic
{
	partial class OrderedDictionary<TKey, TValue> : IList<KeyValuePair<TKey, TValue>>
	{
		/// <summary>
		/// Removes the item at the specified index
		/// </summary>
		/// <param name="index">The index of the item to remove</param>
		public void RemoveAt(int index)
		{
			var key = _innerList[index].Key;
			_innerDictionary.Remove(key);
			_innerList.RemoveAt(index);
		}
		int IList<KeyValuePair<TKey, TValue>>.IndexOf(KeyValuePair<TKey, TValue> item)
			=> _innerList.IndexOf(item);
		void IList<KeyValuePair<TKey, TValue>>.Insert(int index,KeyValuePair<TKey, TValue> item)
		{
			_innerDictionary.Add(item.Key, item.Value);
			_innerList.Insert(index, item);
		}
		KeyValuePair<TKey, TValue> IList<KeyValuePair<TKey, TValue>>.this[int index] {
			get {
				return _innerList[index];
			}
			set {
				_innerList[index]=value;
			}
		}
	}
}
