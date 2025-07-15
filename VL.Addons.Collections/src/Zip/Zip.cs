using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    public static class Zip
    {
        // https://stackoverflow.com/a/27533369
        public static IEnumerable<T> Interleave<T>(this IEnumerable<IEnumerable<T>> source)
        {
            var queues = source.Select(x => new Queue<T>(x)).ToList();
            while (queues.Any(x => x.Any()))
            {
                foreach (var queue in queues.Where(x => x.Any()))
                {
                    yield return queue.Dequeue();
                }
            }
        }
    }
}