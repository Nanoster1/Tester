using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace Algorithms.FirstTask.ThirtTask
{
	public class StackOfEblan<T> : IEnumerable<T>, IReadOnlyCollection<T>
	{
		private LinkedList<T> list;
		public StackOfEblan() { }
		public StackOfEblan(T fitstValue)
		{
			list = new LinkedList<T>(fitstValue,1);
		}
		public StackOfEblan(IEnumerable<T> collection)
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
		public void Push(T value)
		{
			if (list == null)
				list = new LinkedList<T>(value,1);
			else
				list.AddInEnd(value);
		}
		public T Top()
		{
			var result = Pop();
			list.AddInEnd(result);
			return result ?? throw new Exception("Stack is Empty");
		}

		public T Pop()
		{
			return list != null ? list.RemoveFirstNode() : throw new Exception("Stack is Empty");
		}
		public bool IsEmpty()
		{
			return list == null || list.Count == 0;
		}
		public IEnumerator<T> GetEnumerator()
		{
			return list == null ? throw new Exception("Stack is empty") : list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		public override string ToString()
		{
			return string.Join(", ", this).Trim();
		}
	}
}
