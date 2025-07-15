using System.Collections.Generic;

namespace Collections.Generic
{
	/// <summary>
	/// Represents a dictionary where the items are in an explicit and indexable order
	/// </summary>
	/// <typeparam name="TKey">The type of the keys in this dictionary</typeparam>
	/// <typeparam name="TValue">The type of the values in this dictionary</typeparam>
	public partial class OrderedDictionary<TKey,TValue>
	{
		// we keep these synced
		List<KeyValuePair<TKey,TValue>> _innerList;
		Dictionary<TKey, TValue> _innerDictionary;
		IEqualityComparer<TKey> _comparer = null;
		/// <summary>
		/// Creates an ordered dictionary with the specified capacity and comparer
		/// </summary>
		/// <param name="capacity">The initial capacity</param>
		/// <param name="comparer">The comparer</param>
		public OrderedDictionary(int capacity,IEqualityComparer<TKey> comparer)
		{
			_innerDictionary = new Dictionary<TKey, TValue>(capacity, comparer);
			_innerList = new List<KeyValuePair<TKey,TValue>>(capacity);
			_comparer = comparer;
		}
		/// <summary>
		/// Creates an ordered dictionary with the specified items and the specified comparer
		/// </summary>
		/// <param name="collection">The collection or dictionary to copy from</param>
		/// <param name="comparer">The comparer to use</param>
		public OrderedDictionary(IEnumerable<KeyValuePair<TKey,TValue>> collection, IEqualityComparer<TKey> comparer)
		{
			_innerDictionary = new Dictionary<TKey, TValue>(comparer);
			_innerList = new List<KeyValuePair<TKey, TValue>>();
			_AddValues(collection);
			_comparer = comparer;
		}
		/// <summary>
		/// Creates an ordered dictionary with the specified capacity
		/// </summary>
		/// <param name="capacity">The initial capacity</param>
		public OrderedDictionary(int capacity)
		{
			_innerDictionary = new Dictionary<TKey, TValue>(capacity);
			_innerList = new List<KeyValuePair<TKey, TValue>>(capacity);
		}
		/// <summary>
		/// Creates an ordered dictionary filled with the specified collection or dictionary
		/// </summary>
		/// <param name="collection">The collection or dictionary to copy</param>
		public OrderedDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection)
		{
			_innerDictionary = new Dictionary<TKey, TValue>();
			_innerList = new List<KeyValuePair<TKey, TValue>>();
			_AddValues(collection);
		}
		/// <summary>
		/// Creates an ordered dictionary with the specified comparer
		/// </summary>
		/// <param name="comparer">The equality comparer to use for the keys</param>
		public OrderedDictionary(IEqualityComparer<TKey> comparer)
		{
			_innerDictionary = new Dictionary<TKey, TValue>(comparer);
			_innerList = new List<KeyValuePair<TKey, TValue>>();
			_comparer = comparer;
		}
		/// <summary>
		/// Creates a default instance of the ordered dictionary
		/// </summary>
		public OrderedDictionary()
		{
			_innerDictionary = new Dictionary<TKey, TValue>();
			_innerList = new List<KeyValuePair<TKey, TValue>>();
		}
		/// <summary>
		/// Gets the value at the specified index
		/// </summary>
		/// <param name="index">The index of the value to retrieve</param>
		/// <returns>The value of the item at the specified index</returns>
		public TValue GetAt(int index)
		{
			return _innerList[index].Value;
		}
		/// <summary>
		/// Sets the value at the specified index
		/// </summary>
		/// <param name="index">The index of the value to set</param>
		/// <param name="value">The new value to assign</param>
		public void SetAt(int index,TValue value)
		{
			var key = _innerList[index].Key;
			_innerList[index] = new KeyValuePair<TKey, TValue>(key, value);
			_innerDictionary[key] = value;
		}
		/// <summary>
		/// Inserts an item into the ordered dictionary at the specified position
		/// </summary>
		/// <param name="index">The index to insert the item before</param>
		/// <param name="key">The key of the new item</param>
		/// <param name="value">The value of the new item</param>
		public void Insert(int index, TKey key, TValue value)
			=> (this as IList<KeyValuePair<TKey, TValue>>).Insert(index, new KeyValuePair<TKey, TValue>(key, value));
		void _AddValues(IEnumerable<KeyValuePair<TKey,TValue>> collection)
		{
			foreach (var kvp in collection)
			{
				_innerDictionary.Add(kvp.Key, kvp.Value);
				_innerList.Add(kvp);
			}
		}
	}
}
