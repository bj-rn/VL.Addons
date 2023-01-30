using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Collections.Generic
{
	partial class OrderedDictionary<TKey,TValue>
	{
		private sealed class KeysCollection : ICollection<TKey>
		{
			OrderedDictionary<TKey, TValue> _outer;
			public KeysCollection(OrderedDictionary<TKey, TValue> outer)
			{
				_outer = outer;
			}
			public int Count => _outer.Count;
			public bool Contains(TKey key)
				=> _outer.ContainsKey(key);
			public void CopyTo(TKey[] array, int index)
			{
				var count = _outer.Count;
				// check our parameters for validity
				if (null == array)
					throw new ArgumentNullException(nameof(array));
				if (1 != array.Rank || 0 != array.GetLowerBound(0))
					throw new ArgumentException("The array is not an SZArray", nameof(array));
				if (0 > index)
					throw new ArgumentOutOfRangeException(nameof(index),
						  "The index cannot be less than zero.");
				if (array.Length <= index)
					throw new ArgumentOutOfRangeException(nameof(index),
						  "The index cannot be greater than the length of the array.");
				if (count > array.Length + index)
					throw new ArgumentException
					("The array is not big enough to hold the collection entries.", nameof(array));
				for (var i = 0; i < count; ++i)
					array[i + index] = _outer._innerList[i].Key;
			}
			public IEnumerator<TKey> GetEnumerator()
				=> new Enumerator(_outer);
			IEnumerator IEnumerable.GetEnumerator()
				=> GetEnumerator();
			void ICollection<TKey>.Add(TKey key)
				=> throw new NotSupportedException("The collection is read only.");
			bool ICollection<TKey>.Remove(TKey key)
				=> throw new NotSupportedException("The collection is read only.");
			void ICollection<TKey>.Clear()
				=> throw new NotSupportedException("The collection is read only.");
			bool ICollection<TKey>.IsReadOnly => true;
			// this is the meat of our enumeration capabilities
			struct Enumerator : IEnumerator<TKey>
			{
				IEnumerator<KeyValuePair<TKey, TValue>> _inner;
				public Enumerator(OrderedDictionary<TKey,TValue> outer)
				{
					_inner = outer.GetEnumerator();
				}
				public void Reset()
					=> _inner.Reset();
				void IDisposable.Dispose()
					=> _inner.Dispose();
				public bool MoveNext()
					=> _inner.MoveNext();
				public TKey Current
					=> _inner.Current.Key;
				object IEnumerator.Current 
					=> Current;
			}
		}
	}
}
