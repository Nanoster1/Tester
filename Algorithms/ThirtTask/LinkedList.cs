using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.FirstTask.ThirtTask
{
	class Node<TValue>
	{
		public Node(TValue value)
		{
			this.Value = value;
		}
		public TValue Value { get; }
		public Node<TValue> NextNode { get; private set; }
		/// <summary>
		/// Connect node to this node
		/// </summary>
		/// <param name="node">node that will be linked with this node</param>
		public void ConnectNode(Node<TValue> node)
		{
			this.NextNode = node ?? throw new Exception("Array is Empty");
		}
		public void RemoveConnect()
		{
			this.NextNode = null;
		}
		public override bool Equals(object obj)
		{
			if (obj is Node<TValue> node)
				return Value.Equals(node.Value) && NextNode.Equals(node.NextNode);
			else
				return false;
		}

		public override int GetHashCode()
		{
			return Value == null ? 0 : Value.GetHashCode();
		}
		public static Node<TValue> Copy(Node<TValue> value)
		{
			if(value != null)
			{
				var node = new Node<TValue>(value.Value);
				node.ConnectNode(value.NextNode);
				return node;
			}			
			else
			{
				return null;
			}
		}
	}
	public class LinkedList<TValue> : IReadOnlyCollection<TValue>, IEnumerable<TValue>
	{
		private Node<TValue> firstNode;
		public LinkedList(TValue firstNode)
		{
			this.firstNode = new Node<TValue>(firstNode) ?? throw new Exception("Empty node");
		}

		public TValue FirstNode => firstNode.Value;
		public int Count { get; private set; } = 1;
		public void AddOnBegin(TValue value)
		{
			var node = new Node<TValue>(value);
			node.ConnectNode(firstNode);
			firstNode = node;
			Count++;
		}
		public void AddInEnd(TValue value)
		{
			var node = firstNode;

			if (firstNode == null)
				firstNode = new Node<TValue>(value);
			while (node.NextNode != null)
				node = node.NextNode;

			Count++;
			node.ConnectNode(new Node<TValue>(value));
		}
		public TValue RemoveLastNode()
		{
			var node = firstNode ?? throw new Exception("Collection is Empty");

			if (node.NextNode == null)
			{
				var value = firstNode.Value; 
				this.firstNode = null;
				return value;
			}				
			while (node.NextNode.NextNode != null)
			{
				node = node.NextNode;
			}
			
			Count--;
			var lastNode = node.NextNode.Value;
			node.NextNode.RemoveConnect();
			return lastNode;
		}
		public TValue RemoveFirstNode()
		{
			if(firstNode != null)
			{
				var node = firstNode.Value;
				if (firstNode.NextNode != null)
				{
					firstNode = firstNode.NextNode;
				}
				else
				{				
					firstNode = null;					
				}
				Count--;
				return node;
			}
			else
			{
				throw new Exception("List is Empty");
			}
		}
		public IEnumerator<TValue> GetEnumerator()
		{
			Node<TValue> node = firstNode;
			yield return node.Value;
			while (node.NextNode != null)
			{			
				node = node.NextNode;
				yield return node.Value;
			}			
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
