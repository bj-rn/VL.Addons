using System.Collections.Generic;

namespace Collections.Generic
{
	partial class OrderedDictionary<TKey, TValue> : ICollection<KeyValuePair<TKey, TValue>>
	{
		/// <summary>
		/// Returns the count of items in the dictionary
		/// </summary>
		public int Count => _innerList.Count;

		bool ICollection<KeyValuePair<TKey,TValue>>.IsReadOnly => false;

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
		{
			_innerDictionary.Add(item.Key, item.Value);
			_innerList.Add(item);
		}
		/// <summary>
		/// Clears all the items from the dictionary
		/// </summary>
		public void Clear()
		{
			_innerDictionary.Clear();
			_innerList.Clear();
		}

		bool ICollection<KeyValuePair<TKey,TValue>>.Contains(KeyValuePair<TKey, TValue> item)
		{
			if (null == _comparer)
				return _innerList.Contains(item);
			for(int ic=_innerList.Count,i=0;i<ic;++i)
			{
				var kvp = _innerList[i];
				if(_comparer.Equals(item.Key,kvp.Key))
					if (Equals(item.Value, kvp.Value))
						return true;
			}
			return false;
		}
		/// <summary>
		/// Copies the items in the dictionary to the specified array, starting at the specified destination index
		/// </summary>
		/// <param name="array">The array to copy to</param>
		/// <param name="arrayIndex">The index into <paramref name="array"/> at which copying begins</param>
		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			_innerList.CopyTo(array, arrayIndex);
		}
		bool ICollection<KeyValuePair<TKey,TValue>>.Remove(KeyValuePair<TKey, TValue> item)
		{
			if ((_innerDictionary as ICollection<KeyValuePair<TKey, TValue>>).Remove(item))
				return _innerList.Remove(item); // should always return true
			return false;
		}

	}
}
