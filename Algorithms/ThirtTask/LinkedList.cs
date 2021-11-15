using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Algorithms.FirstTask.ThirtTask
{
	interface INode<TValue>
	{
		public abstract TValue Value { get; }
		public INode<TValue> NextNode { get; }
		/// <summary>
		/// Connect node to this node
		/// </summary>
		/// <param name="node">node that will be linked with this node</param>
		public void ConnectNode(INode<TValue> node);
		public void RemoveConnect();
	}

	class OneLinkNode<TValue> : INode<TValue>
	{
		public OneLinkNode(TValue value)
		{
			this.Value = value;
		}
		public TValue Value { get; }
		public INode<TValue> NextNode { get; private set; }
		public void ConnectNode(INode<TValue> node)
		{
			if (node is OneLinkNode<TValue>)
				this.NextNode = node ?? throw new Exception("Array is Empty");
			else
				throw new Exception("not correct node");
		}
		public void RemoveConnect()
		{
			this.NextNode = null;
		}
		public override bool Equals(object obj)
		{
			if (obj is OneLinkNode<TValue> node)
				return Value.Equals(node.Value) && NextNode.Equals(node.NextNode);
			else
				return false;
		}

		public override int GetHashCode()
		{
			return Value == null ? 0 : Value.GetHashCode();
		}
		public static OneLinkNode<TValue> Copy(OneLinkNode<TValue> value)
		{
			if (value != null)
			{
				var node = new OneLinkNode<TValue>(value.Value);
				node.ConnectNode(value.NextNode);
				return node;
			}
			else
			{
				return null;
			}
		}
	}
	class TwoLinkNode<TValue> : INode<TValue>
	{
		public TwoLinkNode(TValue value)
		{
			this.Value = value;
		}
		public TValue Value { get; }
		public INode<TValue> NextNode { get; private set; }
		public INode<TValue> LastNode { get; private set; }

		public void ConnectNode(INode<TValue> node)
		{
			if (node is TwoLinkNode<TValue> twoNode)
			{
				twoNode.LastNode = this;
				this.NextNode = node ?? throw new Exception("Array is Empty");
			}
			else
			{
				throw new Exception("Uncorrect type of node");
			}
		}
		public void RemoveConnect()
		{
			this.NextNode = null;
		}
		public override bool Equals(object obj)
		{
			if (obj is OneLinkNode<TValue> node)
				return Value.Equals(node.Value) && NextNode.Equals(node.NextNode);
			else
				return false;
		}

		public override int GetHashCode()
		{
			return Value == null ? 0 : Value.GetHashCode();
		}
		public static TwoLinkNode<TValue> Copy(TwoLinkNode<TValue> value)
		{
			if (value != null)
			{
				var node = new TwoLinkNode<TValue>(value.Value);
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
		private INode<TValue> firstNode;
		public LinkedList(TValue firstNode, int countOfTie)
		{
			switch (countOfTie)
			{
				case 1: this.firstNode = new OneLinkNode<TValue>(firstNode) ?? throw new Exception("Empty node"); break;
				case 2: this.firstNode = new TwoLinkNode<TValue>(firstNode) ?? throw new Exception("Empty node"); break;
			}
		}
		public LinkedList(IEnumerable<TValue> collection,int countOfTie)
		{
			foreach (var item in collection)
				AddInEnd(item);
		}
		LinkedList(INode<TValue> node)
		{
			this.firstNode = node;
		}
		public TValue FirstNode => firstNode.Value;
		public int Count { get; private set; } = 1;
		public void AddOnBegin(TValue value)
		{
			var node = new OneLinkNode<TValue>(value);
			node.ConnectNode(firstNode);
			firstNode = node;
			Count++;
		}
		public void AddInEnd(TValue value)
		{
			if (firstNode == null)
				firstNode = new OneLinkNode<TValue>(value);
			var node = firstNode;
			
			while (node.NextNode != null)
				node = node.NextNode;

			Count++;
			node.ConnectNode(new OneLinkNode<TValue>(value));
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
			if (firstNode != null)
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
		public void Clear()
		{
			this.firstNode = null;
			this.Count = 0;
		}
		public void FirstNodeToEnd()
		{
			if(this.firstNode != null && this.firstNode.NextNode != null)
			{
				var lastNode = this.firstNode;
				while (lastNode.NextNode != null)
				{
					lastNode = lastNode.NextNode;
				}
				var node = this.firstNode.NextNode;
				this.firstNode.RemoveConnect();
				lastNode.ConnectNode(this.firstNode);
				this.firstNode = node;
			}			
		}
		public int CountDifferentNum()
		{
			if(this is LinkedList<IComparable> list)
			{
				int count = list.Distinct().Count();
				return count;
			}
			else
			{
				return Count;
			}		
		}
		public LinkedList<IComparable> DistinctSimilarEl()
		{
			if(this is IEnumerable<IComparable> list)
			{
				var collection = list.Distinct();
				if (this.firstNode is OneLinkNode<IComparable>)
					return new LinkedList<IComparable>(collection, 1);
				else if (this.firstNode is TwoLinkNode<IComparable>)
					return new LinkedList<IComparable>(collection, 2);
				else
					throw new Exception("uncorrect Node");

			}
			return null;
		}
		public void InsertToIndex(TValue value,int index = 0)
		{
			if(Count > index)
			{
				if(index == 0 && this.firstNode == null)
				{
					this.firstNode = new OneLinkNode<TValue>(value);
				}
				var count = 0;
				var node = this.firstNode;
				while (node.NextNode != null && count < index)
				{
					count++;
					node = node.NextNode;
				}
				node.ConnectNode(new OneLinkNode<TValue>(value));
			}
			else
			{
				throw new Exception("uncorrect index");
			}			
		}
		public void Concat(LinkedList<TValue> list)
		{
			var node = this.firstNode;
			while (node.NextNode != null)
			{
				node = node.NextNode;
			}
			node.ConnectNode(list.firstNode);
		}
		public bool Remove(TValue value)
		{
			var node = this.firstNode.NextNode;
			var lastNode = this.firstNode;
			if (lastNode.Value.Equals(value))
			{
				this.firstNode = node;
				lastNode.RemoveConnect();
				return true;
			}
			while (node.NextNode != null)
			{		
				if(node.Value.Equals(value))
				{
					lastNode.ConnectNode(node.NextNode);
					node.RemoveConnect();
					return true;
				}
				lastNode = node.NextNode;
				node = node.NextNode;
			}
			return false;
		}
		public Tuple<LinkedList<TValue>,LinkedList<TValue>> SplitList(TValue value)
		{
			var node = this.firstNode.NextNode;
			var lastNode = this.firstNode;
			if (lastNode.Value.Equals(value))
			{
				return Tuple.Create(new LinkedList<TValue>(null),this);
			}
			while (node.NextNode != null)
			{
				if (node.Value.Equals(value))
				{
					lastNode.RemoveConnect();
					return Tuple.Create(this, new LinkedList<TValue>(node));
				}
				lastNode = node.NextNode;
				node = node.NextNode;
			}
			return Tuple.Create(this, new LinkedList<TValue>(null));
		}
		public IEnumerator<TValue> GetEnumerator()
		{
			INode<TValue> node = firstNode;
			if (firstNode != null)
			{
				yield return node.Value;
			}				
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
		public override string ToString()
		{
			var @string = new StringBuilder();
			foreach (var item in this)
			{
				@string.Append($"{item}, ");
			}
			return @string.ToString();
		}
	}
}

