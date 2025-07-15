using System.Collections;
using System.Collections.Generic;

namespace Collections.Generic
{
	partial class OrderedDictionary<TKey,TValue> : IEnumerable<KeyValuePair<TKey,TValue>>
	{
		/// <summary>
		/// Gets an enumerator for this dictionary
		/// </summary>
		/// <returns>A new enumerator suitable for iterating through the items in the dictionary in stored order</returns>
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
			=> _innerList.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator()
			=> GetEnumerator();
	}
}
