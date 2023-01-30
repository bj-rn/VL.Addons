using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Collections.Generic
{
	partial class OrderedDictionary<TKey, TValue>
	{
		private sealed class ValuesCollection : ICollection<TValue>
		{
			OrderedDictionary<TKey, TValue> _outer;
			public ValuesCollection(OrderedDictionary<TKey, TValue> outer)
			{
				_outer = outer;
			}
			public int Count => _outer.Count;
			public bool Contains(TValue value)
			{
				for(int ic = Count,i=0;i<ic;++i)
					if (Equals(_outer._innerList[i].Value, value))
						return true;
				return false;
			}
			public void CopyTo(TValue[] array, int index)
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
					array[i + index] = _outer._innerList[i].Value;
			}
			public IEnumerator<TValue> GetEnumerator()
				=> new Enumerator(_outer);
			IEnumerator IEnumerable.GetEnumerator()
				=> GetEnumerator();
			void ICollection<TValue>.Add(TValue value)
				=> throw new NotSupportedException("The collection is read only.");
			bool ICollection<TValue>.Remove(TValue value)
				=> throw new NotSupportedException("The collection is read only.");
			void ICollection<TValue>.Clear()
				=> throw new NotSupportedException("The collection is read only.");
			bool ICollection<TValue>.IsReadOnly => true;
			// this is the meat of our enumeration capabilities
			struct Enumerator : IEnumerator<TValue>
			{
				IEnumerator<KeyValuePair<TKey, TValue>> _inner;
				public Enumerator(OrderedDictionary<TKey, TValue> outer)
				{
					_inner = outer.GetEnumerator();
				}
				public void Reset()
					=> _inner.Reset();
				void IDisposable.Dispose()
					=> _inner.Dispose();
				public bool MoveNext()
					=> _inner.MoveNext();
				public TValue Current
					=> _inner.Current.Value;
				object IEnumerator.Current
					=> Current;
			}
		}
	}
}
