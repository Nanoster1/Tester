using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.FirstTask.ThirtTask
{
	public class Queue2<T> : IEnumerable<T>, IReadOnlyCollection<T>
	{
		private LinkedList<T> list;
		public Queue2() { }
		public Queue2(T fitstValue)
		{
			list = new LinkedList<T>(fitstValue,1);
		}
		public Queue2(IEnumerable<T> collection)
		{
			foreach (var item in collection)
				if (list == null)
					list = new LinkedList<T>(item,1);
				else
					list.AddInEnd(item);
		}
		public int Count => list.Count;
		/// <summary>
		/// Add elemnt to end of collection
		/// </summary>
		/// <param name="value">node that will be linked with this node</param>
		public void Enqueue(T value)
		{
			if (list == null)
				list = new LinkedList<T>(value,1);
			else
				list.AddInEnd(value);
		}
		/// <summary>
		/// Get fitst element in Queue with Remove it from collection
		/// </summary>
		public T Dequeue()
		{
			return list != null ? list.RemoveFirstNode(): throw new Exception("Collection is Empty");
		}
		public T Top()
		{
			var node = list == null?throw new Exception("Collection is Empty"):list.RemoveLastNode() ;
			list.AddInEnd(node);
			return node;
		}
		public bool IsEmpty()
		{
			return list == null || list.Count == 0;
		}
		public IEnumerator<T> GetEnumerator()
		{
			return list == null ? throw new Exception("Empty Quere") : list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		public override string ToString()
		{
			StringBuilder @string = new();
			foreach (var item in this)
			{
				@string.Append($"{item} ");
			}
			return @string.ToString();
		}
	}
}
