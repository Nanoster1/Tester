using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.FirstTask.ThirtTask
{
	public class StackOfEblan<T> : IEnumerable<T>, IReadOnlyCollection<T>
	{
		private LinkedList<T> list;
		public StackOfEblan() { }
		public StackOfEblan(T fitstValue)
		{
			list = new LinkedList<T>(fitstValue);
		}
		public StackOfEblan(IEnumerable<T> collection)
		{
			foreach (var item in collection)
				if (list == null)
					list = new LinkedList<T>(item);
				else
					list.AddInEnd(item);
		}
		public int Count => list.Count;
		/// <summary>
		/// Add elemnt to end of collection
		/// </summary>
		/// <param name="value">node that will be linked with this node</param>
		public void Push(T value)
		{
			if (list == null)
				list = new LinkedList<T>(value);
			else
				list.AddInEnd(value);
		}

		public T Pop()
		{
			return list != null ? list.RemoveLastNode() : throw new Exception("Stack is Empty");
		}
		public IEnumerator<T> GetEnumerator()
		{
			return list == null ? throw new Exception("Stack is empty") : list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
