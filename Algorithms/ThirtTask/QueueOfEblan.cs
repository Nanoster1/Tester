using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.FirstTask.ThirtTask
{
	public class QueueOfEblan<T> : IEnumerable<T>, IReadOnlyCollection<T>
	{
		private LinkedList<T> list;
		public QueueOfEblan() { }
		public QueueOfEblan(T fitstValue)
		{
			list = new LinkedList<T>(fitstValue);
		}
		public QueueOfEblan(IEnumerable<T> collection)
		{
			foreach (var item in collection)
				if (list == null)
					list = new LinkedList<T>(item);
				else
					list.AddInEnd(item);
		}
		public int Count => list.Count;
		/// <summary>
		/// Add elemnt to begin of collection
		/// </summary>
		/// <param name="node">node that will be linked with this node</param>
		public void Enqueue(T value)
		{
			if (list == null)
				list = new LinkedList<T>(value);
			else
				list.AddOnBegin(value);
		}

		public T Dequeue()
		{
			return list != null ? list.RemoveLastNode(): throw new Exception("Collection is Empty");
		}
		public IEnumerator<T> GetEnumerator()
		{
			return list == null ? throw new Exception("Empty Quere") : list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
