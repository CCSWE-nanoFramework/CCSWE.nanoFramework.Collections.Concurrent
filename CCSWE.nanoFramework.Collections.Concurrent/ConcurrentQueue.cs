using System;
using System.Collections;

namespace CCSWE.nanoFramework.Collections.Concurrent
{
    /// <summary>
    /// A thread-safe implementation of a queue.
    /// </summary>
    /// <remarks>
    /// This is a brute force implementation using lock().
    /// Normally I would use a ReaderWriterLockSlim to optimize performance but this will work for now.
    /// </remarks>
    [Serializable]
    public class ConcurrentQueue : ICollection, ICloneable
    {
        private readonly object _lock = new();
        private readonly Queue _queue;

        /// <summary>
        /// Initializes a new instance of the ConcurrentQueue class that is empty, has the default initial capacity, and uses the default growth factor (2x).
        /// </summary>
        public ConcurrentQueue(): this(new Queue())
        {

        }

        private ConcurrentQueue(Queue? queue)
        {
            _queue = queue ?? new Queue();
        }

        /// <summary>
        /// Gets the number of elements contained in the ConcurrentQueue.
        /// </summary>
        public int Count
        {
            get
            {
                lock (_lock)
                {
                    return _queue.Count;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether access to the ConcurrentQueue is synchronized (thread safe).
        /// Always return true.
        /// </summary>
        public bool IsSynchronized => true;

        /// <summary>
        /// Gets an object that can be used to synchronize access to the ConcurrentQueue.
        /// </summary>
        /// <remarks>
        /// All calls are already synchronized so callers do not need to use this.
        /// </remarks>
        public object SyncRoot => this;

        /// <summary>
        /// Removes all objects from the ConcurrentQueue.
        /// </summary>
        public void Clear()
        {
            lock (_lock)
            {
                _queue.Clear();
            }
        }

        /// <summary>
        /// Creates a shallow copy of the ConcurrentQueue.
        /// </summary>
        /// <returns>
        /// A shallow copy of the ConcurrentQueue.
        /// </returns>
        public object Clone()
        {
            lock (_lock)
            {
                return new ConcurrentQueue((Queue) _queue.Clone());
            }
        }

        /// <summary>
        /// Determines whether an element is in the ConcurrentQueue.
        /// </summary>
        /// <param name="item">The object to locate in the ConcurrentQueue.</param>
        /// <returns>true if obj is found in the ConcurrentQueue; otherwise, false.</returns>
        public bool Contains(object item)
        {
            lock (_lock)
            {
                return _queue.Contains(item);
            }
        }

        /// <summary>
        /// Copies the ConcurrentQueue elements to an existing one-dimensional Array, starting at the specified array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from ConcurrentQueue.</param>
        /// <param name="index">The zero-based index in array at which copying begins.</param>
        public void CopyTo(Array array, int index)
        {
            lock (_lock)
            {
                ((Queue) _queue.Clone()).CopyTo(array, index);
            }
        }

        /// <summary>
        /// Removes and returns the object at the beginning of the ConcurrentQueue.
        /// </summary>
        /// <returns>The object that is removed from the beginning of the ConcurrentQueue.</returns>
        public object Dequeue()
        {
            lock (_lock)
            {
                return _queue.Dequeue();
            }
        }

        /// <summary>Adds an object to the end of the ConcurrentQueue.</summary>
        /// <param name="item">The object to add to the ConcurrentQueue.</param>
        public void Enqueue(object item)
        {
            lock (_lock)
            {
                _queue.Enqueue(item);
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the ConcurrentQueue.
        /// </summary>
        /// <returns>An IEnumerator for the ConcurrentQueue.</returns>
        public IEnumerator GetEnumerator()
        {
            lock (_lock)
            {
                return ((Queue)_queue.Clone()).GetEnumerator();
            }
        }

        /// <summary>
        /// Returns the object at the beginning of the ConcurrentQueue without removing it.
        /// </summary>
        /// <returns>The object at the beginning of the ConcurrentQueue.</returns>
        public object Peek()
        {
            lock (_lock)
            {
                return _queue.Peek();
            }
        }

        /// <summary>
        /// Copies the ConcurrentQueue elements to a new array. The order of the elements in the new
        /// array is the same as the order of the elements from the beginning of the ConcurrentQueue
        /// to its end.
        /// </summary>
        /// <returns>A new array containing elements copied from the ConcurrentQueue.</returns>
        public object[] ToArray()
        {
            lock (_lock)
            {
                return _queue.ToArray();
            }
        }

        /// <summary>
        /// Attempts to remove the object at the beginning of the ConcurrentQueue.
        /// </summary>
        /// <returns>true if an object was removed from the beginning of the ConcurrentQueue; otherwise false</returns>
        public bool TryDequeue(out object? item)
        {
            lock (_lock)
            {
                item = _queue.Count > 0 ? _queue.Dequeue() : null;
            }

            return item is not null;
        }
    }
}
